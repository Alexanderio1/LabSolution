using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class MainForm : Form
    {
        private readonly dynamic _ctx;
        private readonly dynamic _menu;
        private readonly MethodInfo _childrenOf;

        public MainForm(dynamic ctx)
        {
            _ctx = ctx;
            InitializeComponent();
            sslUser.Text = "Пользователь: " + _ctx.UserName;
            sslVer.Text = "Версия: " + Application.ProductVersion;

            Assembly asmMenu = Assembly.LoadFrom("MenuLib.dll");
            Type tMenu = asmMenu.GetType("MenuLib.DataDrivenMenu");
            _menu = Activator.CreateInstance(tMenu, new object[] { "menu.txt" });
            _childrenOf = tMenu.GetMethod("ChildrenOf");

            BuildMenu();
        }

        private void BuildMenu()
        {
            foreach (dynamic item in _menu.Items)
            {
                if (item.Level == 0 && _ctx.CanSee(item.Title))
                    menuStrip1.Items.Add(CreateItem(item));
            }
        }

        private ToolStripMenuItem CreateItem(dynamic item)
        {
            var mi = new ToolStripMenuItem((string)item.Title)
            {
                Enabled = _ctx.CanUse(item.Title)
            };

            foreach (dynamic child in (System.Collections.IEnumerable)
                     _childrenOf.Invoke(_menu, new object[] { item }))
            {
                if (_ctx.CanSee(child.Title))
                    mi.DropDownItems.Add(CreateItem(child));
            }

            if (!string.IsNullOrEmpty((string)item.Handler))
                mi.Click += delegate { _menu.Invoke(item, this); };

            return mi;
        }

        private void Others() => MessageBox.Show("Разное");
        private void Stuff() => MessageBox.Show("Сотрудники");
        private void Orders() => MessageBox.Show("Приказы");
        private void Docs() => MessageBox.Show("Документы");
        private void Departs() => MessageBox.Show("Отделы");
        private void Towns() => MessageBox.Show("Города");
        private void Posts() => MessageBox.Show("Должности");
        private void About() => MessageBox.Show("О программе");
        private void Content() => MessageBox.Show("Оглавление");
        private void Window() => MessageBox.Show("Окно");
    }
}
