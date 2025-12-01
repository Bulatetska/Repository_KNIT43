using Microsoft.AspNetCore.Mvc;
using MvcLab.Filters;
using MvcLab.Models;

namespace MvcLab.Controllers
{
    [Auth] // фільтр авторизації – сюди тільки адмін
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            return View(UserController.Users);
        }

        public IActionResult ManageProducts()
        {
            return View(ProductController.Products);
        }
    }
}
