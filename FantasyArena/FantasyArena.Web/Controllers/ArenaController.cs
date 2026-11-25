// Хас, Мацюк

using FantasyArena.Core;
using FantasyArena.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FantasyArena.Web.Controllers;

public class ArenaController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new ArenaViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(ArenaViewModel model)
    {
        string[] allowedTypes = { "Warrior", "Mage", "Archer" };

        if (!allowedTypes.Contains(model.Hero1Type) ||
            !allowedTypes.Contains(model.Hero2Type))
        {
            ModelState.AddModelError("", "Invalid hero type.");
        }

        if (!ModelState.IsValid)
            return View(model);

        IHero hero1 = CreateHero(model.Hero1Type, model.Hero1Name);
        IHero hero2 = CreateHero(model.Hero2Type, model.Hero2Name);

        BattleArena arena = new();

        model.Result = arena.StartDuel(hero1, hero2);

        return View(model);
    }

    private IHero CreateHero(string type, string name)
    {
        return type switch
        {
            "Warrior" => new Warrior(name),
            "Mage" => new Mage(name),
            "Archer" => new Archer(name),
            _ => throw new ArgumentException("Unknown hero type")
        };
    }
}