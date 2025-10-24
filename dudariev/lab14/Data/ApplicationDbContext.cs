using lab14.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace lab14.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sqlite.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

        public void SetupInitialData()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            var admin = new User { Name = "admin", Password = "password", IsAdmin = true };
            var user = new User { Name = "user", Password = "password", IsAdmin = false };
            Users.Add(admin);
            Users.Add(user);

            var phone = new Product { Title = "Телефон", Description = "Lorem ipsum dolor sit amet", Price = 8000M };
            var pen = new Product { Title = "Ручка", Description = "Lorem ipsum dolor sit amet", Price = 20M };
            var apple = new Product { Title = "Яблуко", Description = "Lorem ipsum dolor sit amet", Price = 10M };
            var rock = new Product { Title = "Камінь", Description = "Lorem ipsum dolor sit amet", Price = 500M };
            Products.Add(phone);
            Products.Add(pen);
            Products.Add(apple);
            Products.Add(rock);

            Orders.Add(new Order { User = user, Product = phone, Count = 1, CreatedAt = DateTime.Now.Subtract(TimeSpan.FromMinutes(238)) });
            Orders.Add(new Order { User = user, Product = pen, Count = 2, CreatedAt = DateTime.Now.Subtract(TimeSpan.FromMinutes(42)) });
            Orders.Add(new Order { User = user, Product = rock, Count = 100, CreatedAt = DateTime.Now.Subtract(TimeSpan.FromMinutes(7)) });

            SaveChanges();
        }
    }
}
