using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AuthLib;
using Npgsql;

namespace TableBrowserModule
{
    public class TableBrowserForm : Form
    {
        private readonly UserContext _ctx;
        private readonly ComboBox _cmbTables;
        private readonly ComboBox _cmbSort;
        private readonly TextBox _txtSearch;
        private readonly NumericUpDown _numLimit;
        private readonly DataGridView _grid;

        public TableBrowserForm(UserContext ctx)
        {
            _ctx = ctx;
            Text = "Таблицы и справочники";
            WindowState = FormWindowState.Maximized;

            var topPanel = new Panel { Dock = DockStyle.Top, Height = 45 };

            _cmbTables = new ComboBox { Location = new Point(15, 10), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            _cmbTables.SelectedIndexChanged += (s, e) => LoadData();

            _txtSearch = new TextBox { Location = new Point(250, 10), Width = 200 };
            _txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadData(); };

            _cmbSort = new ComboBox { Location = new Point(470, 10), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            _numLimit = new NumericUpDown { Location = new Point(640, 10), Width = 80, Minimum = 10, Maximum = 5000, Value = 200, Increment = 10 };
            var btnReload = new Button { Text = "Обновить", Location = new Point(740, 8), Width = 90 };
            btnReload.Click += (s, e) => LoadData();

            topPanel.Controls.AddRange(new Control[] { _cmbTables, _txtSearch, _cmbSort, _numLimit, btnReload });

            _grid = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

            Controls.AddRange(new Control[] { topPanel, _grid });
            LoadTables();
        }

        private void LoadTables()
        {
            using (var conn = new NpgsqlConnection(_ctx.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(@"SELECT table_name FROM information_schema.tables
                                                      WHERE table_schema NOT IN ('pg_catalog','information_schema')
                                                      ORDER BY table_name", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        _cmbTables.Items.Add(reader.GetString(0));
                }
            }

            if (_cmbTables.Items.Count > 0)
                _cmbTables.SelectedIndex = 0;
        }

        private List<(string name, string dataType)> LoadColumns(string table)
        {
            var cols = new List<(string, string)>();
            using (var conn = new NpgsqlConnection(_ctx.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(@"SELECT column_name, data_type FROM information_schema.columns
                                                      WHERE table_schema NOT IN ('pg_catalog','information_schema') AND table_name=@t
                                                      ORDER BY ordinal_position", conn))
                {
                    cmd.Parameters.AddWithValue("t", table);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cols.Add((reader.GetString(0), reader.GetString(1)));
                    }
                }
            }
            return cols;
        }

        private void LoadData()
        {
            if (_cmbTables.SelectedItem == null)
                return;

            var table = _cmbTables.SelectedItem.ToString();
            var columns = LoadColumns(table);
            var textColumns = columns.Where(c => c.dataType.Contains("char") || c.dataType.Contains("text")).Select(c => c.name).ToList();

            _cmbSort.Items.Clear();
            foreach (var c in columns)
                _cmbSort.Items.Add(c.name);
            if (_cmbSort.Items.Count > 0)
                _cmbSort.SelectedIndex = 0;

            var filters = new List<string>();
            var cmdText = $"SELECT * FROM \"{table}\"";

            if (!string.IsNullOrWhiteSpace(_txtSearch.Text) && textColumns.Any())
            {
                var searchParts = textColumns.Select((c, i) => $"\"{c}\" ILIKE @p{i}");
                filters.Add("(" + string.Join(" OR ", searchParts) + ")");
            }

            if (filters.Any())
            {
                cmdText += " WHERE " + string.Join(" AND ", filters);
            }

            if (_cmbSort.SelectedItem != null)
            {
                cmdText += $" ORDER BY \"{_cmbSort.SelectedItem}\"";
            }

            cmdText += " LIMIT @limit";

            using (var conn = new NpgsqlConnection(_ctx.ConnectionString))
            using (var cmd = new NpgsqlCommand(cmdText, conn))
            using (var adapter = new NpgsqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("limit", (int)_numLimit.Value);
                if (!string.IsNullOrWhiteSpace(_txtSearch.Text) && textColumns.Any())
                {
                    for (int i = 0; i < textColumns.Count; i++)
                        cmd.Parameters.AddWithValue($"p{i}", "%" + _txtSearch.Text + "%");
                }

                var tableData = new DataTable();
                adapter.Fill(tableData);
                _grid.DataSource = tableData;
            }
        }
    }
}
