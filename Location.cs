public class Location
{
    public int ID;
    public string? Name;
    public string? Description;
    public Quest? QuestAvailableHere;
    public List<Monster> MonsterLivingHere;
    public List<Item> ItemShop;
    public List<Weapon> WeaponShop;
    public Location? LocationToNorth;
    public Location? LocationToEast;
    public Location? LocationToSouth;
    public Location? LocationToWest;
    public Item? itemNecesery;

    public Location(int id, string name, string description, Quest? quest, List<Monster> monster, List<Item> itemList, List<Weapon> weaponList, Item? itemnecesry)
    {
        ID = id;
        Name = name;
        Description = description;
        QuestAvailableHere = quest;
        MonsterLivingHere = monster;
        ItemShop = itemList;
        WeaponShop = weaponList;
        itemNecesery = itemnecesry;
    }

    public void Info()
    {
        string info = "From here you can go:";
        if (LocationToNorth != null){info += $"\nNorth: {LocationToNorth.Name}";}
        if (LocationToEast != null){info += $"\nEast: {LocationToEast.Name}";}
        if (LocationToSouth != null){info += $"\nSouth: {LocationToSouth.Name}";}
        if (LocationToWest != null){info += $"\nWest: {LocationToWest.Name}";}
        // else {info += "Your not supposed to be here";}

        Console.WriteLine(info);
    }

    public void Shop(Player p1)
    {
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine($"Welcome to {Name}");
        string options = "Options: esc: leave";
        options += ItemShop!=null?"\nitems: open item shop":"";
        Console.WriteLine(options);
        string option = Console.ReadLine()!.ToLower();
        while (option != "esc")
        {
            if (option == "items" || option == "i")
            {
                int itemCount = 0;
                foreach (Item item in ItemShop!)
                {
                    Console.WriteLine($"{itemCount}: {item.Name}, Cost = {item.Cost}");
                }
            }
            Console.Write("Do you want to by something? (yes/no): ");
            string yesOrNo = Console.ReadLine()!;
            if (yesOrNo == "yes" || yesOrNo == "y")
            {
                Console.Write("item number: ");
                int number = Convert.ToInt32(Console.ReadLine()!);
                int count = 0;
                if (number <= ItemShop.Count)
                {
                    foreach (Item item in ItemShop)
                    {
                        if(number == count && p1.Gold >= item.Cost)
                        {
                            p1.itemInventory.Add(item);
                            p1.Gold-=item.Cost;
                            ItemShop.Remove(item);
                            count++;
                            break;
                        }
                        else{Console.WriteLine("Not enough Gold");}
                    }
                }
            }
            else if (yesOrNo == "no" || yesOrNo == "n")
            {
                break;
            }


        }
    }
}