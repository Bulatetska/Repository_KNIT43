namespace FantasyArena.Core;

public class Archer : Hero
{
    public Archer(string name)
        : base(name, 95, 28, 7)
    {
    }

    public override int Attack(IHero target)
    {
        bool criticalHit = Random.Shared.Next(100) < 25;

        int damage = criticalHit
            ? AttackPower * 2
            : AttackPower;

        return target.TakeDamage(damage);
    }
}