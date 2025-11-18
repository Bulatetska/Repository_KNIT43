var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// Program.cs
// ...
app.UseRouting();

// Маршрут для Product/Edit з читабельним URL (використовує Name як частину URL)
// Хоча це не зовсім "прихований" параметр, але робить URL читабельним і використовує 
// параметр Name. Для справжніх прихованих параметрів краще використовувати Query String або Session.
// У цьому прикладі 'friendly-edit' є статичною частиною, а {name} - параметром.
app.MapControllerRoute(
    name: "product_edit_friendly",
    pattern: "products/edit/{id:int}/{name?}", // {name?} - робимо його опціональним
    defaults: new { controller = "Product", action = "Edit" });

// Маршрут для UserController/Details з читабельним URL
app.MapControllerRoute(
    name: "user_details",
    pattern: "users/profile/{id:int}",
    defaults: new { controller = "User", action = "Details" });

// Стандартний маршрут (завжди останній)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
