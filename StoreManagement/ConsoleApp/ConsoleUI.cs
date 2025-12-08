using StoreManagement.Models;
using System;

namespace StoreManagement.ConsoleApp
{
    public class ConsoleUI
    {
        private Store store = new Store();
        private Customer customer = new Customer("TestUser", 200);

        public void Start()
        {
            AddDefaultProducts();

            while (true)
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine("   МАГАЗИН | Ваш баланс: " + customer.Balance + " грн");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Показати товари");
                Console.WriteLine("2. Придбати товар");
                Console.WriteLine("3. Показати корзину");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ShowProducts(); break;
                    case "2": BuyProduct(); break;
                    case "3": ShowCart(); break;
                    case "0": return;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще.");
                        break;
                }
            }
        }

        private void AddDefaultProducts()
        {
            store.AddProduct(new Product("Milk", 30, 10));
            store.AddProduct(new Product("Bread", 25, 5));
            store.AddProduct(new Product("Eggs", 50, 30));
            store.AddProduct(new Product("Butter", 70, 15));
            store.AddProduct(new Product("Cheese", 120, 8));
            store.AddProduct(new Product("Apples", 40, 20));
            store.AddProduct(new Product("Bananas", 45, 18));
            store.AddProduct(new Product("Tomatoes", 35, 25));
            store.AddProduct(new Product("Potatoes", 20, 40));
            store.AddProduct(new Product("Chicken", 150, 12));
            store.AddProduct(new Product("Sugar", 32, 10));
            store.AddProduct(new Product("Tea", 60, 14));
        }

        private void ShowProducts()
        {
            Console.WriteLine("\n--- Товари ---");
            foreach (var p in store.Products)
                Console.WriteLine($"{p.Name,-12} | {p.Price,3} грн | {p.Quantity} шт");
        }

        private void BuyProduct()
        {
            Console.Write("\nВведіть назву товару: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Назва не може бути порожньою.");
                return;
            }

            if (store.BuyProduct(customer, name))
                Console.WriteLine("Успішно куплено!");
            else
                Console.WriteLine("Не вдалося купити.");
        }

        private void ShowCart()
        {
            Console.WriteLine("\n--- Корзина ---");
            if (customer.Cart.Count == 0)
            {
                Console.WriteLine("Корзина порожня.");
                return;
            }

            foreach (var p in customer.Cart)
                Console.WriteLine($"{p.Name}: {p.Price} грн");
        }
    }
}
