using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Data;

namespace TaskManager.Controllers;

public class CategoriesController : Controller
{
    public IActionResult Index()
    {
        var categories = FakeDatabase.Categories;
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            category.Id = FakeDatabase.Categories.Max(c => c.Id) + 1;
            FakeDatabase.Categories.Add(category);
            return RedirectToAction("Index");
        }

        return View(category);
    }

    public IActionResult Edit(int id)
    {
        var category = FakeDatabase.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        var existing = FakeDatabase.Categories.FirstOrDefault(c => c.Id == category.Id);
        if (existing == null) return NotFound();

        existing.Name = category.Name;
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var category = FakeDatabase.Categories.FirstOrDefault(c => c.Id == id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var category = FakeDatabase.Categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            FakeDatabase.Categories.Remove(category);
        }
        return RedirectToAction("Index");
    }
}
