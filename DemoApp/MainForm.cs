using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using AuthLib;
using MenuLib;

namespace DemoApp
{
    public partial class MainForm : Form
    {
        private readonly UserContext _ctx;
        private readonly IAuthService _authService;
        private readonly DataDrivenMenu _menu;

        public MainForm(UserContext ctx, IAuthService authService)
        {
            _ctx = ctx;
            _authService = authService;
            InitializeComponent();
            sslUser.Text = $"Пользователь: {_ctx.UserName} ({_ctx.RoleName})";
            sslVer.Text = "Версия: " + Application.ProductVersion;

            _menu = new DataDrivenMenu(_ctx.ConnectionString);
            BuildMenu();
        }

        private void BuildMenu()
        {
            foreach (var item in _menu.Roots())
            {
                if (_ctx.CanSee(item.Id))
                    menuStrip1.Items.Add(CreateItem(item));
            }
        }

        private ToolStripMenuItem CreateItem(DbMenuItem item)
        {
            var mi = new ToolStripMenuItem(item.Caption)
            {
                Enabled = _ctx.CanUse(item.Id),
                Tag = item
            };

            foreach (var child in _menu.ChildrenOf(item))
            {
                if (_ctx.CanSee(child.Id))
                    mi.DropDownItems.Add(CreateItem(child));
            }

            if (!string.IsNullOrEmpty(item.DllName) || string.Equals(item.Caption, "ChangePassword", StringComparison.OrdinalIgnoreCase))
            {
                mi.Click += MenuClicked;
            }

            return mi;
        }

        private void MenuClicked(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem mi && mi.Tag is DbMenuItem item)
            {
                if (string.Equals(item.Caption, "ChangePassword", StringComparison.OrdinalIgnoreCase))
                {
                    using (var form = new ChangePasswordForm(_authService, _ctx))
                        form.ShowDialog(this);
                    return;
                }

                LoadModule(item);
            }
        }

        private void LoadModule(DbMenuItem item)
        {
            var modulesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules");
            var path = Path.Combine(modulesDir, item.DllName);

            if (!File.Exists(path))
            {
                MessageBox.Show($"Модуль {item.DllName} не найден в {modulesDir}", "Модуль", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var asm = Assembly.LoadFrom(path);
                var type = asm.GetType(item.EntryPoint, throwOnError: true);
                if (!(Activator.CreateInstance(type) is IModuleEntry entry))
                    throw new InvalidOperationException("Точка входа не реализует IModuleEntry");

                var form = entry.CreateForm(_ctx);
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка открытия модуля: " + ex.Message, "Модуль", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
