public class Quest
{
    public readonly string Description;
    public readonly int ID;
    public readonly string Name;
    public Npc Npc;
    public readonly Item Reward;
    public int doing = 0;

    public Quest(int id, string name, string description, Item reward, Npc npc)
    {
        ID = id;
        Name = name;
        Description = description;
        Reward = reward;
        Npc = npc;
    }

    public void Info()
    {
        Console.WriteLine($"Quest Availabele: {Name}\nDescription {Description}");
    }

    public void TalkToNpc(Player p1)
    {
        
        if (World.LocationByID(p1.CurrentLocation.ID+1).MonsterLivingHere == null)
        {
            Console.WriteLine($"Quest Completed here is your reward -{Reward.Name}");
            p1.itemInventory.Add(Reward);
            Console.Write("press enter");
            Console.ReadLine();
        }
        if (doing == 1)
        {
            Console.WriteLine($"You already have accepted {Name}");
            Console.Write("press enter");
            Console.ReadLine();
        }
        if (doing == 0)
        {
            Console.WriteLine(Npc.Story);
            Console.WriteLine("You have accepted his quest");
            Console.Write("press enter");
            Console.ReadLine();
            doing++;
        }
        
        
    }

}