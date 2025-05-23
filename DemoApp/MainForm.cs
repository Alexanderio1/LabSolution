using System;
using System.Linq;
using System.Windows.Forms;
using MenuLib;
using AuthLib;

namespace DemoApp
{
    public partial class MainForm : Form
    {
        private readonly UserContext _ctx;
        private readonly DataDrivenMenu _menu = new DataDrivenMenu("menu.txt");

        public MainForm(UserContext ctx)
        {
            _ctx = ctx;
            InitializeComponent();
            sslUser.Text = "Пользователь: " + _ctx.UserName;
            sslSpacer.Text = "Версия: " + Application.ProductVersion;
            BuildMenu();
        }

        /* строим меню из файла с учётом прав */
        private void BuildMenu()
        {
            foreach (MenuLib.MenuItem root in _menu.Items.Where(m => m.Level == 0 &&
                                                        _ctx.CanSee(m.Title)))
                menuStrip1.Items.Add(CreateItem(root));
        }

        private ToolStripMenuItem CreateItem(MenuLib.MenuItem item)
        {
            var mi = new ToolStripMenuItem(item.Title)
            {
                Enabled = _ctx.CanUse(item.Title)
            };

            foreach (var child in _menu.ChildrenOf(item)
                                       .Where(c => _ctx.CanSee(c.Title)))
                mi.DropDownItems.Add(CreateItem(child));

            if (!string.IsNullOrEmpty(item.Handler))
                mi.Click += (_, __) => _menu.Invoke(item, this);
            return mi;
        }

        /* ----- заглушки обработчиков из menu.txt ----- */
        private void Others() => MessageBox.Show("Разное");
        private void Stuff() => MessageBox.Show("Сотрудники");
        private void Orders() => MessageBox.Show("Приказы");
        private void Docs() => MessageBox.Show("Документы");
        private void Departs() => MessageBox.Show("Отделы");
        private void Towns() => MessageBox.Show("Города");
        private void Posts() => MessageBox.Show("Должности");
        private void Window() => MessageBox.Show("Окно");
        private void About() => MessageBox.Show("О программе");
        private void Content() => MessageBox.Show("Оглавление");
    }
}
