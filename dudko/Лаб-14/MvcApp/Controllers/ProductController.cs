using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> Products { get; set; } = new List<Product>();

        public IActionResult List()
        {
            return View(Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = Products.Count + 1;
            Products.Add(product);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var item = Products.FirstOrDefault(p => p.Id == id);
            if (item != null) Products.Remove(item);

            return RedirectToAction("List");
        }

        public static List<Product> GetProducts()
        {
           return Products; // Products — твій статичний список продуктів
        }

    }
}
