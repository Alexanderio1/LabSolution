using System;
using System.IO;
using System.Windows.Forms;
using AuthLib;

namespace DemoApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            var authSvc = new DbAuthService();
            LoginForm login = new LoginForm();

            if (login.ShowDialog() != DialogResult.OK)
                return;

            var result = authSvc.Login(login.User, login.Pass);
            if (!result.IsSuccess)
            {
                MessageBox.Show("Неверные имя или пароль", "Вход",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result.Context.MustChangePassword)
            {
                using (var change = new ChangePasswordForm(authSvc, result.Context))
                {
                    if (change.ShowDialog() != DialogResult.OK)
                        return;
                }
            }

            Application.Run(new MainForm(result.Context, authSvc));
        }
    }
}
