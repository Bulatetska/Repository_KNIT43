using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
namespace ProductApp.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Create(User user)
        {
            return View("Details", user);
        }
        public IActionResult Details(User user)
        {
            return View(user);
        }
    }
}
