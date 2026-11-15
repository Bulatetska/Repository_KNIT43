using System.Security.Claims;
using Lab15MvcApp.Data;
using Lab15MvcApp.Models;
using Lab15MvcApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab15MvcApp.Controllers;

[Authorize]
[Route("orders")]
public class OrderController(AppDbContext db) : Controller
{
    [HttpGet("place")]
    public IActionResult PlaceOrder(int? productId = null)
    {
        FillProducts();
        return View(new OrderFormModel { ProductId = productId ?? 0 });
    }

    [HttpPost("place")]
    [ValidateAntiForgeryToken]
    public IActionResult PlaceOrder(OrderFormModel input)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == input.ProductId);
        if (product is null) ModelState.AddModelError(nameof(input.ProductId), "Товар не знайдено.");
        else if (product.Stock < input.Quantity)
            ModelState.AddModelError(nameof(input.Quantity), "Недостатньо товару на складі.");

        if (!ModelState.IsValid)
        {
            FillProducts();
            return View(input);
        }

        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        product!.Stock -= input.Quantity;
        var order = new PurchaseOrder
        {
            ProductId = product.Id, UserId = userId, Quantity = input.Quantity,
            UnitPrice = product.Price, TotalPrice = product.Price * input.Quantity,
            CreatedUtc = DateTime.UtcNow
        };
        db.Orders.Add(order);
        db.SaveChanges();
        return RedirectToAction(nameof(Details), new { id = order.Id });
    }

    [HttpGet("my")]
    public IActionResult MyOrders()
    {
        int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var orders = db.Orders.AsNoTracking().Include(o => o.Product)
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.Id).ToList();
        return View(orders);
    }

    [HttpGet("{id:int}")]
    public IActionResult Details(int id)
    {
        var order = db.Orders.AsNoTracking().Include(o => o.Product)
            .FirstOrDefault(o => o.Id == id);
        if (order is null) return NotFound();
        if (!User.IsInRole("Admin") &&
            User.FindFirstValue(ClaimTypes.NameIdentifier) != order.UserId.ToString())
            return Forbid();
        return View(order);
    }

    private void FillProducts()
    {
        var products = db.Products.AsNoTracking().Where(p => p.Stock > 0)
            .OrderBy(p => p.Name).ToList();
        ViewBag.Products = new SelectList(products, "Id", "Name");
    }
}
