using System;
using System.Collections.Generic;
using System.IO;

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
        public string UserName { get; private set; }
        public Dictionary<string, ItemStatus> Rules { get; private set; }

        public UserContext(string name)
        {
            UserName = name;
            Rules = new Dictionary<string, ItemStatus>();
        }

        public bool CanSee(string title)
        {
            ItemStatus s;
            return !Rules.TryGetValue(title, out s) || s != ItemStatus.Hidden;
        }

        public bool CanUse(string title)
        {
            ItemStatus s;
            return !Rules.TryGetValue(title, out s) || s == ItemStatus.Enabled;
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

    public interface IAuthService
    {
        LoginResult Login(string user, string pass, string path = "USERS.txt");
    }

    public class FileAuthService : IAuthService
    {
        public LoginResult Login(string user, string pass, string path = "USERS.txt")
        {
            if (!File.Exists(path))
                return new LoginResult(LoginStatus.UserMissing, null);

            var lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].TrimEnd();
                if (!line.StartsWith("#")) continue;

                string[] head = line.Substring(1)
                                    .Split(new[] { ' ' }, 2,
                                           StringSplitOptions.RemoveEmptyEntries);
                if (head.Length != 2) continue;

                if (head[0] != user)
                    continue;

                if (head[1].Trim() != pass.Trim())
                    return new LoginResult(LoginStatus.WrongPass, null);

                var ctx = new UserContext(user);

                // Читаем права до следующего «#» или конца файла.
                for (int j = i + 1;
                     j < lines.Length && !lines[j].StartsWith("#"); j++)
                {
                    var p = lines[j].Trim()
                                    .Split(new[] { ' ' }, 2,
                                           StringSplitOptions.RemoveEmptyEntries);
                    if (p.Length == 2)
                    {
                        int st;
                        if (int.TryParse(p[1], out st) &&
                            Enum.IsDefined(typeof(ItemStatus), st))
                            ctx.Rules[p[0]] = (ItemStatus)st;
                    }
                }
                return new LoginResult(LoginStatus.Success, ctx);
            }
            return new LoginResult(LoginStatus.UserMissing, null);
        }
    }
}
