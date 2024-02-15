public class Monster
{

    public int CurrentHitPoints;
    public int ID;
    public int MaximumDamage;
    public int MaximumHitPoints;
    public string Name;
    public int Gold;
    public int ExpDrop;
    public Monster(int id, string name, int damage, int currenthp, int maxhp, int gold, int expDrop)
    {
        ID = id;
        Name = name;
        MaximumDamage = damage;
        CurrentHitPoints = currenthp;
        MaximumHitPoints = maxhp;
        Gold = gold;
        ExpDrop = expDrop;
    }
}