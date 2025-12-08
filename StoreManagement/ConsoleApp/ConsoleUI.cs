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
            store.AddProduct(new Product("Milk", 30, 10));
            store.AddProduct(new Product("Bread", 25, 5));

            while (true)
            {
                Console.WriteLine("\n1. Показати товари");
                Console.WriteLine("2. Придбати товар");
                Console.WriteLine("3. Показати корзину");
                Console.WriteLine("0. Вихід");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1": ShowProducts(); break;
                    case "2": BuyProduct(); break;
                    case "3": ShowCart(); break;
                    case "0": return;
                }
            }
        }

        private void ShowProducts()
        {
            Console.WriteLine("\n--- Товари ---");
            foreach (var p in store.Products)
                Console.WriteLine($"{p.Name}: {p.Price} грн ({p.Quantity} шт)");
        }

        private void BuyProduct()
        {
            Console.Write("\nВведіть назву товару: ");
            string name = Console.ReadLine() ?? "";

            if (store.BuyProduct(customer, name))
                Console.WriteLine("Успішно куплено!");
            else
                Console.WriteLine("Не вдалося купити.");
        }

        private void ShowCart()
        {
            Console.WriteLine("\n--- Корзина ---");
            foreach (var p in customer.Cart)
                Console.WriteLine($"{p.Name}: {p.Price} грн");
        }
    }
}