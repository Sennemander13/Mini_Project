public class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World!");
        
        // World.World();
        Player p1 = new("Senne", 100, 100, null, World.LocationByID(1));
        while (p1.CurrentLocation?.ID != 3)
        {
            Console.WriteLine($"{p1.CurrentLocation?.Name}: {p1.CurrentLocation?.Description}");
            if (p1.CurrentLocation?.QuestAvailableHere != null)
            {
                p1.CurrentLocation.QuestAvailableHere.Info();
                Console.WriteLine("Extra option: accept: accepts quest");
            //choice to accept quest
            }
            Console.WriteLine("Options:\nesc: pause/quit game\nMove: move to other location");
            Console.Write("Choice: ");
            string choice = Console.ReadLine()!.ToLower();
            if (choice == "move")
            {
                p1.CurrentLocation?.Info();
                Console.Write("Cardinal: ");
                string move = Console.ReadLine()!.ToLower();
                p1.MoveTo(move);
            }
        }
        
        

    }
}