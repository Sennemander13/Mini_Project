public class Player
{
    public int CurrentHitPoints;
    public Location? CurrentLocation;
    public Weapon? CurrentWeapon;
    public int MaximumHitPoints;
    public int BaseDamage;
    public string Name;
    public int Gold = 10;
    public int Level = 1;
    public int ExpNeeded = 10;
    public int CurrentExp = 0;

    public List<Item> itemInventory = new List<Item>();
    public List<Weapon> weaponInventory = new();

    public Player(string name, int currenthp, int maxhp, int BaseDamage ,Weapon? weapon, Location? location)
    {
        Name = name;
        CurrentHitPoints = currenthp;
        CurrentLocation = location;
        CurrentWeapon = weapon;
        MaximumHitPoints = maxhp;
    }

    public void MoveTo(string cardinal)
    {
        switch (cardinal)
        {
            case "n":
            case "north":
                Item itemNecesery1 = CurrentLocation!.LocationToNorth!.itemNecesery!;
                if ((itemNecesery1 != null && itemInventory!.Contains(itemNecesery1)) || itemNecesery1 == null)
                {
                    CurrentLocation = CurrentLocation.LocationToNorth;
                }
                else
                {
                    Console.WriteLine("You dont have the key\nPress Enter");
                    Console.ReadLine();
                }
                break;
            case "east":
            case "e":
                Item itemNecesery2 = CurrentLocation!.LocationToEast!.itemNecesery!;
                if ((itemNecesery2 != null && itemInventory!.Contains(itemNecesery2)) || itemNecesery2 == null)
                {
                    CurrentLocation = CurrentLocation.LocationToEast;
                }
                else
                {
                    Console.WriteLine("You dont have the key\nPress Enter");
                    Console.ReadLine();
                }
                break;
            case "s":
            case "south":
                Item itemNecesery3 = CurrentLocation!.LocationToSouth!.itemNecesery!;
                if ((itemNecesery3 != null && itemInventory!.Contains(itemNecesery3)) || itemNecesery3 == null)
                {
                    CurrentLocation = CurrentLocation.LocationToSouth;
                }
                else
                {
                    Console.WriteLine("You dont have the key\nPress Enter");
                    Console.ReadLine();
                }
                break;
            case "west":
            case "w":
                Item itemNecesery4 = CurrentLocation!.LocationToWest!.itemNecesery!;
                if ((itemNecesery4 != null && itemInventory!.Contains(itemNecesery4)) || itemNecesery4 == null)
                {
                    CurrentLocation = CurrentLocation.LocationToWest;
                }
                else
                {
                    Console.WriteLine("You dont have the key\nPress Enter");
                    Console.ReadLine();
                }
                break;
            default:
                Console.WriteLine("Invalid move");
                break;
        }
    }

    public void Respawn()
    {
        Console.WriteLine("You wake up in your house :( try again");
        CurrentLocation = World.LocationByID(1);
        CurrentHitPoints = MaximumHitPoints;
    }

    public void TryLevelUp()
    {
        int originalBaseDamage = BaseDamage;
        int originalMxHP = MaximumHitPoints;
        if (CurrentExp >= ExpNeeded)
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.Write($"Level increased\n{Level}");
            Level++;
            Console.WriteLine($"->{Level}");
            Random rng = new();
            int levelUpPoints = 10;
            Console.WriteLine($"You have {levelUpPoints}\nInvest in BaseDamage or MaxHP");
            // Console.WriteLine("Example: 5,5 will divide it equally");
            int count = 1;
            do
            {
                if (count%2==1)
                {
                    Console.Write($"How many do you want to add to Base Damage ({BaseDamage}): ");
                    int invest1 = Convert.ToInt32(Console.ReadLine()!);
                    if (invest1 > levelUpPoints){Console.WriteLine("Invalid Amount");}
                    else{
                        levelUpPoints-=invest1;
                        BaseDamage += invest1;
                        count++;
                    }
                }
                else {Console.Write($"How many do you want to add to MaxHP ({MaximumHitPoints}): ");
                    int invest2 = Convert.ToInt32(Console.ReadLine()!);
                    if (invest2 > levelUpPoints){Console.WriteLine($"Invalid Amount, Amount left: {levelUpPoints}");}
                    else{
                        levelUpPoints-=invest2;
                        MaximumHitPoints += invest2;
                        count++;
                    }
                }
                
            }while (levelUpPoints != 0);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"You have invested {BaseDamage-originalBaseDamage} in Base Damage ({originalBaseDamage}->{BaseDamage})");
            Console.WriteLine($"You have Invested {MaximumHitPoints-originalMxHP} in MaxHP ({originalMxHP}->{MaximumHitPoints})");
            ExpNeeded = ExpNeeded*2;
            Console.WriteLine($"Exp needed for next level {ExpNeeded}");
            // Console.Write("Press enter");
            // Console.ReadLine();

        }
    }
    public void FullHeal()
    {
        Console.WriteLine($"\nYou have healed {MaximumHitPoints-CurrentHitPoints} From {CurrentHitPoints} -> {MaximumHitPoints}");
        CurrentHitPoints = MaximumHitPoints;
        Console.Write("Press enter");
        Console.ReadLine();
    }

    public void stats()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine($"\nName: {Name} Level: {Level}\nEXP {CurrentExp} out of {ExpNeeded}");
        Console.WriteLine($"Base Damage: {BaseDamage} Max Damage: {BaseDamage + CurrentWeapon.MaxDamage}");
        Console.WriteLine($"Health: {CurrentHitPoints} out of {MaximumHitPoints}");
        Console.WriteLine($"Gold: {Gold} Equiped Weapon: {CurrentWeapon.Name}, DMG: {CurrentWeapon.MaxDamage}");
        Console.Write("Press enter");
        Console.ReadLine();
    }

    public void Bag()
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("Options: items or weapons\nesc: leave bag");
        string wich_inventory = "";
        while (wich_inventory != "esc")
        {
            wich_inventory = Console.ReadLine()!.ToLower();
            if (wich_inventory == "items" || wich_inventory == "i")
            {
                Dictionary<Item,int> individual = new();
                foreach (Item item in itemInventory)
                {
                    if (individual.ContainsKey(item))
                    {
                        individual[item]++;
                    }
                    else 
                    {
                        individual[item] = 1;
                    }
                }

                foreach (Item item1 in individual.Keys)
                {
                    Console.WriteLine($"{item1.Name}, amount: {individual[item1]} worth: {item1.Value*individual[item1]} ({item1.Value})gold");
                }
            }
            else if (wich_inventory == "weapons" || wich_inventory == "w")
            {
                int count = 0;
                foreach (Weapon weapon in weaponInventory)
                {
                    Console.WriteLine($"{count}|{weapon.Name}: {weapon.MaxDamage}");
                    count++;
                }
                Console.WriteLine("Equip weapon? (y/n)");
                string yesOrNo = Console.ReadLine()!.ToLower();
                if (yesOrNo == "n" || yesOrNo == "no")
                {
                    break;
                }
                else if (yesOrNo == "y" || yesOrNo == "yes")
                {
                    Console.WriteLine("Wich Weapon (number):");
                    int index = Convert.ToInt32(Console.ReadLine()!);
                    setWeapon(index);
                    break;
                }
            }
        }
    }

    public void setWeapon(int number)
    {
        //equips weapon out of bag
        Weapon? newWeapon = null;
        Weapon? currentWeapon = CurrentWeapon;

        int count = 0;
        foreach (Weapon weapon in weaponInventory)
        {
            if (count == number)
            {
                newWeapon = weapon;
                break;
            }
            count++;
        }
        weaponInventory.Add(currentWeapon);
        this.CurrentWeapon = newWeapon;
        Console.WriteLine($"new equiped weapon: {CurrentWeapon.Name}");
    }
    public Item? DropRandomOnDeath()
    {
        Random rng = new();
        
        if (itemInventory.Count != 0)
        {
            int randomNumber = rng.Next(0,itemInventory.Count);
            return itemInventory[randomNumber];
        }
        else{
            Console.WriteLine("Nothing Left");
            return null;
        }
    }
}