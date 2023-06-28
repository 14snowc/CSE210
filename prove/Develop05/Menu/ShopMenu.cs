class ShopMenu: MenuBase
{
    private List<string> _actors;
    private List<string> _adjectives;
    private string _shopKeeper;
    public ShopMenu(): base()
    {
        _actors = new List<string>{
            "Goblin",
            "Trickster",
            "Dragon",
            "Human",
            "Elf",
            "Vampire",
            "Dwarf",
            "Wizard",
            "Mimic",
            "Keeper of Time",
            "Owl"
        };
        _adjectives = new List<string>{
            "Goblish",
            "Tricky",
            "Draconic",
            "Humanoid",
            "Elven",
            "Vampiric",
            "Dwarven",
            "Mystical",
            "Awakened",
            "Eternal",
            "Wise",
            "Chaotic"
        };
        _title = "<>Points Shop<>";
        _menuItems = new List<string>{
            "Add an item to the shop",
            "View the shop's wares",
            "Leave"
        };
        _itemTypes = new List<string>{
            "\"Stock - Item that can be purchased a limited amount of times, usually something you want a few of but not too much.\"",
            "\"Eternal - Items taht can be purchased limitlessly, provided you have points...\"",
            "\"Milestone - A high cost item you can invest small amounts of points to get, make it something big.\"",
            "Change your mind about adding an item."
        };
    }

    private void GenerateShopKeeper()
    {
        _shopKeeper = $"{Choose(_adjectives)} {Choose(_actors)}";
    }
    public int GetExtraPoints(int pointsFromGoals)
    {
        return pointsFromGoals - GetTotalPoints();
    }
    public void MenuMain(int pointsFromGoals)
    {

        while(true)
        {
            GenerateShopKeeper();
            ShowTitle();
            Console.WriteLine($"As you wander into the shop you find yourself face to face with a {_shopKeeper},\n \"Welcome to my shop, I sell everything you could ever want but not for useless gold and tarnished silver.\n   I crave points, prove your worthy of my wares.\"\n");
            Console.WriteLine($"\"You currently have {GetExtraPoints(pointsFromGoals)} unspent points.\" ");
            DisplayMenu(_menuItems);

            int userInputInt = InputInt("\n\"What can I do for you?\" ");
            switch(userInputInt)
            {
                case(1):
                    //Create Reward
                    CreateReward();
                    break;
                case(2):
                    //Buy a reward
                    SetItemComplete($"Points: {GetExtraPoints(pointsFromGoals)}\n\"What are you buying?\"(type \"back\" to retrun to menu) ", "\"I'm afraid I dont understand.\"");
                    break;

                case(3):
                    //leave
                    return;
            }
        }
    }
    private void CreateReward()
    {
        while(true)
        {
            ShowTitle();
            Console.WriteLine("\"You wish to add an item to my shop, very well here are the item types I can make\"");
            DisplayMenu(_itemTypes);

            int userInputInt = InputInt("\"So is your choice?\" ");
            if(userInputInt >= 0 & userInputInt <= 2)
            {
                ShowTitle();
                Console.WriteLine($"The {_shopKeeper} begins to stare intently into your eyes.");
                Console.Write("\"What is this item called?\" ");
                string userInputName = Console.ReadLine();

                ShowTitle();
                Console.WriteLine($"\"{userInputName}...Yes that will do.\"");
                Console.Write($"\"How would you discribe {userInputName}?\" ");
                string userInputDiscription = Console.ReadLine();

                ShowTitle();
                Console.WriteLine($"The {_shopKeeper} stares even deeper into your eyes and with a chilling voice says,");
                int userInputIntPoints = InputInt($"\"How much points should {userInputName} cost?\" ");
            
                switch(userInputInt)
                {
                    case(0):
                        //Stock
                        ShowTitle();
                        int userInputIntStock = InputInt($"\"How many {userInputName} should I make?\" ");
                        CreateStockReward(userInputName, userInputDiscription, userInputIntPoints, userInputIntStock);
                        break;

                    case(1):
                        //Eternal
                        CreateEternalReward(userInputName, userInputDiscription, userInputIntPoints);
                        break;
                        
                    case(2):
                        //Milestone
                        CreateMilestoneReward(userInputName, userInputDiscription, userInputIntPoints);
                        break;
                }
                return;
                
            }
            else if(userInputInt == 4)
            {
                return;
            }
        }
    }
    private void CreateStockReward(string name, string discription, int points, int stock)
    {
        var reward = new RewardStock(name, discription, points, stock);
        ShowTitle();
        Console.WriteLine("\"Your new reward will look like this in my shop.\" ");
        reward.Display();
        Console.Write($"\"Do you want to finalize {name}, remember there is no going back...\"(yes/no) ");
        string userInputYN = Console.ReadLine().ToLower();
        if(userInputYN == "yes")
        {
            _itemList.Add(reward);
        }
    }
    private void CreateEternalReward(string name, string discription, int points)
    {
        var reward = new EternalReward(name, discription, points);
        ShowTitle();
        Console.WriteLine("\"Your new reward will look like this in my shop.\" ");
        reward.Display();
        Console.Write($"\"Do you want to finalize {name}, remember there is no going back...\"(yes/no) ");
        string userInputYN = Console.ReadLine().ToLower();
        if(userInputYN == "yes")
        {
            _itemList.Add(reward);
        }
    }
    private void CreateMilestoneReward(string name, string discription, int points)
    {
        var reward = new MilestoneReward(name, discription, points);
        ShowTitle();
        Console.WriteLine("\"Your new reward will look like this in my shop.\" ");
        reward.Display();
        Console.Write($"\"Do you want to finalize {name}, remember there is no going back...\"(yes/no) ");
        string userInputYN = Console.ReadLine().ToLower();
        if(userInputYN == "yes")
        {
            _itemList.Add(reward);
        }
    }


}