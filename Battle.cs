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
            foreach (Item item in Player.itemInventory)
            {
                if (item.ID == 1){hasHealingPotions = true;}
                else {hasHealingPotions = false;}
            }
            Console.WriteLine($"\n              {Monster.Name} HP: {Monster.CurrentHitPoints}\n\n{Player.Name} HP:{Player.CurrentHitPoints}");
            Console.WriteLine($"choices: Fight, run: run away {(hasHealingPotions ? "or Heal": "")}");
            string choice = Console.ReadLine()!.ToLower();
            if (hasHealingPotions && choice == "heal")
            {
                Player.CurrentHitPoints += 10;
                if (Player.CurrentHitPoints > Player.MaximumHitPoints){Player.CurrentHitPoints = Player.MaximumHitPoints;}
                foreach (Item item in Player.itemInventory)
                {
                    if (item.ID == 1){Player.itemInventory.Remove(item);}
                }
            }
            else if (choice == "fight")
            {
                int damage = rng.Next((Player.CurrentWeapon.MaxDamage + Player.BaseDamage) - 5, (Player.CurrentWeapon.MaxDamage +Player.BaseDamage));
                Monster.CurrentHitPoints -= damage;
                Console.WriteLine($"You did {damage} damage");
            }
            else if (choice == "run")
            {
                break;
            }
            int mDamage = rng.Next(Monster.MaximumDamage - 1, Monster.MaximumDamage);
            Player.CurrentHitPoints -= mDamage;
            Console.WriteLine($"{Monster.Name} did {mDamage} damage");
        }

        if (Player.CurrentHitPoints <= 0)
        {
            // and take a item from its inventory and put it in theirs 
            Console.WriteLine($"\nYou died fighting {Monster.Name}");//\nIt has taken {item}");
            Player.Respawn();
        }
        else if (Monster.CurrentHitPoints <= 0)
        {
            Console.Write($"\nYou Won\nHeal at home\nCurrent hp: {Player.CurrentHitPoints}\nGained {Monster.Gold} gold\n");
            Player.Gold += Monster.Gold;
            Player.CurrentExp += Monster.ExpDrop;
            Player.CurrentLocation.MonsterLivingHere = null;
            Console.WriteLine($"EXP: {Player.CurrentExp}/{Player.ExpNeeded}");
            Player.TryLevelUp();
            // take item from its inventory
        }
        Console.Write("Press enter");
        Console.ReadLine();
    }
}