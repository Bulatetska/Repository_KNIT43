namespace FantasyArena.Core;

public abstract class Hero : IHero
{
    public string Name { get; }
    public int Health { get; private set; }
    public int MaxHealth { get; }
    public int AttackPower { get; }
    public int Defense { get; }

    public Inventory Inventory { get; } = new();

    public bool IsAlive => Health > 0;

    protected Hero(string name, int health,
        int attackPower, int defense)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
        AttackPower = attackPower;
        Defense = defense;
    }

    protected int GetAttackDamage()
    {
        return Inventory.EquippedWeapon?
            .CalculateDamage(AttackPower) ?? AttackPower;
    }

    public abstract int Attack(IHero target);

    public virtual int TakeDamage(int damage)
    {
        int actualDamage = Math.Min(
            Health, Math.Max(1, damage - Defense));

        Health -= actualDamage;

        return actualDamage;
    }
}