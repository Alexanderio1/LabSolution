using System;                       // базовые типы (Exception и пр.)
using System.Collections.Generic;   // List<>, IEnumerable<>
using System.IO;                    // File.ReadAllLines
using System.Linq;                  // Where(), Select(), ToList()
using System.Reflection;            // BindingFlags, MethodInfo

namespace MenuLib
{
    /// <summary>Один пункт меню.</summary>
    public class MenuItem
    {
        // --- Свойства класса MenuItem ---
        public int Level { get; }       // уровень вложенности (0–корень, 1–дочерний и т.п.)
        public string Title { get; }    // текст, который показывается в меню
        public string Handler { get; }  // имя метода-обработчика (null/empty → есть подпункты)

        // --- Конструктор MenuItem(level, title, handler) ---
        public MenuItem(int level, string title, string handler)
        {
            Level = level;
            Title = title;
            Handler = handler;
        }
    }

    public class DataDrivenMenu
    {
        // Список всех пунктов меню в порядке чтения из файла.
        public List<MenuItem> Items { get; private set; }

        public DataDrivenMenu(string path = "menu.txt")
        {

            Items = File.ReadAllLines(path)
                        .Where(l => !string.IsNullOrWhiteSpace(l)
                                 && !l.TrimStart().StartsWith("#"))
                        .Select(Parse)
                        .ToList();
        }

        //Превращает одну строку из файла в объект MenuItem.
        private static MenuItem Parse(string line)
        {

            var parts = line.Split(new[] { ' ' }, 3,
                                   StringSplitOptions.RemoveEmptyEntries);

            // Если получено менее 2 частей — строка некорректна.
            if (parts.Length < 2)
                throw new FormatException("Некорректная строка меню: " + line);

            // 1) Парсим уровень из текста в int.
            int level = int.Parse(parts[0]);
            // 2) Второй токен — заголовок пункта.
            string title = parts[1];
            // 3) Если есть третья часть — это имя обработчика, иначе null
            string handler = parts.Length == 3 ? parts[2] : null;

            // Создаём и возвращаем новую запись меню.
            return new MenuItem(level, title, handler);
        }

        public IEnumerable<MenuItem> ChildrenOf(MenuItem parent)
        {
            // Найдём индекс parent в списке.
            int index = Items.IndexOf(parent);
            if (index < 0)
                yield break;   // Если не нашли — не возвращаем ничего.

            int parentLevel = parent.Level;
            // Идём по списку от следующей позиции, пока уровень > уровня parent.
            for (int i = index + 1; i < Items.Count && Items[i].Level > parentLevel; i++)
            {
                // Если уровень = parentLevel + 1 — это непосредственный потомок.
                if (Items[i].Level == parentLevel + 1)
                    yield return Items[i];
            }
        }

        public void Invoke(MenuItem item, object target)
        {
            // Если Handler пустой или null — ничего не делаем.
            if (string.IsNullOrEmpty(item.Handler))
                return;

            // Получаем объект System.Reflection.MethodInfo для имени метода.
            var method = target.GetType()
                               .GetMethod(item.Handler,
                                          BindingFlags.Instance    // Ищем среди методов экземпляра.
                                        | BindingFlags.Public      // Как публичные.
                                        | BindingFlags.NonPublic); // Так и приватные.

            if (method == null)
                throw new MissingMethodException("Метод не найден: " + item.Handler);

            method.Invoke(target, null);
        }
    }
}
