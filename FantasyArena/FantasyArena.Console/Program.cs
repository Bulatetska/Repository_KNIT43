// Хас

using FantasyArena.Core;

IHero hero1 = new Warrior("Daemon");
IHero hero2 = new Mage("Aemond");

BattleArena arena = new();

BattleResult result = arena.StartDuel(hero1, hero2);

System.Console.WriteLine("=== FANTASY ARENA ===\n");

foreach (string log in result.Logs)
{
    System.Console.WriteLine(log);
}

System.Console.WriteLine("\n=== BATTLE RESULT ===");
System.Console.WriteLine($"Winner: {result.Winner}");
System.Console.WriteLine($"Rounds: {result.Rounds}");
System.Console.WriteLine($"Daemon HP: {result.Hero1Health}");
System.Console.WriteLine($"Aemond HP: {result.Hero2Health}");