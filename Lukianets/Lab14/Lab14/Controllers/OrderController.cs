using Microsoft.AspNetCore.Mvc;
using MvcStoreLab.Models;

namespace MvcStoreLab.Controllers
{
    public class OrderController : Controller
    {
        // 1. Дія PlaceOrder (GET - Відображення форми замовлення)
        // Для спрощення ми просто відображаємо форму
        public IActionResult PlaceOrder()
        {
            ViewBag.AvailableProducts = DataStore.Products;
            return View();
        }

        // Controllers/OrderController.cs

        // ...

        // 1. Дія PlaceOrder (POST - Обробка даних форми)
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Змінюємо тип selectedProducts з string на string[]
        public IActionResult PlaceOrder(string customerName, string[] selectedProducts)
        {
            // Перевіряємо, чи був обраний хоча б один продукт
            if (string.IsNullOrWhiteSpace(customerName) || selectedProducts == null || selectedProducts.Length == 0)
            {
                ModelState.AddModelError("", "Будь ласка, вкажіть ваше ім'я та оберіть хоча б один продукт.");
                ViewBag.AvailableProducts = DataStore.Products;
                return View();
            }

            // --- 🔑 ЛОГІКА КОРЕКТНОГО РОЗРАХУНКУ СУМИ ---

            // selectedProducts вже є масивом назв!
            var selectedProductNames = selectedProducts.ToList(); // Перетворюємо масив на список

            decimal totalAmount = 0;
            var productsInOrder = new List<Product>();

            foreach (var productName in selectedProductNames)
            {
                // Знаходимо продукт у сховищі даних за назвою
                var product = DataStore.Products.FirstOrDefault(p => p.Name == productName);

                if (product != null)
                {
                    totalAmount += product.Price;
                    productsInOrder.Add(product);
                }
            }

            // Перевірка
            if (totalAmount <= 0)
            {
                ModelState.AddModelError("", "Не вдалося знайти обрані продукти або загальна сума дорівнює нулю.");
                ViewBag.AvailableProducts = DataStore.Products;
                return View();
            }

            // ------------------------------------------------

            // Імітація додавання замовлення до "бази даних"
            var newOrder = new Order
            {
                Id = DataStore.Orders.Any() ? DataStore.Orders.Max(o => o.Id) + 1 : 1,
                Username = customerName,
                // Об'єднуємо всі назви у єдиний рядок для зберігання
                ProductNames = string.Join(", ", productsInOrder.Select(p => p.Name)),
                TotalAmount = totalAmount,
                OrderDate = DateTime.Now
            };

            DataStore.Orders.Add(newOrder);

            return RedirectToAction("OrderConfirmation", new { id = newOrder.Id });
        }
        public IActionResult ListOrders()
        {
            // Отримуємо всі замовлення, які були додані до DataStore
            var orders = DataStore.Orders;

            // Передаємо список замовлень до представлення
            return View(orders);
        }

        public IActionResult OrderConfirmation(int id)
        {
            var order = DataStore.Orders.FirstOrDefault(o => o.Id == id);
            return View(order);
        }
    }
}