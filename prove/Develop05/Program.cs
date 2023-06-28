using System;
//Store user point total for save/load
class Program
{
    static void Main(string[] args)
    {
        // var goals = new List<Goal>();
        bool keepLoop = true;
        // var shopItems = new List<Goal>();
        var goalMenu = new GoalMenu();
        var shopMenu = new ShopMenu();

        while(keepLoop)
        {
            string userInputString = goalMenu.MenuMain();
            switch(userInputString)
            {
                case("Points Shop"):
                    //Points shop
                    shopMenu.MenuMain(goalMenu.GetTotalPoints());
                    break;
                
                case("Save"):
                
                    //Save
                    Save(goalMenu, shopMenu);
                    break;
                
                case("Load"):
                    //Load
                    Load(goalMenu, shopMenu);
                    break;

                case("Quit"):
                    //Quit
                    keepLoop = false;
                    break;
            }
        }
    }
    static void Save(GoalMenu goalMenu, ShopMenu shopMenu)
    {
        var dataList = goalMenu.GetItemData().Concat(shopMenu.GetItemData()).ToList();
        
        Console.Write("What file do you want to save to or type \"back\" to return to the menu. ");
        string filename = Console.ReadLine();

        if(filename.ToLower() == "back")
        {
            return;
        }
        using(StreamWriter writer = new StreamWriter(filename))
        foreach(var data in dataList)
        {
            writer.WriteLine(data);
        }
    }

    static void Load(GoalMenu goalMenu, ShopMenu shopMenu)
    {
        Console.Write("What file do you want to Load or type \"back\" to return to the menu? ");
        string filename = Console.ReadLine();
        if(filename.ToLower() == "back")
        {
            return;
        }

        var goals = new List<Goal>();
        var shopItems = new List<Goal>();

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(";");

            switch(parts[0])
            {
                
                case("Simple"):
                    Simple simpleGoal = new Simple(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                    goals.Add(simpleGoal);
                    break;
                
                case("Eternal"):
                    Eternal eternalGoal = new Eternal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));
                    goals.Add(eternalGoal);
                    break;
                
                case("Checklist"):
                    Checklist checklistGoal = new Checklist(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                    goals.Add(checklistGoal);    
                    break;
                
                case("RewardStock"):
                    RewardStock stockReward = new RewardStock(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                    shopItems.Add(stockReward);
                    break;
                
                case("EternalReward"):
                    var eternalReward = new EternalReward(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]), int.Parse(parts[5]));
                    shopItems.Add(eternalReward);
                    break;
                
                case("MilestoneReward"):
                    var milestoneReward = new MilestoneReward(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]), int.Parse(parts[5]));
                    shopItems.Add(milestoneReward);
                    break;
            }

            goalMenu.SetItems(goals);
            shopMenu.SetItems(shopItems);
        }
    }
}