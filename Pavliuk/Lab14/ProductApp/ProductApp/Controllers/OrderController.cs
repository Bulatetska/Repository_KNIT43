using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class OrderController : Controller
    {
        private static List<Order> orders = new List<Order>();
        private static List<Product> products = new List<Product> {
            new Product {Id = 1, Name = "Bread", Price = 25},
            new Product {Id = 2, Name = "Milk", Price = 35}
        };
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PlaceOrder()
        {
            var newOrder = new Order
            {
                Id = orders.Count + 1
            };
            return View(newOrder);
        }
        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            orders.Add(order);
            return View("OrderDetails", order);
        }
        public IActionResult OrderDetails(Order order)
        {
            var o = orders.SingleOrDefault(x => x.Id == order.Id);
            return View(o);
        }
    }
}
