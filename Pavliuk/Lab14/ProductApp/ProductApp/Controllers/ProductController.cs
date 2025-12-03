//ProductController.cs
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using ProductApp.Filters;

namespace ProductApp.Controllers
{
    [Route("products")]
    [RequireAuthentication]
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product> { 
            new Product {Id = 1, Name = "Bread", Price = 25},
            new Product {Id = 2, Name = "Milk", Price = 35}
        };

        public IActionResult Index()
        {
            return View();
        }
        [LogAction("Product list viewed")]
        [HttpGet("")]
        public IActionResult List()
        {
            return View(products);        
        }

        [HttpGet("edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var product = products.SingleOrDefault(x => x.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            var product = products.SingleOrDefault(x => x.Id == p.Id);
            product.Name = p.Name;
            product.Price = p.Price;
            return RedirectToAction("List");
        }
        [HttpGet("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var product = products.SingleOrDefault(x =>x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost("delete/{id:int}")]
        public IActionResult DeleteConfirm(int id)
        {
            var product = products.SingleOrDefault(x=> x.Id ==id);if (product != null)
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return RedirectToAction("List");
        }
        [HttpGet("{id:int}/{slug?}")]
        public IActionResult Details(int id, string? slug)
        {
            var product = products.SingleOrDefault(x => x.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }
    }
}
