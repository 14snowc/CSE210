class GoalMenu: MenuBase
{
    private List<string> _motivations;
    public GoalMenu(): base()
    {
        _title = "--Eternal Quest--";
        _menuItems = new List<string>{
            "Start a new quest.",
            "Finish a quest.",
            "Enter the point shop <-- \"Earn your rewards!\"",
            "Save your progress.",
            "Load your progress.",
            "Quit"
        };
        //Use specal characters for goal. *gn = goal name, *gd = goal discription, *gp = goal points
        _motivations = new List<string>{
            "Free *gp points from *gn!",
            "We could check off *gn by \"*gd.\"",
            "Why not start with *gn?"
        };
        _itemTypes = new List<string>{
            "Simple - A quest that can be completed once.",
            "Eternal - A quest that can be completed infinitly.",
            "Checklist - A qust that can be completed a set number of times, gives bonus points after finishing entirly.",
            "Back - Return to the goal menu."
        };
    }   


    private void CreateGoal()
    {
        while(true)
        {
            ShowTitle();
            DisplayMenu(_itemTypes);

            int userInputInt = InputInt("Which goal do you want? ") - 1;
            if(userInputInt >= 0 && userInputInt <= 2)
            {
                ShowTitle();
                Console.Write("What is a good name for your quest? ");
                string userInputName = Console.ReadLine();

                ShowTitle();
                Console.Write($"What is a good discription for {userInputName}? ");
                string userInputDiscription = Console.ReadLine();

                ShowTitle();
                int userInputIntPoints = InputInt($"How many points should {userInputName} be worth? ");

                if(userInputInt == 0)
                {
                    //Simple
                    CreateSimpleGoal(userInputName, userInputDiscription, userInputIntPoints);
                }
                else if(userInputInt == 1)
                {
                    //Eternal
                    CreateEternalGoal(userInputName, userInputDiscription, userInputIntPoints);
                }
                else if(userInputInt == 2)
                {
                    //Checklist
                    CreateChecklist(userInputName, userInputDiscription, userInputIntPoints);
                }
                return;
            }
            else  if(userInputInt == 3)
            {
                //Quit
                return;
            }
        }
    }
    private void CreateSimpleGoal(string name, string discription, int points)
    {
        var goal = new Simple(name, discription, points);
        Console.WriteLine("This is how the simple quest will look:");
        goal.Display();
        Console.Write("Does this look ok to you?(yes/no) ");
        string userInputYN = Console.ReadLine().ToLower();
        if(userInputYN == "yes")
        {
            _itemList.Add(goal);
        }
    }
    private void CreateEternalGoal(string name, string discription, int points)
    {
        var goal = new Eternal(name, discription, points);
        Console.WriteLine("THis is how the eternal quest will look:");
        goal.Display();
        Console.Write("Does this look ok to you?(yes/no) ");
        string userInputYN = Console.ReadLine().ToLower();
        if(userInputYN == "yes")
        {
            _itemList.Add(goal);
        }
    }
    private void CreateChecklist(string name, string discription, int points)
    {
        ShowTitle();
        int userInputIntQuota = InputInt($"How many times should {name} be done before it is finished? ");

        ShowTitle();
        int userInputIntBonus = InputInt($"How many bonus points should {name} be worth after finishing? ");
        
        ShowTitle();
        var goal = new Checklist(name, discription, points, userInputIntQuota, userInputIntBonus);
        Console.Write($"This is how {name} will look like: ");
        goal.Display();
        Console.Write("Does this look ok to you?(yes/no) ");
        
        string userInputYN = Console.ReadLine().ToLower();
        if(userInputYN == "yes")
        {
            _itemList.Add(goal);
        }
    }

    public string MenuMain()
    {
        while(true)
        {
            ShowTitle();
            if(_itemList.Count() > 0)
            {
                ShowMotivation();
            }
            GetItemsDisplay();
            Console.WriteLine($" -Total Points Collected: {GetTotalPoints()}\n");
            DisplayMenu(_menuItems);

            int userInputInt = InputInt("\nWhat is your selection? ") - 1;
            if(userInputInt == 0)
            {
                //Create Goal
                CreateGoal();
            }
            else if(userInputInt == 1)
            {
                //Finish Goal
                SetItemComplete($"\nWhat goal number did you complete, or type \"back\" to return to the menu. ");
            }
            else if(userInputInt == 2)
            {
                //Point Shop
                return "Points Shop";
            }
            else if(userInputInt == 3)
            {
                //Save
                return "Save";
            }
            else if(userInputInt == 4)
            {
                //Load
                return "Load";
            }
            else if(userInputInt == 5)
            { 
                //Quit
                return "Quit";
            }
            else
            {
                Console.WriteLine("Invalid entry");
                Thread.Sleep(_sleepTime);
            }
        }
    }
    private void ShowMotivation()
    {
        string chosenModivation = Choose(_motivations);
        var chosenGoal = Choose(_itemList);
        chosenModivation = chosenModivation.Replace("*gn", chosenGoal.GetName()).Replace("*gd", chosenGoal.GetDiscription()).Replace("*gp", $"{chosenGoal.GetPoints()}");
        Console.WriteLine(chosenModivation);
    }


}