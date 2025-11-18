using Microsoft.AspNetCore.Mvc;
using MvcStoreLab.Models;
using System.Linq; // Не забуваємо про Linq

namespace MvcStoreLab.Controllers
{
    public class ProductController : Controller
    {
        // 1. Дія List (Відображає список продуктів)
        public IActionResult List()
        {
            var products = DataStore.Products;
            return View(products);
        }

        // 2. Дія Edit (GET - Відображення форми редагування)
        public IActionResult Edit(int id)
        {
            var product = DataStore.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // 2. Дія Edit (POST - Обробка даних форми)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = DataStore.Products.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    existingProduct.Description = product.Description;
                    return RedirectToAction(nameof(List));
                }
                return NotFound();
            }
            return View(product);
        }

        // 3. Дія Delete (GET - Підтвердження видалення)
        public IActionResult Delete(int id)
        {
            var product = DataStore.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); // Використовуємо сторінку підтвердження
        }

        // 3. Дія Delete (POST - Видалення продукту)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var productToRemove = DataStore.Products.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                DataStore.Products.Remove(productToRemove);
                return RedirectToAction(nameof(List));
            }
            return NotFound();
        }
    }
}