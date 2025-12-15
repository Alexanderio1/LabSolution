INSERT INTO roles(name) VALUES
    ('Owner'),
    ('SalesManager'),
    ('GoodsSpecialist'),
    ('Accountant')
ON CONFLICT (name) DO NOTHING;

-- Users with PBKDF2 hashes
INSERT INTO users(username, password_hash, salt, algorithm, iterations, role_id)
SELECT 'owner', '/Pnw4d6oz1Q/bXGeIBj7J3ru1T28peqCOpNUvtwdtVM=', 'UlBwySDXVEDvZM4YYQXMPA==', 'PBKDF2', 120000, id FROM roles WHERE name='Owner'
ON CONFLICT (username) DO NOTHING;

INSERT INTO users(username, password_hash, salt, algorithm, iterations, role_id)
SELECT 'sales', 'duxwOwURUeEmf8w2Eg3mt6rx/Wn/4xha3u+T7NwjTWg=', 'PSE8nN8E1ldbsOXMmHZ9QQ==', 'PBKDF2', 120000, id FROM roles WHERE name='SalesManager'
ON CONFLICT (username) DO NOTHING;

INSERT INTO users(username, password_hash, salt, algorithm, iterations, role_id)
SELECT 'goods', 'DEhMNfY1hSvawao9dCv7cXwr+hI7B1RXQqVR8GU9Sf8=', 'WurDniUypT/RWc+LD8H/hA==', 'PBKDF2', 120000, id FROM roles WHERE name='GoodsSpecialist'
ON CONFLICT (username) DO NOTHING;

INSERT INTO users(username, password_hash, salt, algorithm, iterations, role_id)
SELECT 'account', '8OJWXWqdnOptv84g/UIeVCmvqXFTKksv7ez+Pc7Yido=', 'Pr9EuXqo12xeRIsUCh3rIg==', 'PBKDF2', 120000, id FROM roles WHERE name='Accountant'
ON CONFLICT (username) DO NOTHING;

-- Legacy MD5 user for compatibility checks
INSERT INTO users(username, password_hash, salt, algorithm, iterations, role_id)
SELECT 'legacy', 'e8dad0d3667325a30ee1b06391300ab4', 'o3AZX42cvpc=', 'MD5', 1, id FROM roles WHERE name='GoodsSpecialist'
ON CONFLICT (username) DO NOTHING;

-- Menu items and module bindings
TRUNCATE menu_items RESTART IDENTITY CASCADE;
INSERT INTO menu_items(parent_id, caption, dll_name, entry_point, sort_order) VALUES
    (NULL, 'Account', NULL, NULL, 0),
    (1, 'ChangePassword', NULL, NULL, 0),
    (NULL, 'Catalogs', 'TableBrowserModule.dll', 'TableBrowserModule.EntryPoint', 1),
    (NULL, 'SQLConsole', 'SqlConsoleModule.dll', 'SqlConsoleModule.EntryPoint', 2),
    (NULL, 'ISReports', 'SqlConsoleModule.dll', 'SqlConsoleModule.TemplateEntryPoint', 3);

-- Rights: Owner sees everything, others limited
INSERT INTO role_rights(role_id, menu_item_id, status)
SELECT r.id, m.id, 0 FROM roles r CROSS JOIN menu_items m ON CONFLICT DO NOTHING;

-- Sales manager: hide table browser
UPDATE role_rights SET status = 2 WHERE role_id = (SELECT id FROM roles WHERE name='SalesManager') AND menu_item_id = 3;
-- Goods specialist: disable SQL console, allow catalogs
UPDATE role_rights SET status = 1 WHERE role_id = (SELECT id FROM roles WHERE name='GoodsSpecialist') AND menu_item_id = 4;
-- Accountant: hide catalogs
UPDATE role_rights SET status = 2 WHERE role_id = (SELECT id FROM roles WHERE name='Accountant') AND menu_item_id = 3;

-- Sample reference data
INSERT INTO suppliers(name, city, phone) VALUES
 ('Northwind Foods', 'Moscow', '+7 495 000-00-01'),
 ('Fresh Valley', 'Kazan', '+7 843 000-00-02'),
 ('Organic Life', 'Novosibirsk', '+7 383 000-00-03')
ON CONFLICT DO NOTHING;

INSERT INTO customers(name, email, phone) VALUES
 ('ООО Ромашка', 'info@romashka.example', '+7 921 000-00-01'),
 ('ЗАО Мечта', 'sales@mechta.example', '+7 812 000-00-02'),
 ('ИП Петров', 'petrov@example', '+7 911 000-00-03')
ON CONFLICT DO NOTHING;

