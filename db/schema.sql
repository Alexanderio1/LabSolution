-- Database schema for DemoApp WinForms sample
CREATE TABLE IF NOT EXISTS roles (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS users (
    id SERIAL PRIMARY KEY,
    username TEXT NOT NULL UNIQUE,
    password_hash TEXT NOT NULL,
    salt TEXT NOT NULL,
    algorithm TEXT NOT NULL DEFAULT 'PBKDF2',
    iterations INTEGER NOT NULL DEFAULT 120000,
    role_id INTEGER NOT NULL REFERENCES roles(id),
    must_change_password BOOLEAN NOT NULL DEFAULT FALSE
);

CREATE TABLE IF NOT EXISTS menu_items (
    id SERIAL PRIMARY KEY,
    parent_id INTEGER REFERENCES menu_items(id) ON DELETE CASCADE,
    caption TEXT NOT NULL,
    dll_name TEXT,
    entry_point TEXT,
    sort_order INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS role_rights (
    role_id INTEGER NOT NULL REFERENCES roles(id) ON DELETE CASCADE,
    menu_item_id INTEGER NOT NULL REFERENCES menu_items(id) ON DELETE CASCADE,
    status SMALLINT NOT NULL DEFAULT 0,
    PRIMARY KEY(role_id, menu_item_id)
);

CREATE TABLE IF NOT EXISTS query_templates (
    id SERIAL PRIMARY KEY,
    title TEXT NOT NULL,
    sql_text TEXT NOT NULL,
    description TEXT
);

CREATE TABLE IF NOT EXISTS suppliers (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    city TEXT,
    phone TEXT
);

CREATE TABLE IF NOT EXISTS customers (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    email TEXT,
    phone TEXT
);

CREATE TABLE IF NOT EXISTS products (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    category TEXT,
    supplier_id INTEGER REFERENCES suppliers(id),
    price NUMERIC(12,2) NOT NULL,
    in_stock INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS sales (
    id SERIAL PRIMARY KEY,
    customer_id INTEGER REFERENCES customers(id),
    sale_date DATE NOT NULL DEFAULT CURRENT_DATE
);

CREATE TABLE IF NOT EXISTS sale_items (
    id SERIAL PRIMARY KEY,
    sale_id INTEGER NOT NULL REFERENCES sales(id) ON DELETE CASCADE,
    product_id INTEGER NOT NULL REFERENCES products(id),
    quantity INTEGER NOT NULL,
    price NUMERIC(12,2) NOT NULL
);

CREATE TABLE IF NOT EXISTS payments (
    id SERIAL PRIMARY KEY,
    sale_id INTEGER REFERENCES sales(id) ON DELETE CASCADE,
    payment_date DATE NOT NULL DEFAULT CURRENT_DATE,
    amount NUMERIC(12,2) NOT NULL
);

CREATE OR REPLACE VIEW v_sales_summary AS
SELECT s.id AS sale_id,
       s.sale_date,
       c.name AS customer,
       SUM(si.quantity * si.price) AS total_amount,
       COALESCE(paid.paid_amount, 0) AS paid_amount,
       SUM(si.quantity * si.price) - COALESCE(paid.paid_amount, 0) AS balance
FROM sales s
JOIN customers c ON c.id = s.customer_id
JOIN sale_items si ON si.sale_id = s.id
LEFT JOIN (
    SELECT sale_id, SUM(amount) AS paid_amount
    FROM payments
    GROUP BY sale_id
) paid ON paid.sale_id = s.id
GROUP BY s.id, s.sale_date, c.name, paid.paid_amount;
