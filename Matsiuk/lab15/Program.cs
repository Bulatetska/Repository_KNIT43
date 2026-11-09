using Lab15_MvcStore.Data;
using Lab15_MvcStore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Password hashing
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Authentication
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.Cookie.Name = "Lab15.MvcStore.Auth";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });

// Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Initialize database and seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    db.Database.EnsureCreated();

    var hasher = scope.ServiceProvider
        .GetRequiredService<IPasswordHasher<User>>();

    if (!db.Users.Any(u => u.Email == "admin@store.com"))
    {
        var admin = new User
        {
            FullName = "System Administrator",
            Email = "admin@store.com",
            Role = "Admin"
        };

        admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

        db.Users.Add(admin);
    }

    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new Product
            {
                Name = "Gaming Laptop",
                Description = "High-performance laptop for gaming and work.",
                Price = 1299.99m,
                Stock = 15
            },
            new Product
            {
                Name = "Wireless Headphones",
                Description = "Premium wireless headphones with clear sound.",
                Price = 149.99m,
                Stock = 30
            },
            new Product
            {
                Name = "Mechanical Keyboard",
                Description = "Mechanical keyboard with RGB lighting.",
                Price = 89.99m,
                Stock = 25
            },
            new Product
            {
                Name = "Gaming Mouse",
                Description = "Ergonomic mouse with adjustable sensitivity.",
                Price = 49.99m,
                Stock = 40
            }
        );
    }

    db.SaveChanges();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

// Readable routes
app.MapControllerRoute(
    name: "product-details",
    pattern: "products/{id:int}",
    defaults: new { controller = "Product", action = "Details" });

app.MapControllerRoute(
    name: "product-list",
    pattern: "products",
    defaults: new { controller = "Product", action = "List" });

app.MapControllerRoute(
    name: "user-details",
    pattern: "users/{id:int}",
    defaults: new { controller = "User", action = "Details" });

app.MapControllerRoute(
    name: "order",
    pattern: "orders/place",
    defaults: new { controller = "Order", action = "PlaceOrder" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();