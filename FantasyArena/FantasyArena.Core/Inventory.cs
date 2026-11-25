namespace FantasyArena.Core;

public class Inventory
{
    private readonly List<Weapon> _weapons = new();

    public Weapon? EquippedWeapon { get; private set; }

    public void AddWeapon(Weapon weapon)
    {
        _weapons.Add(weapon);
    }

    public bool EquipWeapon(string name)
    {
        Weapon? weapon = _weapons.Find(w =>
            string.Equals(
                w.Name,
                name,
                StringComparison.OrdinalIgnoreCase));

        if (weapon == null)
            return false;

        EquippedWeapon = weapon;
        return true;
    }

    public int GetDamageBonus()
    {
        return EquippedWeapon?.DamageBonus ?? 0;
    }
}