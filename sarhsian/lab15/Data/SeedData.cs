using Lab15MvcApp.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab15MvcApp.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext db, IPasswordHasher<AppUser> hasher)
    {
        if (!db.Products.Any())
        {
            db.Products.AddRange(
                new Product { Name = "Ноутбук Acer Nitro V 15", Price = 42000m,
                    Stock = 5, Description = "Intel Core i5, оперативна пам'ять 16 ГБ" },
                new Product { Name = "Смартфон Samsung Galaxy A55", Price = 17000m,
                    Stock = 12, Description = "Android, акумулятор 5000 мА·год" },
                new Product { Name = "Навушники SoundBeat", Price = 1600m,
                    Stock = 20, Description = "Бездротові навушники" });
        }

        // Локальний навчальний обліковий запис, НЕ для реального сайту.
        if (!db.Users.Any(x => x.Email == "admin@lab.local"))
        {
            var admin = new AppUser
            {
                Name = "Адміністратор", Email = "admin@lab.local", Role = "Admin"
            };
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");
            db.Users.Add(admin);
        }
        db.SaveChanges();
    }
}
