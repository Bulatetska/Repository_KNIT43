namespace MvcStoreLab.Models
{
    public static class DataStore
    {
        public static List<Product> Products { get; set; } = new List<Product>
        {
            new Product { Id = 1, Name = "Ноутбук", Price = 1200.00M, Description = "Потужний ноутбук для роботи" },
            new Product { Id = 2, Name = "Смартфон", Price = 750.50M, Description = "Остання модель смартфона" },
            new Product { Id = 3, Name = "Монітор", Price = 300.00M, Description = "27-дюймовий 4K монітор" }
        };

        public static List<User> Users { get; set; } = new List<User>
        {
            new User { Id = 1, Username = "admin", Email = "admin@example.com", Password = "securepassword" }
        };

        public static List<Order> Orders { get; set; } = new List<Order>();
    }
}