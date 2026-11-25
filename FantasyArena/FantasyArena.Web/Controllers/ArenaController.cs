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
        string[] allowedTypes =
            { "Warrior", "Mage", "Archer" };

        string[] allowedWeapons =
            { "None", "Sword", "Staff", "Bow" };

        if (!allowedTypes.Contains(model.Hero1Type) ||
            !allowedTypes.Contains(model.Hero2Type))
        {
            ModelState.AddModelError("", "Invalid hero type.");
        }

        if (!allowedWeapons.Contains(model.Hero1Weapon) ||
            !allowedWeapons.Contains(model.Hero2Weapon))
        {
            ModelState.AddModelError("", "Invalid weapon.");
        }

        if (!ModelState.IsValid)
            return View(model);

        Hero hero1 = CreateHero(
            model.Hero1Type, model.Hero1Name);

        Hero hero2 = CreateHero(
            model.Hero2Type, model.Hero2Name);

        EquipWeapon(hero1, model.Hero1Weapon);
        EquipWeapon(hero2, model.Hero2Weapon);

        BattleArena arena = new();

        model.Result = arena.StartDuel(hero1, hero2);

        return View(model);
    }

    private Hero CreateHero(string type, string name)
    {
        return type switch
        {
            "Warrior" => new Warrior(name),
            "Mage" => new Mage(name),
            "Archer" => new Archer(name),
            _ => throw new ArgumentException("Unknown hero type")
        };
    }

    private void EquipWeapon(Hero hero, string weaponName)
    {
        Weapon? weapon = weaponName switch
        {
            "Sword" => new Weapon("Sword", 15),
            "Staff" => new Weapon("Staff", 12),
            "Bow" => new Weapon("Bow", 10),
            _ => null
        };

        if (weapon != null)
        {
            hero.Inventory.AddWeapon(weapon);
            hero.Inventory.EquipWeapon(weapon.Name);
        }
    }
}