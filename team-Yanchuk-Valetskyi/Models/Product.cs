using System;
using RestaurantSystem.Interfaces;

namespace RestaurantSystem.Models
{
    /// <summary>
    /// Базовий товар ресторану.
    /// </summary>
    public abstract class Product : IOrderable
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Базова ціна без знижок.
        /// </summary>
        public decimal Price { get; set; }

        public string Category { get; set; } = string.Empty;

        public virtual string GetInfo()
        {
            return $"{Name} ({Category}) — {Price} грн";
        }

        public virtual decimal GetPrice() => Price;

        public virtual string GetName() => Name;
    }
}
