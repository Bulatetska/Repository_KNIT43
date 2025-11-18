using Microsoft.AspNetCore.Mvc;
using MvcStoreLab.Filters; // Використовуємо наш кастомний атрибут
using MvcStoreLab.Models;

namespace MvcStoreLab.Controllers
{
    // Застосовуємо фільтр авторизації та кастомний атрибут дії
    [AuthorizeUser("Admin")] // Припускаємо, що "Admin" - роль адміністратора
    [LogAction] // Наш кастомний атрибут
    public class AdminController : Controller
    {
        // Управління Продуктами
        public IActionResult ManageProducts()
        {
            var products = DataStore.Products;
            return View(products);
        }

        // Управління Користувачами
        public IActionResult ManageUsers()
        {
            var users = DataStore.Users;
            return View(users);
        }
    }
}