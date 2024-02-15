public class Program
{
    static void Main(string[] args)
    {
        Player p1 = new("Senne", 100, 100, 0, World.WeaponByID(1), World.LocationByID(1));
        while (p1.CurrentLocation?.ID != 10)
        {
            Console.WriteLine($"\n{p1.CurrentLocation?.Name}: {p1.CurrentLocation?.Description}");
            if (p1.CurrentLocation?.QuestAvailableHere != null)
            {
                p1.CurrentLocation.QuestAvailableHere.Info();
            }
            string options = $"Options:\nesc: pause/quit game\nbag: open bag\nMove: move to other location\nStats: see player stats";
            options += p1.CurrentLocation?.QuestAvailableHere!=null?"\nTalk: Talk to Person":"";
            options += p1.CurrentLocation?.MonsterLivingHere!=null?$"\nExtra: fight: fight {p1.CurrentLocation?.MonsterLivingHere.Name}":"";
            options += p1.CurrentLocation?.ID == 1 ? "\nExtra : Heal: Heal to full hp":"";
            Console.WriteLine(options);
            Console.Write("Choice: ");
            string choice = Console.ReadLine()!.ToLower();
            if (choice == "move" || choice == "m")
            {
                p1.CurrentLocation?.Info();
                Console.Write("Cardinal: ");
                string move = Console.ReadLine()!.ToLower();
                p1.MoveTo(move);
            }
            else if (choice == "bag")
            {
                p1.Bag();
            }
            else if (p1.CurrentLocation?.ID == 1 && choice == "heal")
            {
                p1.FullHeal();
            }
            else if (choice == "stats")
            {
                p1.stats();
            }
            else if (choice == "talk" || choice == "t" && p1.CurrentLocation?.QuestAvailableHere != null)
            {
                // Console.WriteLine(p1.CurrentLocation?.QuestAvailableHere?.Npc.Name);
                p1.CurrentLocation?.QuestAvailableHere?.TalkToNpc(p1);
            }
            else if (choice == "fight" || choice == "f" && p1.CurrentLocation?.MonsterLivingHere != null)
            {
                Battle battle = new(p1, p1.CurrentLocation.MonsterLivingHere);
                battle.fight();
            }
            else if (choice == "esc")
            {
                break;
            }
        }

    }
}