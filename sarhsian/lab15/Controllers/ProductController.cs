using Lab15MvcApp.Data;
using Lab15MvcApp.Filters;
using Lab15MvcApp.Models;
using Lab15MvcApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab15MvcApp.Controllers;

[Route("products")]
public class ProductController(AppDbContext db) : Controller
{
    [HttpGet("")]
    [HttpGet("list")]
    public IActionResult List()
        => View(db.Products.AsNoTracking().OrderBy(p => p.Id).ToList());

    [Authorize(Roles = "Admin")]
    [HttpGet("create")]
    public IActionResult Create() => View(new ProductFormModel());

    [Authorize(Roles = "Admin")]
    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    [ValidateProductData]
    public IActionResult Create(ProductFormModel input)
    {
        if (!ModelState.IsValid) return View(input);

        db.Products.Add(new Product
        {
            Name = input.Name.Trim(), Description = input.Description?.Trim() ?? "",
            Price = input.Price, Stock = input.Stock
        });
        db.SaveChanges();
        TempData["Message"] = "Товар створено.";
        return RedirectToAction(nameof(List));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id:int}/edit")]
    public IActionResult Edit(int id)
    {
        var product = db.Products.Find(id);
        if (product is null) return NotFound();
        return View(new ProductFormModel
        {
            Id = product.Id, Name = product.Name, Description = product.Description,
            Price = product.Price, Stock = product.Stock
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("{id:int}/edit")]
    [ValidateAntiForgeryToken]
    [ValidateProductData]
    public IActionResult Edit(int id, ProductFormModel input)
    {
        if (id != input.Id) return BadRequest();
        if (!ModelState.IsValid) return View(input);

        var product = db.Products.Find(id);
        if (product is null) return NotFound();
        product.Name = input.Name.Trim();
        product.Description = input.Description?.Trim() ?? "";
        product.Price = input.Price;
        product.Stock = input.Stock;
        db.SaveChanges();
        TempData["Message"] = "Товар оновлено.";
        return RedirectToAction(nameof(List));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id:int}/delete")]
    public IActionResult Delete(int id)
    {
        var product = db.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
        return product is null ? NotFound() : View(product);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("{id:int}/delete")]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var product = db.Products.Find(id);
        if (product is null) return NotFound();
        if (db.Orders.Any(o => o.ProductId == id))
        {
            TempData["Error"] = "Не можна видалити товар, на який уже є замовлення.";
            return RedirectToAction(nameof(List));
        }
        db.Products.Remove(product);
        db.SaveChanges();
        TempData["Message"] = "Товар видалено.";
        return RedirectToAction(nameof(List));
    }
}
