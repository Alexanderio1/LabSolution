using System;
using System.Drawing;
using System.Windows.Forms;
using AuthLib;

namespace DemoApp
{
    public class ChangePasswordForm : Form
    {
        private readonly IAuthService _authService;
        private readonly UserContext _context;
        private readonly TextBox _txtNew;
        private readonly TextBox _txtConfirm;
        private readonly ComboBox _cmbAlgo;
        private readonly NumericUpDown _numIterations;

        public ChangePasswordForm(IAuthService authService, UserContext context)
        {
            _authService = authService;
            _context = context;
            Text = "Смена пароля";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(420, 220);

            var lblNew = new Label { Text = "Новый пароль:", AutoSize = true, Location = new Point(20, 25) };
            var lblConfirm = new Label { Text = "Повторите пароль:", AutoSize = true, Location = new Point(20, 65) };
            var lblAlgo = new Label { Text = "Алгоритм:", AutoSize = true, Location = new Point(20, 105) };
            var lblIter = new Label { Text = "Iterations:", AutoSize = true, Location = new Point(220, 105) };

            _txtNew = new TextBox { Location = new Point(150, 20), Width = 230, UseSystemPasswordChar = true };
            _txtConfirm = new TextBox { Location = new Point(150, 60), Width = 230, UseSystemPasswordChar = true };
            _cmbAlgo = new ComboBox { Location = new Point(150, 100), Width = 60, DropDownStyle = ComboBoxStyle.DropDownList };
            _cmbAlgo.Items.AddRange(new object[] { "PBKDF2", "MD5" });
            _cmbAlgo.SelectedIndex = 0;
            _numIterations = new NumericUpDown { Location = new Point(300, 100), Width = 80, Minimum = 1000, Maximum = 500000, Value = 120000, Increment = 1000 };

            var btnOk = new Button { Text = "Сохранить", DialogResult = DialogResult.OK, Location = new Point(150, 150), Width = 110 };
            var btnCancel = new Button { Text = "Отмена", DialogResult = DialogResult.Cancel, Location = new Point(270, 150), Width = 110 };

            btnOk.Click += Save;

            Controls.AddRange(new Control[] { lblNew, lblConfirm, lblAlgo, lblIter, _txtNew, _txtConfirm, _cmbAlgo, _numIterations, btnOk, btnCancel });
        }

        private void Save(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtNew.Text))
            {
                MessageBox.Show("Введите новый пароль", "Пароль", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            if (_txtNew.Text != _txtConfirm.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Пароль", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            try
            {
                var iterations = _cmbAlgo.SelectedItem.ToString() == "PBKDF2" ? (int?)_numIterations.Value : 1;
                _authService.ChangePassword(_context.UserId, _txtNew.Text, _cmbAlgo.SelectedItem.ToString(), iterations);
                MessageBox.Show("Пароль обновлен", "Пароль", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при смене пароля: " + ex.Message, "Пароль", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
