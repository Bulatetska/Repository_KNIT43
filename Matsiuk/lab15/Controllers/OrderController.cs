using System.Security.Claims;
using Lab15_MvcStore.Attributes;
using Lab15_MvcStore.Data;
using Lab15_MvcStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab15_MvcStore.Controllers;

[Authorize]
[RequireStoreAccess]
public class OrderController : Controller
{
    private readonly ApplicationDbContext _db;

    public OrderController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> PlaceOrder()
    {
        await LoadProducts();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PlaceOrder(
        int productId,
        int quantity)
    {
        if (quantity < 1 || quantity > 1000)
        {
            ModelState.AddModelError(
                "",
                "Quantity must be between 1 and 1000.");

            await LoadProducts();
            return View();
        }

        var product = await _db.Products
            .FirstOrDefaultAsync(p => p.Id == productId);

        if (product == null)
        {
            ModelState.AddModelError("", "Product not found.");

            await LoadProducts();
            return View();
        }

        if (product.Stock < quantity)
        {
            ModelState.AddModelError(
                "",
                "Not enough products in stock.");

            await LoadProducts();
            return View();
        }

        var userId = int.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var order = new Order
        {
            UserId = userId,
            ProductId = product.Id,
            Quantity = quantity,
            TotalPrice = product.Price * quantity,
            OrderDate = DateTime.UtcNow
        };

        product.Stock -= quantity;

        _db.Orders.Add(order);

        await _db.SaveChangesAsync();

        TempData["Success"] = "Your order has been placed successfully.";

        return RedirectToAction("Index", "Home");
    }

    private async Task LoadProducts()
    {
        var products = await _db.Products
            .Where(p => p.Stock > 0)
            .OrderBy(p => p.Name)
            .ToListAsync();

        ViewBag.Products = new SelectList(
            products,
            "Id",
            "Name");
    }
}