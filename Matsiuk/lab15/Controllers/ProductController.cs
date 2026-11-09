using Lab15_MvcStore.Data;
using Lab15_MvcStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab15_MvcStore.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _db;

    public ProductController(ApplicationDbContext db)
    {
        _db = db;
    }

    [AllowAnonymous]
    public IActionResult List()
    {
        var products = _db.Products
            .OrderBy(p => p.Name)
            .ToList();

        return View(products);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _db.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        return View(product);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _db.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        return View(product);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(product);

        _db.Products.Update(product);

        await _db.SaveChangesAsync();

        TempData["Success"] = "Product updated successfully.";

        return RedirectToAction(nameof(List));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _db.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        return View(product);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _db.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        bool hasOrders = await _db.Orders
            .AnyAsync(o => o.ProductId == id);

        if (hasOrders)
        {
            TempData["Error"] =
                "This product cannot be deleted because it has existing orders.";

            return RedirectToAction(nameof(List));
        }

        _db.Products.Remove(product);

        await _db.SaveChangesAsync();

        TempData["Success"] = "Product deleted successfully.";

        return RedirectToAction(nameof(List));
    }
}