using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MenuLib
{
    /// <summary>Один пункт меню.</summary>
    public class MenuItem
    {
        public int Level { get; }
        public string Title { get; }
        public string Handler { get; }   // null ⇒ есть подпункты

        public MenuItem(int level, string title, string handler)
        {
            Level = level;
            Title = title;
            Handler = handler;           // может быть null/Empty
        }
    }

    /// <summary>Читает menu.txt и предоставляет логику меню.</summary>
    public class DataDrivenMenu
    {
        public List<MenuItem> Items { get; private set; }

        public DataDrivenMenu(string path = "menu.txt")
        {
            Items = File.ReadAllLines(path)
                        .Where(l => !string.IsNullOrWhiteSpace(l) &&
                                    !l.TrimStart().StartsWith("#"))
                        .Select(Parse)
                        .ToList();
        }

        private static MenuItem Parse(string line)
        {
            // Для Framework 4.x используем массив символов:
            var parts = line.Split(new[] { ' ' }, 3,
                                   StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                throw new FormatException("Некорректная строка меню: " + line);

            int level = int.Parse(parts[0]);
            string title = parts[1];
            string handler = parts.Length == 3 ? parts[2] : null;
            return new MenuItem(level, title, handler);
        }

        /// <summary>Все непосредственные подпункты parent.</summary>
        public IEnumerable<MenuItem> ChildrenOf(MenuItem parent)
        {
            int index = Items.IndexOf(parent);
            if (index < 0) yield break;

            int parentLevel = parent.Level;
            for (int i = index + 1; i < Items.Count && Items[i].Level > parentLevel; i++)
                if (Items[i].Level == parentLevel + 1)
                    yield return Items[i];
        }

        /// <summary>Пытается вызвать метод-обработчик на target.</summary>
        public void Invoke(MenuItem item, object target)
        {
            if (string.IsNullOrEmpty(item.Handler)) return;

            var method = target.GetType()
                               .GetMethod(item.Handler,
                                          BindingFlags.Instance |
                                          BindingFlags.Public |
                                          BindingFlags.NonPublic);

            if (method == null)
                throw new MissingMethodException("Метод не найден: " + item.Handler);

            method.Invoke(target, null);
        }
    }
}
