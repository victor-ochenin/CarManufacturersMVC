### CarManufacturersMVC — краткое описание структуры проекта

Небольшое ASP.NET Core (Razor Pages + API) приложение для управления производителями и автомобилями. Ниже — что за что отвечает.

### Основные файлы
- **`Program.cs`**: точка входа. Регистрирует `Controllers`, `RazorPages`, `DbContext` (EF Core, SQL Server), включает статику (`wwwroot`) и настраивает маршруты.
- **`CarManufacturersMVC.csproj`**: таргет-фреймворк `net9.0`, зависимости `Microsoft.EntityFrameworkCore.*` (SqlServer, Tools, Design).
- **`appsettings.json`**: базовые настройки, включая строку подключения `ConnectionStrings:DefaultConnection`, уровни логирования и `AllowedHosts`.
- **`appsettings.Development.json`**: переопределения для dev-среды (логирование и пр.).

### Папки
- **`Data/`**
  - `ApplicationDbContext.cs`: контекст EF Core с наборами данных.
  - `DbInitializer.cs`: (опционально) инициализация/заполнение БД. Вызов закомментирован в `Program.cs`.
- **`Models/`**
  - `Car.cs`, `Manufacturer.cs`: доменные модели (авто и производители).
- **`Api/`**
  - `CarsController.cs`, `ManufacturersController.cs`: API-контроллеры для CRUD-операций.
  - `Messages.cs`: вспомогательные сообщения/константы для API.
- **`Pages/`** (Razor Pages UI)
  - `Cars/`: страницы `Index`, `Create`, `Edit`, `Delete`, `Details` для автомобилей.
  - `Manufacturers/`: страницы `Index`, `Create`, `Delete` для производителей.
  - `Index.cshtml`: корневая страница приложения.
- **`wwwroot/`** (статические файлы)
  - `css/cyberpunk.css`: стили.
  - `js/context-menu.js`: скрипты.
  - `images/`: изображения (логотип и фото авто; есть подпапка `photo_for_README/`).
- **`Migrations/`**: миграции EF Core и `ApplicationDbContextModelSnapshot.cs`.
- **`Properties/`**
  - `launchSettings.json`: профили запуска для разработки.
- **`bin/`, `obj/`**: артефакты сборки (обычно не коммитятся).

### Примечание
- Для работы с базой проверьте строку подключения в `appsettings.json` (сервер, БД, сертификаты). При необходимости раскомментируйте вызов инициализации БД в `Program.cs`.


