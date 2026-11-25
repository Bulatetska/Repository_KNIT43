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

        int damage = GetAttackDamage();

        if (criticalHit)
            damage *= 2;

        return target.TakeDamage(damage);
    }
}