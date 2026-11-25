namespace FantasyArena.Core;

public class Weapon
{
    public string Name { get; }
    public int DamageBonus { get; }

    public Weapon(string name, int damageBonus)
    {
        Name = name;
        DamageBonus = Math.Max(0, damageBonus);
    }

    public int CalculateDamage(int baseDamage)
    {
        return baseDamage + DamageBonus;
    }
}