using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
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
        public IActionResult List()
        {
            return View(products);        
        }

        [HttpGet]
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
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return None;
        }
    }
}
