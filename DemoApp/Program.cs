using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

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

            // Явная загрузка AuthLib.dll.
            Assembly asmAuth = Assembly.LoadFrom("AuthLib.dll");
            Type tAuth = asmAuth.GetType("AuthLib.FileAuthService");
            dynamic authSvc = Activator.CreateInstance(tAuth);

            // Форма логина.
            LoginForm login = new LoginForm();
            if (login.ShowDialog() != DialogResult.OK) return;

            // Авторизация.
            dynamic result = authSvc.Login(login.User, login.Pass, "USERS.txt");
            if (!(bool)result.IsSuccess)
            {
                MessageBox.Show("Неверные имя или пароль", "Вход",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm(result.Context));
        }
    }
}
