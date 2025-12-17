using System;

namespace RestaurantSystem.Interfaces
{
    /// <summary>
    /// Інтерфейс для об'єктів, на які можна застосувати знижку.
    /// </summary>
    public interface IDiscountable
    {
        /// <summary>
        /// Повертає ціну з урахуванням знижки у відсотках.
        /// </summary>
        decimal ApplyDiscount(decimal percent);
    }
}