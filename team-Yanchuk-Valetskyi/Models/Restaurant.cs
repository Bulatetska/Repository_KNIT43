using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSystem.Models
{
    /// <summary>
    /// Головний клас, що керує рестораном.
    /// </summary>
    public class Restaurant
    {
        public string Name { get; set; }

        public List<Product> Menu { get; } = new List<Product>();

        public List<Order> ActiveOrders { get; } = new List<Order>();

        public List<User> Users { get; } = new List<User>();

        public Restaurant(string name = "YumBox Restaurant")
        {
            Name = name;
        }

        // ---------------- Меню ----------------

        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            Menu.Add(product);
        }

        public Product? FindProduct(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            return Menu.FirstOrDefault(p =>
                string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Product> SearchProductsByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return new List<Product>();

            return Menu
                .Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // ---------------- Користувачі ----------------

        public User RegisterUser(string name, string phone)
        {
            var existing = Users.FirstOrDefault(u =>
                string.Equals(u.Phone, phone, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
                return existing;

            var user = new User(name, phone);
            Users.Add(user);
            return user;
        }

        // ---------------- Замовлення ----------------

        public Order CreateOrder(User user, int tableNumber)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var order = new Order(user, tableNumber);
            ActiveOrders.Add(order);
            return order;
        }

        public void CloseOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));

            order.Close();
            ActiveOrders.Remove(order);
        }

        public List<Order> GetActiveOrders()
        {
            return ActiveOrders.ToList();
        }

        public void ShowMenu()
{
    Console.WriteLine("\n--- Меню ресторану ---");
    foreach (var product in Menu)
    {
        Console.WriteLine(product.GetInfo());
    }
}

    }
}
