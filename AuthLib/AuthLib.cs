using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Npgsql;

namespace AuthLib
{
    [Flags]
    public enum LoginStatus
    {
        None = 0,
        Success = 1,
        WrongPass = 2,
        UserMissing = 4
    }

    public enum ItemStatus { Enabled = 0, Disabled = 1, Hidden = 2 }

    public class UserContext
    {
        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public int RoleId { get; private set; }
        public string RoleName { get; private set; }
        public string ConnectionString { get; private set; }
        public bool MustChangePassword { get; private set; }
        public Dictionary<int, ItemStatus> Rules { get; private set; }

        public UserContext(int id, string name, int roleId, string roleName, string connectionString, bool mustChangePassword)
        {
            UserId = id;
            UserName = name;
            RoleId = roleId;
            RoleName = roleName;
            ConnectionString = connectionString;
            MustChangePassword = mustChangePassword;
            Rules = new Dictionary<int, ItemStatus>();
        }

        public bool CanSee(int menuId)
        {
            return !Rules.TryGetValue(menuId, out var status) || status != ItemStatus.Hidden;
        }

        public bool CanUse(int menuId)
        {
            return !Rules.TryGetValue(menuId, out var status) || status == ItemStatus.Enabled;
        }
    }

    public class LoginResult
    {
        public LoginStatus Status { get; private set; }
        public UserContext Context { get; private set; }
        public bool IsSuccess { get { return (Status & LoginStatus.Success) != 0; } }

        public LoginResult(LoginStatus st, UserContext ctx)
        { Status = st; Context = ctx; }
    }

    public interface IModuleEntry
    {
        System.Windows.Forms.Form CreateForm(UserContext ctx);
    }

    public interface IAuthService
    {
        LoginResult Login(string user, string pass);
        void ChangePassword(int userId, string newPassword, string algorithm = "PBKDF2", int? iterations = null);
    }

    public static class PasswordHasher
    {
        private const int DefaultIterations = 120000;

        public static (string hash, string salt, int iterations) HashPassword(string password, string algorithm = "PBKDF2", int? iterations = null)
        {
            if (string.Equals(algorithm, "MD5", StringComparison.OrdinalIgnoreCase))
            {
                var saltBytes = RandomNumberGenerator.GetBytes(8);
                return (HashMd5(password, saltBytes), Convert.ToBase64String(saltBytes), 1);
            }

            var salt = RandomNumberGenerator.GetBytes(16);
            var iter = iterations ?? DefaultIterations;
            return (HashPbkdf2(password, salt, iter), Convert.ToBase64String(salt), iter);
        }

        public static bool Verify(string password, string storedHash, string saltBase64, string algorithm, int iterations)
        {
            var salt = Convert.FromBase64String(saltBase64);
            if (string.Equals(algorithm, "MD5", StringComparison.OrdinalIgnoreCase))
            {
                return string.Equals(storedHash, HashMd5(password, salt), StringComparison.OrdinalIgnoreCase);
            }

            var hash = HashPbkdf2(password, salt, iterations > 0 ? iterations : DefaultIterations);
            return SlowEquals(Convert.FromBase64String(storedHash), Convert.FromBase64String(hash));
        }

        private static string HashPbkdf2(string password, byte[] salt, int iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                return Convert.ToBase64String(pbkdf2.GetBytes(32));
            }
        }

        private static string HashMd5(string password, byte[] salt)
        {
            using (var md5 = MD5.Create())
            {
                var data = salt.Concat(Encoding.UTF8.GetBytes(password)).ToArray();
                var hash = md5.ComputeHash(data);
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            }
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }

    public class DbAuthService : IAuthService
    {
        private readonly string _connectionString;

        public DbAuthService(string connectionString = null)
        {
            _connectionString = connectionString ?? ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public LoginResult Login(string user, string pass)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(@"SELECT u.id, u.username, u.password_hash, u.salt, u.algorithm, u.iterations, u.role_id, u.must_change_password, r.name as role_name
                                                       FROM users u
                                                       JOIN roles r ON r.id = u.role_id
                                                      WHERE u.username = @user", conn))
                {
                    cmd.Parameters.AddWithValue("user", user);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return new LoginResult(LoginStatus.UserMissing, null);

                        var storedHash = reader.GetString(reader.GetOrdinal("password_hash"));
                        var salt = reader.GetString(reader.GetOrdinal("salt"));
                        var alg = reader.GetString(reader.GetOrdinal("algorithm"));
                        var iterations = reader.GetInt32(reader.GetOrdinal("iterations"));

                        if (!PasswordHasher.Verify(pass, storedHash, salt, alg, iterations))
                            return new LoginResult(LoginStatus.WrongPass, null);

                        int userId = reader.GetInt32(reader.GetOrdinal("id"));
                        int roleId = reader.GetInt32(reader.GetOrdinal("role_id"));
                        string roleName = reader.GetString(reader.GetOrdinal("role_name"));
                        bool mustChange = reader.GetBoolean(reader.GetOrdinal("must_change_password"));

                        var ctx = new UserContext(userId, user, roleId, roleName, _connectionString, mustChange);
                        reader.Close();
                        LoadRights(conn, ctx);
                        return new LoginResult(LoginStatus.Success, ctx);
                    }
                }
            }
        }

        public void ChangePassword(int userId, string newPassword, string algorithm = "PBKDF2", int? iterations = null)
        {
            var hashData = PasswordHasher.HashPassword(newPassword, algorithm, iterations);
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(@"UPDATE users SET password_hash=@hash, salt=@salt, algorithm=@alg, iterations=@iter, must_change_password=FALSE WHERE id=@id", conn))
                {
                    cmd.Parameters.AddWithValue("hash", hashData.hash);
                    cmd.Parameters.AddWithValue("salt", hashData.salt);
                    cmd.Parameters.AddWithValue("alg", algorithm); 
                    cmd.Parameters.AddWithValue("iter", hashData.iterations);
                    cmd.Parameters.AddWithValue("id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void LoadRights(NpgsqlConnection conn, UserContext ctx)
        {
            using (var cmd = new NpgsqlCommand("SELECT menu_item_id, status FROM role_rights WHERE role_id=@rid", conn))
            {
                cmd.Parameters.AddWithValue("rid", ctx.RoleId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ctx.Rules[reader.GetInt32(0)] = (ItemStatus)reader.GetInt16(1);
                    }
                }
            }
        }
    }
}
