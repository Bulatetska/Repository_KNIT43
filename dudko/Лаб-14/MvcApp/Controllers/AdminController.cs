using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class AdminController : Controller
    {
        // --- Адмін-панель: головна ---
        public IActionResult Index()
        {
            return View(); // Views/Admin/Index.cshtml
        }

        // --- Список користувачів ---
        public IActionResult Users()
        {
            var users = UserController.GetUsers();
            return View(users); // Views/Admin/Users.cshtml
        }

        public IActionResult DeleteUser(int id)
        {
            var user = UserController.GetUsers().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                UserController.GetUsers().Remove(user);
            }
            return RedirectToAction("Users");
        }

        // --- Список продуктів ---
        public IActionResult Products()
        {
            var products = ProductController.GetProducts();
            return View(products); // Views/Admin/Products.cshtml
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = ProductController.GetProducts().FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                ProductController.GetProducts().Remove(product);
            }
            return RedirectToAction("Products");
        }

        // --- Перегляд замовлень ---
        public IActionResult Orders()
        {
            var orders = OrderController.GetOrders();
            return View(orders); // Views/Admin/Orders.cshtml
        }
    }
}
