using Microsoft.AspNetCore.Mvc;
using lab14.Models;
using System.Collections.Generic;
using System.Linq;
using lab14.Filters;

namespace lab14.Controllers
{
    [CustomActionFilter]
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Яблуко", Price = 46 },
            new Product { Id = 2, Name = "Іграшка машинка", Price = 250 },
            new Product { Id = 3, Name = "Планшет", Price = 15000 }
        };

        // Список продуктів
        public IActionResult List()
        {
            return View(products);
        }

        // Додати продукт
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;
            products.Add(product);
            return RedirectToAction("List");
        }

        // Редагувати продукт
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            return RedirectToAction("List");
        }

        // Видалити продукт
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                products.Remove(product);

            return RedirectToAction("List");
        }
    }
}
