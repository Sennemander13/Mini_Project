public class Battle
{
    public Player? Player;
    public Monster? Monster;
    public  Battle(Player player, Monster monster)
    {
        Player = player;
        Monster = monster;
    }

    public void fight()
    {
        Random rng = new();
        bool hasHealingPotions = false;
        while (Player.CurrentHitPoints > 0 && Monster.CurrentHitPoints > 0)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Item item in Player.itemInventory)
            {
                if (item.ID == 1){hasHealingPotions = true;}
            }
            Console.WriteLine($"                                            {Monster.Name} HP: {Monster.CurrentHitPoints}\n\n\n\n\n\n\n{Player.Name} HP:{Player.CurrentHitPoints}");
            Console.WriteLine($"choices: Fight, run: run away {(hasHealingPotions ? "or Heal": "")}");
            string choice = Console.ReadLine()!.ToLower();
            if (hasHealingPotions && choice == "heal")
            {
                Player.CurrentHitPoints += 10;
                if (Player.CurrentHitPoints > Player.MaximumHitPoints){Player.CurrentHitPoints = Player.MaximumHitPoints;}
                Player.itemInventory.Remove(World.ItemByID(1));
            }
            else if (choice == "fight" || choice == "f")
            {
                int damage = rng.Next((Player.CurrentWeapon.MaxDamage + Player.BaseDamage) - 5, (Player.CurrentWeapon.MaxDamage +Player.BaseDamage));
                Monster.CurrentHitPoints -= damage;
                Console.WriteLine($"You did {damage} damage");
            }
            else if (choice == "run" || choice == "r")
            {
                break;
            }
            int mDamage = rng.Next(Monster.MaximumDamage - 1, Monster.MaximumDamage);
            hasHealingPotions = false;
            Player.CurrentHitPoints -= mDamage;
            Console.WriteLine($"{Monster.Name} did {mDamage} damage");
        }

        if (Player.CurrentHitPoints <= 0)
        {
            // and take a item from its inventory and put it in theirs 
            Item taken = Player.DropRandomOnDeath();
            Console.WriteLine($"\nYou died fighting {Monster.Name}");//\nIt has taken {item}");
            Player.Respawn();
        }
        else if (Monster.CurrentHitPoints <= 0)
        {
            Console.Clear();
            Console.Write($"You Won\nHeal at home\nCurrent hp: {Player.CurrentHitPoints}\nGained {Monster.Gold} gold\n");
            Player.Gold += Monster.Gold;
            Player.CurrentExp += Monster.ExpDrop;
            Item drop = Monster.DropRandomOnDeath();
            Console.WriteLine($"Added {drop.Name} to items inventory");
            Player.itemInventory.Add(drop);
            Player.CurrentLocation.MonsterLivingHere = null;
            Console.WriteLine($"EXP: {Player.CurrentExp}/{Player.ExpNeeded}");
            Player.TryLevelUp();
            // take item from its inventory
        }
        Console.Write("Press enter");
        Console.ReadLine();
    }
}