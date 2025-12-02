using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantSystem.Interfaces;

namespace RestaurantSystem.Models
{
    /// <summary>
    /// Страва (піца, паста, салат тощо).
    /// </summary>
    public class Dish : Product, IDiscountable
    {
        /// <summary>
        /// Інгредієнти страви.
        /// </summary>
        public List<string> Ingredients { get; set; } = new List<string>();

        /// <summary>
        /// Вага страви в грамах.
        /// </summary>
        public double Weight { get; set; }

        public override string GetInfo()
        {
            string ingredients = Ingredients.Any()
                ? string.Join(", ", Ingredients)
                : "без опису інгредієнтів";

            return $"{Name} ({Category}) — {Price} грн, {Weight} г. Інгредієнти: {ingredients}";
        }

        /// <summary>
        /// Повертає ціну з урахуванням знижки у відсотках.
        /// </summary>
        public decimal ApplyDiscount(decimal percent)
        {
            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent), "Знижка повинна бути від 0 до 100%.");

            decimal discount = Price * percent / 100m;
            return Price - discount;
        }
    }
}
