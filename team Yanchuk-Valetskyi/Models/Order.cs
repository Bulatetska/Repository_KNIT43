using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantSystem.Interfaces;

namespace RestaurantSystem.Models
{
    /// <summary>
    /// Замовлення в ресторані.
    /// </summary>
    public class Order
    {
        private static int _idCounter = 1;

        public int Id { get; }

        public List<IOrderable> Items { get; } = new List<IOrderable>();

        public DateTime CreatedAt { get; }

        public int TableNumber { get; }

        public User Customer { get; }

        public bool IsClosed { get; private set; }

        public Order(User customer, int tableNumber)
        {
            Id = _idCounter++;
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            TableNumber = tableNumber;
            CreatedAt = DateTime.Now;
        }

        public void AddItem(IOrderable item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            Items.Add(item);
        }

        public void RemoveItem(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName)) return;

            var item = Items.FirstOrDefault(i =>
                string.Equals(i.GetName(), itemName, StringComparison.OrdinalIgnoreCase));

            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(i => i.GetPrice());
        }

        public void Close()
        {
            IsClosed = true;
            Customer.AddToHistory(this);
        }

        public string GetOrderDetails()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Замовлення #{Id}");
            sb.AppendLine($"Клієнт: {Customer}");
            sb.AppendLine($"Стіл: {TableNumber}");
            sb.AppendLine($"Час створення: {CreatedAt}");
            sb.AppendLine();
            sb.AppendLine("Позиції:");

            foreach (var item in Items)
            {
                sb.AppendLine($" - {item.GetName()} — {item.GetPrice()} грн");
            }

            sb.AppendLine();
            sb.AppendLine($"Разом: {GetTotalPrice()} грн");
            sb.AppendLine(IsClosed ? "Статус: Закрите" : "Статус: Відкрите");

            return sb.ToString();
        }
    }
}
