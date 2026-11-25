// Хас, Мацюк

namespace FantasyArena.Core;

public class Mage : Hero
{
    public Mage(string name)
        : base(name, 80, 35, 4)
    {
    }

    public override int Attack(IHero target)
    {
        int magicDamage = AttackPower
            + target.Defense / 2;

        return target.TakeDamage(magicDamage);
    }
}