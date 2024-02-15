public class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World!");
        
        // World.World();
        Player p1 = new("Senne", 100, 100, null, World.LocationByID(1));
        while (p1.CurrentLocation?.ID != 3)
        {
            Console.WriteLine($"\n{p1.CurrentLocation?.Name}: {p1.CurrentLocation?.Description}");
            if (p1.CurrentLocation?.QuestAvailableHere != null)
            {
                p1.CurrentLocation.QuestAvailableHere.Info();
            }
            Console.WriteLine($"Options:\nesc: pause/quit game\nbag: open bag\nMove: move to other location\n{(p1.CurrentLocation?.QuestAvailableHere!=null?"Extra option: accept: accepts quest":"")}");
            Console.Write("Choice: ");
            string choice = Console.ReadLine()!.ToLower();
            if (choice == "move")
            {
                p1.CurrentLocation?.Info();
                Console.Write("Cardinal: ");
                string move = Console.ReadLine()!.ToLower();
                p1.MoveTo(move);
            }
            else if (choice == "bag")
            {
                Console.WriteLine("Options: items or weapons\nesc: leave bag");
                string wich_inventory = "";
                while (wich_inventory != "esc")
                {
                    wich_inventory = Console.ReadLine()!.ToLower();
                    if (wich_inventory == "items")
                    {
                        foreach (Item item in p1.itemInventory)
                        {
                            Console.WriteLine($"{item.Name}: {item.Value}");
                        }
                    }
                    else if (wich_inventory == "weapons")
                    {
                        foreach (Weapon weapon in p1.weaponInventory)
                        {
                            Console.WriteLine($"{weapon.Name}: {weapon.MaxDamage}");
                        }
                    }
                }
            }

            else if (choice == "accept" && p1.CurrentLocation?.QuestAvailableHere != null)
            {
                p1.CurrentLocation?.QuestAvailableHere?.TalkToNpc(p1);
            }
            else if (choice == "esc")
            {
                break;
            }
        }
        
        

    }
}