using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AuthLib;
using Npgsql;

namespace SqlConsoleModule
{
    public class SqlConsoleForm : Form
    {
        private class TemplateItem
        {
            public string Title { get; set; }
            public string Sql { get; set; }
            public string Description { get; set; }
            public override string ToString() => Title;
        }

        private readonly UserContext _ctx;
        private readonly bool _templateMode;
        private readonly TextBox _txtSql;
        private readonly DataGridView _grid;
        private readonly FlowLayoutPanel _paramPanel;
        private readonly ListBox _templates;
        private readonly Label _lblInfo;

        public SqlConsoleForm(UserContext ctx, bool templateMode)
        {
            _ctx = ctx;
            _templateMode = templateMode;
            _templates = new ListBox();

            Text = templateMode ? "Запросы ИС" : "SQL-консоль";
            WindowState = FormWindowState.Maximized;

            _txtSql = new TextBox { Multiline = true, ScrollBars = ScrollBars.Vertical, Dock = DockStyle.Top, Height = 150, Font = new Font("Consolas", 10) };
            _txtSql.TextChanged += (s, e) => BuildParameterEditors();
            var btnExecute = new Button { Text = "Выполнить", Dock = DockStyle.Top, Height = 35 };
            btnExecute.Click += ExecuteQuery;

            _paramPanel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 60, AutoScroll = true };
            _lblInfo = new Label { Dock = DockStyle.Top, Height = 30, Text = "" };
            _grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

            Controls.Add(_grid);
            Controls.Add(_lblInfo);
            Controls.Add(_paramPanel);
            Controls.Add(btnExecute);
            Controls.Add(_txtSql);

            if (_templateMode)
            {
                _templates.Dock = DockStyle.Left;
                _templates.Width = 250;
                _templates.SelectedIndexChanged += TemplateChanged;
                Controls.Add(_templates);
                LoadTemplates();
            }
        }

        private void LoadTemplates()
        {
            var items = new List<TemplateItem>();
            using (var conn = new NpgsqlConnection(_ctx.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id, title, sql_text, description FROM query_templates ORDER BY id", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new TemplateItem
                        {
                            Title = reader.GetString(1),
                            Sql = reader.GetString(2),
                            Description = reader.IsDBNull(3) ? string.Empty : reader.GetString(3)
                        });
                    }
                }
            }

            foreach (var item in items)
            {
                _templates.Items.Add(item);
            }
            if (_templates.Items.Count > 0)
                _templates.SelectedIndex = 0;
        }

        private void TemplateChanged(object sender, EventArgs e)
        {
            if (_templates.SelectedItem is TemplateItem selected)
            {
                _txtSql.Text = selected.Sql;
                _lblInfo.Text = selected.Description;
            }
        }

        private void BuildParameterEditors()
        {
            _paramPanel.Controls.Clear();
            var parameters = ExtractParameters(_txtSql.Text);
            foreach (var p in parameters)
            {
                var label = new Label { Text = p + ":", Width = 90, TextAlign = ContentAlignment.MiddleLeft, Margin = new Padding(5) };
                var box = new TextBox { Name = "param_" + p.Trim('@'), Width = 120, Margin = new Padding(5) };
                _paramPanel.Controls.Add(label);
                _paramPanel.Controls.Add(box);
            }
        }

        private static List<string> ExtractParameters(string sql)
        {
            return Regex.Matches(sql, @"@[A-Za-z0-9_]+")
                        .Cast<Match>()
                        .Select(m => m.Value)
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .ToList();
        }

        private bool IsSqlAllowed(string sql, out string error)
        {
            error = null;
            var trimmed = sql.Trim();
            if (string.IsNullOrWhiteSpace(trimmed))
            {
                error = "Введите SELECT запрос";
                return false;
            }

            if (trimmed.Contains(";"))
            {
                error = "Разрешен только один SELECT без точки с запятой";
                return false;
            }

            var lower = trimmed.ToLowerInvariant();
            if (!(lower.StartsWith("select") || lower.StartsWith("with")))
            {
                error = "Допустим только SELECT / WITH";
                return false;
            }

            if (Regex.IsMatch(lower, @"\b(insert|update|delete|drop|create|alter|truncate)\b"))
            {
                error = "DML/DDL команды запрещены";
                return false;
            }

            if (lower.StartsWith("with") && !lower.Contains("select"))
            {
                error = "WITH должен содержать SELECT";
                return false;
            }

            return true;
        }

        private void ExecuteQuery(object sender, EventArgs e)
        {
            var sql = _txtSql.Text;
            if (!IsSqlAllowed(sql, out var error))
            {
                MessageBox.Show(error, "SQL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var parameters = ExtractParameters(sql);
            try
            {
                using (var conn = new NpgsqlConnection(_ctx.ConnectionString))
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    foreach (var p in parameters)
                    {
                        var ctl = _paramPanel.Controls.Cast<Control>().FirstOrDefault(c => c.Name == "param_" + p.Trim('@')) as TextBox;
                        var value = ctl != null ? ctl.Text : string.Empty;
                        cmd.Parameters.AddWithValue(p.Trim('@'), GuessValue(value));
                    }

                    var table = new DataTable();
                    adapter.Fill(table);
                    _grid.DataSource = table;
                    _lblInfo.Text = $"Получено строк: {table.Rows.Count}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка выполнения запроса: " + ex.Message, "SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private object GuessValue(string value)
        {
            if (DateTime.TryParse(value, out var dt))
                return dt;
            if (int.TryParse(value, out var i))
                return i;
            if (decimal.TryParse(value, out var d))
                return d;
            return value ?? string.Empty;
        }
    }
}
