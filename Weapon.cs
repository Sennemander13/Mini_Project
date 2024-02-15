public class Weapon
{
    public readonly int ID;
    public int MaxDamage;
    public string Name;

    public Weapon(int id, string name, int maxDamage)
    {
        ID = id;
        MaxDamage = maxDamage;
        Name = name;
    }
}