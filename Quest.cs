public class Quest
{
    public readonly string Description;
    public readonly int ID;
    public readonly string Name;

    public Quest(int id, string name, string description)
    {
        ID = id;
        Name = name;
        Description = description;
    }

    public void Info()
    {
        Console.WriteLine($"Quest Availabele: {Name}\nDescription {Description}");
    }
}