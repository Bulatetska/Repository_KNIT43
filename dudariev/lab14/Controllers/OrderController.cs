using lab14.Data;
using lab14.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace lab14.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var orders = await _context.Orders
                .Include(x => x.Product)
                .Where(x => x.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
            return View(orders);
        }

        [Authorize]
        public async Task<IActionResult> PlaceOrder(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(new PlaceOrderViewModel { Product = product, Count = 1 });
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("PlaceOrder")]
        public async Task<IActionResult> PlaceOrderPost([ModelBinder(Name = "Product.Id")] int productId, [Range(1, 1000)] int count)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(new PlaceOrderViewModel { Product = product, Count = count });
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            _context.Add(new Order { UserId = userId, ProductId = productId, Count = count });
            await _context.SaveChangesAsync();

            return RedirectToAction("List");
        }
    }
}
