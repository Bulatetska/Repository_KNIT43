using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Models;

namespace MyAspNetCoreApp.Controllers
{
    public class OrderController : Controller
    {
        private static List<Order> orders = new List<Order>();
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m },
            new Product { Id = 2, Name = "Mouse", Price = 29.99m },
            new Product { Id = 3, Name = "Keyboard", Price = 79.99m }
        };

        [HttpGet]
        public IActionResult PlaceOrder()
        {
            ViewBag.Products = products;
            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                order.Id = orders.Count + 1;
                order.OrderDate = DateTime.Now;
                orders.Add(order);
                return RedirectToAction("OrderConfirmation", new { id = order.Id });
            }
            
            ViewBag.Products = products;
            return View(order);
        }

        public IActionResult OrderConfirmation(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();
            
            return View(order);
        }
    }
}