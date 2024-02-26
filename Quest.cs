public class Quest
{
    public readonly string Description;
    public readonly int ID;
    public readonly string Name;
    public Npc? Npc;
    public Item? Reward;
    public int doing = 0;

    public Quest(int id, string name, string description, Item? reward, Npc? npc)
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
        Location questLocation = World.LocationByID(p1.CurrentLocation!.ID + 1!)!;
        if (doing == 0)
        {
            Console.WriteLine($"Name: {Npc?.Name}, {Npc?.Description}\n{Npc?.Story}");
            Console.WriteLine("You have accepted their quest");
            Console.Write("press enter");
            Console.ReadLine();
            doing++;
        }
        else if (questLocation != null && questLocation.MonsterLivingHere.Count != 0)
        {
            Console.WriteLine($"You already have accepted {Name} \nfrom {Npc?.Name}");
            Console.Write("press enter");
            Console.ReadLine();
        }
        if (questLocation != null && questLocation.MonsterLivingHere.Count == 0)
        {
            if (Reward != null)
            {
                Console.WriteLine($"Quest Completed here is your reward: {Reward.Name}");
                p1.itemInventory.Add(Reward);
            }
            p1.CurrentLocation.QuestAvailableHere = null;
            Console.Write("press enter");
            Console.ReadLine();
        }
    }

}