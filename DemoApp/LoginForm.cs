using System;
using System.Drawing;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class LoginForm : Form
    {
        // Публичные свойства, чтобы Program.cs забрал логин/пароль.
        public string User => txtUser.Text;
        public string Pass => txtPass.Text;

        public LoginForm()
        {
            InitializeComponent();

            
            BackColor = Color.FromArgb(224, 240, 255);
            lblTitle.BackColor = Color.FromArgb(255, 250, 205);
            lblVersion.Parent = lblVersionBar;
            lblVersion.Text = "Версия " + Application.ProductVersion;

            // События для CapsLock / языка ввода.
            KeyPreview = true;
            KeyUp += AnyKey;
            txtUser.KeyUp += AnyKey;
            txtPass.KeyUp += AnyKey;
            InputLanguageChanged += (s, e) => UpdateStatus();
            UpdateStatus();
        }

        // Кнопка «Вход» просто выставляет OK.
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        // CapsLock / язык ввода.
        private void AnyKey(object sender, KeyEventArgs e) => UpdateStatus();

        private void UpdateStatus()
        {
            sslLang.Text = "Язык ввода: " +
                           InputLanguage.CurrentInputLanguage.LayoutName;

            bool caps = Control.IsKeyLocked(Keys.CapsLock);
            sslSpacer.Text = "Клавиша CapsLock " +
                                  (caps ? "нажата" : "выключена");
            sslSpacer.ForeColor = caps ? Color.Blue : SystemColors.GrayText;
        }
    }
}
