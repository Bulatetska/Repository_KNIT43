namespace FantasyArena.Core;

public interface IHero
{
    string Name { get; }
    int Health { get; }
    int AttackPower { get; }
    int Defense { get; }
    bool IsAlive { get; }

    int Attack(IHero target);
    int TakeDamage(int damage);
}