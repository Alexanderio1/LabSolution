using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Npgsql;

namespace MenuLib
{
    public class DbMenuItem
    {
        public int Id { get; }
        public int? ParentId { get; }
        public string Caption { get; }
        public string DllName { get; }
        public string EntryPoint { get; }
        public int SortOrder { get; }

        public DbMenuItem(int id, int? parentId, string caption, string dllName, string entryPoint, int sortOrder)
        {
            Id = id;
            ParentId = parentId;
            Caption = caption;
            DllName = dllName;
            EntryPoint = entryPoint;
            SortOrder = sortOrder;
        }
    }

    public class DataDrivenMenu
    {
        public List<DbMenuItem> Items { get; private set; }

        public DataDrivenMenu(string connectionString = null)
        {
            var cs = connectionString ?? ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Items = Load(cs);
        }

        private static List<DbMenuItem> Load(string connectionString)
        {
            var items = new List<DbMenuItem>();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(@"SELECT id, parent_id, caption, dll_name, entry_point, sort_order
                                                     FROM menu_items
                                                    ORDER BY COALESCE(parent_id, 0), sort_order, id", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new DbMenuItem(
                            reader.GetInt32(0),
                            reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                            reader.GetString(2),
                            reader.IsDBNull(3) ? null : reader.GetString(3),
                            reader.IsDBNull(4) ? null : reader.GetString(4),
                            reader.GetInt32(5)));
                    }
                }
            }
            return items;
        }

        public IEnumerable<DbMenuItem> Roots()
        {
            return Items.Where(i => i.ParentId == null).OrderBy(i => i.SortOrder).ThenBy(i => i.Id);
        }

        public IEnumerable<DbMenuItem> ChildrenOf(DbMenuItem parent)
        {
            return Items.Where(i => i.ParentId == parent.Id).OrderBy(i => i.SortOrder).ThenBy(i => i.Id);
        }
    }
}
