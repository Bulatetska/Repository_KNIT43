using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using ProductApp.Filters;
namespace ProductApp.Controllers
{
    [RequireAuthentication]
    [RequireRole("Admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("users")]
        public IActionResult Users()
        {
            return View();
        }

        public IActionResult ManageUsers()
        {
            return View();
        }

        public IActionResult ManageProducts()
        {
            return View();
        }
    }
}
