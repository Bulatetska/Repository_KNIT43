using Microsoft.AspNetCore.Mvc;
using MvcLab.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

// Кастомний маршрут з "прихованими" параметрами
app.MapControllerRoute(
    name: "product_slug",
    pattern: "catalog/{id:int}/{slug?}",
    defaults: new { controller = "Product", action = "Details" }
);

// Стандартний маршрут
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
