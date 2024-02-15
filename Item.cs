public class Item
{
    public readonly int ID;
    public readonly string Name;
    public readonly int Value;
    public readonly int Cost;
    public readonly bool SellAble;
    public Item(int id, string name, int value, bool sellable)
    {
        ID = id;
        Name = name;
        Value = value;
        SellAble = sellable;
        Cost = value*2;
    }
}