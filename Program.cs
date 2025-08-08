using System.Globalization;
using CarManufacturersMVC.Data;
using Microsoft.EntityFrameworkCore;

var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Инициализация базы данных
// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//     DbInitializer.Initialize(context);
// }

app.UseStaticFiles();

app.MapControllers();
app.MapRazorPages();

app.Run(); 