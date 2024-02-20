public class Monster
{

    public int CurrentHitPoints;
    public int ID;
    public int MaximumDamage;
    public int MaximumHitPoints;
    public string Name;
    public int Gold;
    public List<Weapon> Droplist;
    public int ExpDrop;
    public Monster(int id, string name, int damage, int currenthp, int maxhp, int gold, int expDrop, List<Weapon> itemlist)
    {
        ID = id;
        Name = name;
        MaximumDamage = damage;
        CurrentHitPoints = currenthp;
        MaximumHitPoints = maxhp;
        Gold = gold;
        ExpDrop = expDrop;
        Droplist = itemlist;
    }

    public Weapon? DropRandomOnDeath()
    {
        Random rng = new();
        
        if (Droplist.Count != 0)
        {
            int randomNumber = rng.Next(0,Droplist.Count);
            return Droplist[randomNumber];
        }
        else{
            Console.WriteLine("Nothing Left");
            return null;
        }
    }
}