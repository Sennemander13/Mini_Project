using System.Collections.Generic;

public class Player
{
    public int CurrentHitPoints;
    public Location? CurrentLocation;
    public Weapon? CurrentWeapon;
    public int MaximumHitPoints;
    public string Name;
    public int Gold = 0;

    public List<Item> itemInventory = new List<Item>();
    public List<Weapon> weaponInventory = new();

    public Player(string name, int currenthp, int maxhp, Weapon? weapon, Location? location)
    {
        Name = name;
        CurrentHitPoints = currenthp;
        CurrentLocation = location;
        CurrentWeapon = weapon;
        MaximumHitPoints = maxhp;
    }

    public void MoveTo(string cardinal)
    {
        switch (cardinal)
        {
            case "n":
            case "north":
                if (CurrentLocation?.LocationToNorth != null)
                {
                    CurrentLocation = CurrentLocation.LocationToNorth;
                }
                break;
            case "east":
            case "e":
                if (CurrentLocation?.LocationToEast != null)
                {
                    CurrentLocation = CurrentLocation.LocationToEast;
                }
                break;
            case "s":
            case "south":
                if (CurrentLocation?.LocationToSouth != null)
                {
                    CurrentLocation = CurrentLocation.LocationToSouth;
                }
                break;
            case "west":
            case "w":
                if (CurrentLocation?.LocationToWest != null)
                {
                    CurrentLocation = CurrentLocation.LocationToWest;
                }
                break;
            default:
                Console.WriteLine("Invalid move");
                break;
        }
    }
}