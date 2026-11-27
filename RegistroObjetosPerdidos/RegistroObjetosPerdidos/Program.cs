
using Microsoft.EntityFrameworkCore;
using RegistroObjetosPerdidos.Data;

var builder = WebApplication.CreateBuilder(args);

// Conexion a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No se encontro la cadena de conexion.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString));

// Servicios MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuracion del entorno
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
