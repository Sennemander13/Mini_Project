using System.Collections.Generic;

public static class World
{

    public static readonly List<Weapon> Weapons = new List<Weapon>();
    public static readonly List<Monster> Monsters = new List<Monster>();
    public static readonly List<Quest> Quests = new List<Quest>();
    public static readonly List<Location> Locations = new List<Location>();
    public static readonly List<Item> Items = new List<Item>();
    public static readonly List<Npc> Npcs = new List<Npc>();
    public static readonly Random RandomGenerator = new Random();

    public const int NPC_ID_FLY = 1;
    public const int NPC_ID_FARMER = 2;
    public const int NPC_ID_ALCHEMIST = 3;

    public const int ITEM_ID_TEST = 0;
    public const int ITEM_ID_HEALTHPOTION = 1;

    public const int WEAPON_ID_TEST = 0;
    public const int WEAPON_ID_RUSTY_SWORD = 1;
    public const int WEAPON_ID_CLUB = 2;
    public const int WEAPON_ID_SOLARFLARE = 13;

    public const int MONSTER_ID_RAT = 1;
    public const int MONSTER_ID_SNAKE = 2;
    public const int MONSTER_ID_GIANT_SPIDER = 3;

    public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
    public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;
    public const int QUEST_ID_COLLECT_SPIDER_SILK = 3;

    public const int LOCATION_ID_HOME = 1;
    public const int LOCATION_ID_TOWN_SQUARE = 2;
    public const int LOCATION_ID_GUARD_POST = 3;
    public const int LOCATION_ID_ALCHEMIST_HUT = 4;
    public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
    public const int LOCATION_ID_FARMHOUSE = 6;
    public const int LOCATION_ID_FARM_FIELD = 7;
    public const int LOCATION_ID_BRIDGE = 8;
    public const int LOCATION_ID_SPIDER_FIELD = 9;

    public const int LOCATION_ID_SHOP1 = 10;

    static World()
    {
        PopulateItems();
        PopulateNpcs();
        PopulateWeapons();
        PopulateMonsters();
        PopulateQuests();
        PopulateLocations();
        
    }
    public static void PopulateNpcs()
    {
        Npcs.Add(new Npc(NPC_ID_ALCHEMIST,"Alfie the Alchemist", "Part of the shadow wizzard money gang", "These Rats in my garden are snatching my crystals"));
        Npcs.Add(new Npc(NPC_ID_FARMER, "Old Jo", "Old but hard working lady", "Its been a while since there where snakes on these farms\nIm statrting to get worried."));
        Npcs.Add(new Npc(NPC_ID_FLY, "Local fly", "Small and scared little being", "Help, can you please clear the webs for me so that i can live here?"));
    }
    public static void PopulateItems()
    {
        Items.Add(new Item(ITEM_ID_TEST,"TEST",100,false));
        Items.Add(new Item(ITEM_ID_HEALTHPOTION, "Health potion", 5, true));
    }


    public static void PopulateWeapons()
    {
        Weapons.Add(new Weapon(WEAPON_ID_RUSTY_SWORD, "Rusty sword", 5));
        Weapons.Add(new Weapon(WEAPON_ID_CLUB, "Club", 10));
    }

    public static void PopulateMonsters()
    {
        Monster rat = new Monster(MONSTER_ID_RAT, "rat", 2, 15, 15, 5, 10, new List<Item>(){ItemByID(ITEM_ID_HEALTHPOTION),ItemByID(ITEM_ID_TEST)});


        Monster snake = new Monster(MONSTER_ID_SNAKE, "snake", 10, 7, 7, 10, 10, new List<Item>(){ItemByID(ITEM_ID_HEALTHPOTION)});


        Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "giant spider", 3, 10, 10, 25, 15, new List<Item>(){ItemByID(ITEM_ID_HEALTHPOTION),ItemByID(ITEM_ID_TEST)});


