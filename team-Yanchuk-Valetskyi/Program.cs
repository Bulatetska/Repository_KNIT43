using System;
using RestaurantSystem.Models;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Створюємо ресторан
        var restaurant = new Restaurant("YumBox");

        // 2. Додаємо меню
        restaurant.AddProduct(new Dish
        {
            Name = "Піцца Маргарита",
            Category = "Піцца",
            Price = 180,
            Weight = 450,
            Ingredients = { "Сир", "Тісто", "Томатний соус", "Базилік" }
        });

        restaurant.AddProduct(new Drink
        {
            Name = "Кола",
            Category = "Напій",
            Price = 30,
            Volume = 0.5m,
            IsAlcoholic = false
        });

        // 3. Реєструємо користувача
        var user = restaurant.RegisterUser("Іван", "0931234567");

        // 4. Створюємо замовлення
        var order = restaurant.CreateOrder(user, tableNumber: 5);

        // 5. Додаємо позиції

var pizza = restaurant.FindProduct("Піцца Маргарита");
if (pizza != null)
{
    order.AddItem(pizza);
}
else
{
    Console.WriteLine("Піцца Маргарита не знайдена в меню!");
}

var cola = restaurant.FindProduct("Кола");
if (cola != null)
{
    order.AddItem(cola);
}
else
{
    Console.WriteLine("Кола не знайдена в меню!");
}


        // 6. Виводимо інформацію про замовлення
        Console.WriteLine(order.GetOrderDetails());

        // 7. Закриваємо замовлення
        restaurant.CloseOrder(order);

        Console.WriteLine("\nЗамовлення закрито!");
        Console.ReadLine();
        restaurant.ShowMenu();

    }
}
