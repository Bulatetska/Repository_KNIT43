using System;
using RestaurantSystem.Interfaces;

namespace RestaurantSystem.Models
{
    /// <summary>
    /// Напій.
    /// </summary>
    public class Drink : Product, IDiscountable
    {
        /// <summary>
        /// Обʼєм у літрах.
        /// </summary>
        public decimal Volume { get; set; }

        /// <summary>
        /// Чи містить алкоголь.
        /// </summary>
        public bool IsAlcoholic { get; set; }

        public override string GetInfo()
        {
            string alcoholText = IsAlcoholic ? "алкогольний" : "безалкогольний";
            return $"{Name} — {Price} грн, {Volume} л, {alcoholText}";
        }

        public decimal ApplyDiscount(decimal percent)
        {
            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent), "Знижка повинна бути від 0 до 100%.");

            decimal discount = Price * percent / 100m;
            return Price - discount;
        }
    }
}
