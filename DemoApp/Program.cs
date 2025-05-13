using System;
using System.IO;
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

            using (var login = new LoginForm())
            {
                if (login.ShowDialog() != DialogResult.OK ||
                    !login.Result.IsSuccess)
                    return;                       // отказ или неуспех
                Application.Run(new MainForm(login.Result.Context));
            }
        }
    }
}
