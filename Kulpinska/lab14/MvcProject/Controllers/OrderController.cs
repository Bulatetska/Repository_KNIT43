using Microsoft.AspNetCore.Mvc;
using MvcLab.Models;

namespace MvcLab.Controllers
{
    public class OrderController : Controller
    {
        public static List<Order> Orders = new();

        // GET: PlaceOrder
        public IActionResult PlaceOrder()
        {
            return View();
        }

        // POST: PlaceOrder
        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            order.Id = Orders.Count == 0 ? 1 : Orders.Max(o => o.Id) + 1;
            Orders.Add(order); // умовна "база даних"
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(Orders);
        }
    }
}
