// Хас

namespace FantasyArena.Core;

public class BattleArena
{
    public BattleResult StartDuel(IHero hero1, IHero hero2)
    {
        BattleResult result = new();

        int round = 0;

        while (hero1.IsAlive && hero2.IsAlive)
        {
            round++;

            result.Logs.Add($"=== Round {round} ===");

            int damage = hero1.Attack(hero2);

            result.Logs.Add(
                $"{hero1.Name} attacks {hero2.Name}: " +
                $"{damage} damage. HP: {hero2.Health}");

            if (!hero2.IsAlive)
                break;

            damage = hero2.Attack(hero1);

            result.Logs.Add(
                $"{hero2.Name} attacks {hero1.Name}: " +
                $"{damage} damage. HP: {hero1.Health}");
        }

        result.Winner = hero1.IsAlive
            ? hero1.Name
            : hero2.Name;

        result.Rounds = round;
        result.Hero1Health = hero1.Health;
        result.Hero2Health = hero2.Health;

        return result;
    }
}