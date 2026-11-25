using FantasyArena.Core;

IHero warrior = new Warrior("Daemon");
IHero mage = new Mage("Aemond");
IHero archer = new Archer("Daeron");

IHero[] heroes = { warrior, mage, archer };

System.Console.WriteLine("=== FANTASY ARENA ===");

foreach (IHero hero in heroes)
{
    System.Console.WriteLine(
        $"{hero.Name} ({hero.GetType().Name}): " +
        $"HP: {hero.Health}, " +
        $"Attack: {hero.AttackPower}, " +
        $"Defense: {hero.Defense}");
}

System.Console.WriteLine("\n=== ATTACK TEST ===");

int damage = warrior.Attack(mage);

System.Console.WriteLine(
    $"{warrior.Name} deals {damage} damage to {mage.Name}");

damage = mage.Attack(warrior);

System.Console.WriteLine(
    $"{mage.Name} deals {damage} damage to {warrior.Name}");

System.Console.WriteLine("\n=== HEALTH AFTER ATTACKS ===");

foreach (IHero hero in heroes)
{
    System.Console.WriteLine($"{hero.Name}: {hero.Health} HP");
}