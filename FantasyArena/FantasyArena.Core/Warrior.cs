namespace FantasyArena.Core;

public class Warrior : Hero
{
    public Warrior(string name)
        : base(name, 120, 25, 12)
    {
    }

    public override int Attack(IHero target)
    {
        return target.TakeDamage(AttackPower);
    }
}