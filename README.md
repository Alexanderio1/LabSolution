# LabSolution WinForms + PostgreSQL

## Требования окружения
- .NET Framework 4.8.1
- PostgreSQL 14+ (локально или в Docker)
- Npgsql (подтягивается через `nuget restore`)

## Настройка базы данных
1. Создай базу, пользователя и выдай права:
   ```sql
   CREATE DATABASE labsolution;
   CREATE USER lab_user WITH PASSWORD 'your_password';
   GRANT ALL PRIVILEGES ON DATABASE labsolution TO lab_user;
   ```
2. Применяй схему и данные:
   ```bash
   psql -h localhost -U lab_user -d labsolution -f db/schema.sql
   psql -h localhost -U lab_user -d labsolution -f db/seed.sql
   ```
3. В `DemoApp/App.config` пропиши актуальный connection string (логин/пароль не хранятся в репозитории, используй свои значения).

## Сборка и запуск
1. Выполни `nuget restore LabSolution.sln`.
2. Собери solution в конфигурации Debug/Release через Visual Studio или `msbuild LabSolution.sln`.
3. Скопируй собранные DLL модулей в `DemoApp/bin/<Configuration>/Modules/`:
   - `TableBrowserModule.dll`
   - `SqlConsoleModule.dll`
4. Запусти `DemoApp.exe` из той же папки (connection string считывается из `App.config`).

## Учётные записи из сида
- `owner` / `owner123` (PBKDF2, все права)
- `sales` / `sales123`
- `goods` / `goods123`
- `account` / `account123`
- `legacy` / `legacy123` (MD5 совместимость)

## Структура меню и модулей
- Пункты меню, права и модули хранятся в таблицах `menu_items` и `role_rights`.
- Приложение загружает меню динамически и подставляет доступность по ролям.
- Точка входа модуля реализует `AuthLib.IModuleEntry` и возвращает WinForm.

### Модули
- **Таблицы/Справочники** (`TableBrowserModule.dll`): просмотр выбранной таблицы с фильтром, сортировкой и лимитом выборки.
- **SQL-консоль** (`SqlConsoleModule.dll`): выполняет только `SELECT`/`WITH SELECT`; запрещены DML/DDL и многокомандные запросы. Вариант "Запросы ИС" подставляет шаблоны из таблицы `query_templates` и создаёт параметры.

### Авторизация и пароли
- Хэш по умолчанию — PBKDF2 (`Rfc2898DeriveBytes`), хранится соль и количество итераций.
- Поддерживается режим совместимости MD5 (для legacy-пользователя).
- Смена пароля доступна через меню `Account -> ChangePassword` и обновляет хэш в БД.
