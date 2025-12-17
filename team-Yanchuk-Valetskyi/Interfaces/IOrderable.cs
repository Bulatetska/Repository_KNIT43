using System;

namespace RestaurantSystem.Interfaces
{
    /// <summary>
    /// Будь-який об'єкт, який можна додати в замовлення.
    /// </summary>
    public interface IOrderable
    {
        decimal GetPrice();
        string GetName();
    }
}