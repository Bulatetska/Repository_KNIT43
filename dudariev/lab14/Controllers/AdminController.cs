using lab14.Data;
using lab14.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab14.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> UserList()
        {
            var users = await _context.Users.ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> UserDelete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("UserDelete")]
        public async Task<IActionResult> UserDeletePost(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("UserList");
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost, ActionName("ProductCreate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreatePost([Bind("Title", "Description", "Price")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _context.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Product");
        }

        public async Task<IActionResult> ProductEdit(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("ProductEdit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEditPost(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(product, "", x => x.Title, x => x.Description, x => x.Price))
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("List", "Product");
            }

            return View(product);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("ProductDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDeletePost(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("List", "Product");
        }
    }
}
