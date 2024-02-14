public class Monster
{

    public int CurrentHitPoints;
    public int ID;
    public int MaximumDamage;
    public int MaximumHitPoints;
    public string Name;
    public Monster(int id, string name, int damage, int currenthp, int maxhp)
    {
        ID = id;
        Name = name;
        MaximumDamage = damage;
        CurrentHitPoints = currenthp;
        MaximumHitPoints = maxhp;
    }
}