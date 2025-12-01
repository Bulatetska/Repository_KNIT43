using Microsoft.AspNetCore.Mvc;
using MvcLab.Models;
using MvcLab.Filters;

namespace MvcLab.Controllers
{
    [LogAction] // власний атрибут логування
    public class ProductController : Controller
    {
        // Умовна "база даних"
        public static List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Ноутбук", Price = 25000 },
            new Product { Id = 2, Name = "Смартфон", Price = 15000 }
        };

        public IActionResult List()
        {
            return View(Products);
        }

        public IActionResult Details(int id, string? slug)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public IActionResult Create(Product model)
        {
            model.Id = Products.Count == 0 ? 1 : Products.Max(p => p.Id) + 1;
            Products.Add(model);
            return RedirectToAction("List");
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: Edit
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            var p = Products.FirstOrDefault(x => x.Id == model.Id);
            if (p == null) return NotFound();

            p.Name = model.Name;
            p.Price = model.Price;
            return RedirectToAction("List");
        }

        // GET: Delete
        public IActionResult Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: Delete
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            Products.RemoveAll(p => p.Id == id);
            return RedirectToAction("List");
        }
    }
}
