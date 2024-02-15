public class Location
{
    public int ID;
    public string? Name;
    public string? Description;
    public Quest? QuestAvailableHere;
    public Monster? MonsterLivingHere;
    public Location? LocationToNorth;
    public Location? LocationToEast;
    public Location? LocationToSouth;
    public Location? LocationToWest;

    public Location(int id, string name, string description, Quest? quest, Monster? monster)
    {
        ID = id;
        Name = name;
        Description = description;
        QuestAvailableHere = quest;
        MonsterLivingHere = monster;
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
}