        Monsters.Add(rat);
        Monsters.Add(snake);
        Monsters.Add(giantSpider);
    }

    public static void PopulateQuests()
    {
        Quest clearAlchemistGarden =
            new Quest(
                QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                "Clear the alchemist's garden",
                "Kill rats in the alchemist's garden ",
                ItemByID(ITEM_ID_HEALTHPOTION),NpcByID(NPC_ID_ALCHEMIST));//new Npc(NPC_ID_ALCHEMIST,"al","yeet", "story"));



        Quest clearFarmersField =
            new Quest(
                QUEST_ID_CLEAR_FARMERS_FIELD,
                "Clear the farmer's field",
                "Kill snakes in the farmer's field",
                ItemByID(ITEM_ID_HEALTHPOTION),
                NpcByID(NPC_ID_FARMER));


        Quest clearSpidersForest =
            new Quest(
                QUEST_ID_COLLECT_SPIDER_SILK,
                "Collect spider silk",
                "Kill spiders in the spider forest",
                ItemByID(ITEM_ID_HEALTHPOTION),
                NpcByID(NPC_ID_FLY));


        Quests.Add(clearAlchemistGarden);
        Quests.Add(clearFarmersField);
        Quests.Add(clearSpidersForest);
    }

    public static void PopulateLocations()
    {
        // Create each location
        Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.", null, null,null,null);
        Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town square", "You see a fountain.", null, null,null,null);

        Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's hut", "There are many strange plants on the shelves.", null, null,null,null);
        alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

        Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's garden", "Many plants are growing here.", null, null,null,null);
        alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

        Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.", null, null,null,null);
        farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

        Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's field", "You see rows of vegetables growing here.", null, null,null,null);
        farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

        Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here.", null, null,null,null);

        Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.", null, null,null,null);
        bridge.QuestAvailableHere = QuestByID(QUEST_ID_COLLECT_SPIDER_SILK);

        Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.", null, null,null,null);
        spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

        Location shop1 = new Location(LOCATION_ID_SHOP1,"Black Market","Shop to buy mystery items",null,null, new List<Item>(){ItemByID(ITEM_ID_HEALTHPOTION)}, new List<Weapon>(){WeaponByID(WEAPON_ID_CLUB)});

        // Link the locations together
        home.LocationToNorth = townSquare;

        townSquare.LocationToNorth = alchemistHut;
        townSquare.LocationToSouth = home;
        townSquare.LocationToEast = guardPost;
        townSquare.LocationToWest = farmhouse;

        farmhouse.LocationToEast = townSquare;
        farmhouse.LocationToWest = farmersField;

        farmersField.LocationToEast = farmhouse;

        alchemistHut.LocationToSouth = townSquare;
        alchemistHut.LocationToNorth = alchemistsGarden;

        alchemistsGarden.LocationToSouth = alchemistHut;

        guardPost.LocationToEast = bridge;
        guardPost.LocationToWest = townSquare;
        guardPost.LocationToNorth = shop1;

        shop1.LocationToSouth = guardPost;

        bridge.LocationToWest = guardPost;
        bridge.LocationToEast = spiderField;

        spiderField.LocationToWest = bridge;

        // Add the locations to the static list
        Locations.Add(home);
        Locations.Add(townSquare);
        Locations.Add(guardPost);
        Locations.Add(alchemistHut);
        Locations.Add(alchemistsGarden);
        Locations.Add(farmhouse);
        Locations.Add(farmersField);
        Locations.Add(bridge);
        Locations.Add(spiderField);
    }

    public static Location? LocationByID(int id)
    {
        foreach (Location location in Locations)
        {
            if (location.ID == id)
            {
                return location;
            }
        }

        return null;
    }

    public static Weapon? WeaponByID(int id)
    {
        foreach (Weapon item in Weapons)
        {
            if (item.ID == id)
            {
                return item;
            }
        }

        return null;
    }



    public static Monster? MonsterByID(int id)
    {
        foreach (Monster monster in Monsters)
        {
            if (monster.ID == id)
            {
                return monster;
            }
        }

        return null;
    }

    public static Quest? QuestByID(int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.ID == id)
            {
                return quest;
            }
        }

        return null;
    }

    public static Npc? NpcByID(int id)
    {
        foreach (Npc npc in Npcs)
        {
            if (npc.ID == id)
            {
                return npc;
            }
        }
        return null;
    }

    public static Item? ItemByID(int id)
    {
        foreach (Item item in Items)
        {
            if (item.ID == id)
            {
                return item;
            }
        }
        return null;
    }
}