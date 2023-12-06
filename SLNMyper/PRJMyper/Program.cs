using PRJMyper.CapaDatos;
using PRJMyper.CapaNegocio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<TrabajadoresDao>();
builder.Services.AddScoped<Trabajadores_CN>();

builder.Services.AddScoped<UbicacionDAO>();
builder.Services.AddScoped<Ubicacion_CN>();

builder.Services.AddScoped<DocumentoDao>();
builder.Services.AddScoped<Documento_CN>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
