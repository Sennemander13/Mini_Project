public class Program
{
    static void Main(string[] args)
    {        
        string startorquit = "";
        do
        {
            startorquit = Menu();
            if (startorquit == "quit" || startorquit == "q"){return;}
            else if (startorquit == "start" || startorquit == "s"){break;}
        }while(startorquit != "start");

        Player p1 = CreateCharacter();

        while (p1.CurrentLocation?.ID < 100)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"\n{p1.CurrentLocation?.Name}: {p1.CurrentLocation?.Description}");
            if (p1.CurrentLocation?.QuestAvailableHere != null)
            {
                p1.CurrentLocation.QuestAvailableHere.Info();
            }
            string options = $"Options:\nesc: pause/quit game\nbag: open bag\nMove: move to other location\nStats: see player stats";
            options += p1.CurrentLocation?.QuestAvailableHere!=null?"\nTalk: Talk to Person":"";
            options += p1.CurrentLocation?.MonsterLivingHere!=null?$"\n: fight: fight {p1.CurrentLocation?.MonsterLivingHere.Name}":"";
            options += p1.CurrentLocation?.ID == 1 ? "\nHeal: Heal to full hp":"";
            options += p1.CurrentLocation?.ID == 10? "\nShop: enter black marker":"";
            Console.WriteLine(options);
            Console.Write("Choice: ");
            string choice = Console.ReadLine()!.ToLower();

            if (choice == "move" || choice == "m")
            {
                Console.WriteLine("--------------------------------------------------------------------");
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
            else if (choice == "shop" || choice == "s" && p1.CurrentLocation?.ID==10)
            {
                p1.CurrentLocation?.Shop(p1);
            }
            else if (choice == "stats" || choice == "s")
            {
                p1.stats();
            }
            else if (choice == "talk" || choice == "t" && p1.CurrentLocation?.QuestAvailableHere != null)
            {
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

    static string Menu()
    {
        
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("                       Welcome To Craft Mine");
        Console.WriteLine("\n\n         Start                                 Quit");
        Console.Write("\n                         Choice: ");
        return Console.ReadLine()!.ToLower();
        // return startorquit;
    }

    static Player? CreateCharacter()
    {
        //add classes
        Console.Clear();
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("                      Create Character");
        Console.Write("     Name: ");
        string playerName = Console.ReadLine()!;
        // Console.WriteLine();
        int HP = 20;
        Console.Write($"\n     Hp = {HP}");
        int BaseDamage = 5;
        Console.Write($"\n     Base Damage = {BaseDamage}");
        Weapon starterWeapon = World.WeaponByID(1);
        Console.Write($"\n     Starter Weapon = {starterWeapon.Name}");
        Location starterLocation = World.LocationByID(1);
        Console.Write($"\n     Starter Location = {starterLocation.Name}");

        
        Console.Write("\nPress Enter");
        Console.ReadLine();
        return new Player(playerName,HP,HP,BaseDamage,starterWeapon,starterLocation);

    }
}