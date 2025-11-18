using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class OrderController : Controller
    {
        private static List<Order> Orders { get; set; } = new List<Order>();

        [HttpGet]
        public IActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            order.Id = Orders.Count + 1;
            Orders.Add(order);
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            return View(Orders);
        }
        public static List<Order> GetOrders()
        {
            return Orders; // Orders — статичний список замовлень
        }

    }
}
