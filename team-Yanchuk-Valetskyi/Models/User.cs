using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSystem.Models
{
    /// <summary>
    /// Клієнт ресторану.
    /// </summary>
    public class User
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public List<Order> History { get; } = new List<Order>();

        public User(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public void AddToHistory(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            History.Add(order);
        }

        /// <summary>
        /// Повертає останні N замовлень (за замовчуванням 5).
        /// </summary>
        public List<Order> GetLastOrders(int count = 5)
        {
            return History
                .OrderByDescending(o => o.CreatedAt)
                .Take(count)
                .ToList();
        }

        public override string ToString()
        {
            return $"{Name} ({Phone})";
        }
    }
}
