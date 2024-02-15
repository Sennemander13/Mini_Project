public class Npc
{
    public readonly int ID;
    public readonly string Name;
    public readonly string Description;
    public readonly string Story;
    public Npc(int id, string name, string description, string story)
    {
        ID = id;
        Name = name;
        Description = description;
        Story = story;
    }
}