INSERT INTO products(name, category, supplier_id, price, in_stock) VALUES
 ('Сыр Российский', 'Молочные продукты', 1, 450.00, 120),
 ('Йогурт Клубничный', 'Молочные продукты', 1, 75.00, 300),
 ('Яблоки', 'Фрукты', 2, 60.00, 500),
 ('Груши', 'Фрукты', 2, 80.00, 250),
 ('Киноа', 'Крупы', 3, 210.00, 140)
ON CONFLICT DO NOTHING;

INSERT INTO sales(customer_id, sale_date) VALUES
 (1, CURRENT_DATE - INTERVAL '10 days'),
 (2, CURRENT_DATE - INTERVAL '5 days'),
 (3, CURRENT_DATE - INTERVAL '2 days')
ON CONFLICT DO NOTHING;

INSERT INTO sale_items(sale_id, product_id, quantity, price) VALUES
 (1, 1, 10, 440.00),
 (1, 3, 50, 55.00),
 (2, 2, 40, 72.00),
 (2, 5, 15, 205.00),
 (3, 3, 30, 60.00),
 (3, 4, 20, 78.00)
ON CONFLICT DO NOTHING;

INSERT INTO payments(sale_id, payment_date, amount) VALUES
 (1, CURRENT_DATE - INTERVAL '7 days', 35000.00),
 (2, CURRENT_DATE - INTERVAL '2 days', 8000.00)
ON CONFLICT DO NOTHING;

-- Query templates 1-8
TRUNCATE query_templates RESTART IDENTITY;
INSERT INTO query_templates(title, sql_text, description) VALUES
 ('1. Продажи по периоду',
  'SELECT s.id, s.sale_date, c.name AS customer, SUM(si.quantity * si.price) AS total_amount\nFROM sales s\nJOIN customers c ON c.id = s.customer_id\nJOIN sale_items si ON si.sale_id = s.id\nWHERE s.sale_date BETWEEN @date_from AND @date_to\nGROUP BY s.id, s.sale_date, c.name\nORDER BY s.sale_date;',
  'Сумма продаж за период (параметры date_from, date_to).'),
 ('2. Продажи по покупателю',
  'SELECT s.id, s.sale_date, SUM(si.quantity * si.price) AS total_amount\nFROM sales s\nJOIN sale_items si ON si.sale_id = s.id\nWHERE s.customer_id = @customer_id\nGROUP BY s.id, s.sale_date\nORDER BY s.sale_date;',
  'Продажи выбранного покупателя (customer_id).'),
 ('3. Товары по поставщику',
  'SELECT p.id, p.name, p.category, p.price, p.in_stock\nFROM products p\nWHERE p.supplier_id = @supplier_id\nORDER BY p.name;',
  'Список товаров поставщика (supplier_id).'),
 ('4. Остатки по категории',
  'SELECT category, SUM(in_stock) AS total_left\nFROM products\nWHERE category ILIKE @category||''%''\nGROUP BY category\nORDER BY category;',
  'Остатки по категории (category).'),
 ('5. ТОП клиентов по обороту',
  'SELECT c.name, SUM(si.quantity * si.price) AS turnover\nFROM customers c\nJOIN sales s ON s.customer_id = c.id\nJOIN sale_items si ON si.sale_id = s.id\nWHERE s.sale_date BETWEEN @date_from AND @date_to\nGROUP BY c.name\nORDER BY turnover DESC\nLIMIT @limit;',
  'ТОП клиентов за период (date_from, date_to, limit).'),
 ('6. Просроченные платежи',
  'SELECT v.sale_id, v.sale_date, v.customer, v.balance\nFROM v_sales_summary v\nWHERE v.balance > 0 AND v.sale_date < @due_date\nORDER BY v.sale_date;',
  'Продажи без полной оплаты до due_date.'),
 ('7. Движение товара',
  'SELECT p.name, SUM(si.quantity) AS qty_sold\nFROM sale_items si\nJOIN products p ON p.id = si.product_id\nWHERE si.price > 0 AND EXISTS (SELECT 1 FROM sales s WHERE s.id = si.sale_id AND s.sale_date BETWEEN @date_from AND @date_to)\nGROUP BY p.name\nORDER BY qty_sold DESC;',
  'Количество проданных товаров за период (date_from, date_to).'),
 ('8. Средний чек',
  'SELECT AVG(t.total) AS avg_receipt\nFROM (SELECT s.id, SUM(si.quantity * si.price) AS total FROM sales s JOIN sale_items si ON si.sale_id = s.id WHERE s.sale_date BETWEEN @date_from AND @date_to GROUP BY s.id) t;',
  'Средний чек за период (date_from, date_to).');
