using AuthLib;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;

namespace DemoApp
{
    public partial class LoginForm : Form
    {
        private readonly IAuthService _auth = new FileAuthService();
        public LoginResult Result { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            
            this.BackColor = Color.FromArgb(224, 240, 255);
            lblTitle.BackColor = Color.FromArgb(255, 250, 205);
            lblVersion.Parent = lblVersionBar;
            lblVersion.Text = "Версия " + Application.ProductVersion;
            KeyPreview = true;
            this.KeyUp += AnyKey;
            txtUser.KeyUp += AnyKey;
            txtPass.KeyUp += AnyKey;
            this.InputLanguageChanged += (s, e) => UpdateStatus();
            UpdateStatus();
        }
        
        /* --- обработчик кнопки "Вход" (btnOk) --- */
        private void btnOk_Click(object sender, EventArgs e)
        {
            Result = _auth.Login(txtUser.Text, txtPass.Text);
            if (!Result.IsSuccess)
            {
                MessageBox.Show("Неверные имя или пароль", Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }

        /* --- статусная строка --- */
        private void AnyKey(object s, KeyEventArgs e) => UpdateStatus();

        private void UpdateStatus()
        {
            sslLang.Text = "Язык ввода: " + InputLanguage.CurrentInputLanguage.LayoutName;

            bool caps = Control.IsKeyLocked(Keys.CapsLock);
            sslSpacer.Text = "Клавиша CapsLock " + (caps ? "нажата" : "выключена");
            sslSpacer.ForeColor = caps ? Color.Blue : SystemColors.GrayText;
        }

        private void btnCancel_Click(object s, EventArgs e) => Close();
    }
}
