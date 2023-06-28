class MenuBase
{
    protected List<Goal> _itemList;
    protected int _sleepTime = 2000;
    protected List<String> _menuItems;
    protected string _title;
    protected List<string> _itemTypes;


    public MenuBase()
    {
        _itemList = new List<Goal>();
    }

    protected string Choose(List<string> stringList)
    {
        var choice = new Random();
        return stringList[choice.Next(0, stringList.Count() - 1)];
    }
    protected Goal Choose(List<Goal> itemList)
    {
        var choice = new Random();
        return itemList[choice.Next(0, itemList.Count() - 1)];
    }
    protected int InputInt(string message = "")
    {
        try
        {
            Console.Write(message);
            int userInputInt = int.Parse(Console.ReadLine());
            return userInputInt;
        }
        catch(Exception)
        {
            return -1;
        }
    }
    public List<Goal> GetItems()
    {
        return _itemList;
    }
    public void SetItems(List<Goal> itemList)
    {
        _itemList = itemList;
    }
    protected void ShowTitle()
    {
        Console.Clear();
        Console.WriteLine(_title + "\n");
    }
    protected virtual void DisplayMenu(List<string> menuList)
    {
        int lineNumber = 1;
        foreach(var menuItem in menuList)
        {
            Console.WriteLine($"{lineNumber}) {menuItem}");
            lineNumber ++;
        }
    }
    
    protected void SetItemComplete(string message = "", string errorMessage = "Invalid entry.")
    {
        ShowTitle();
        var uncompletedItems = new List<Goal>();
        int lineNumber = 1;
        while(true)
        {    
            foreach(var item in _itemList)
            {
                if(!item.GetisComplete())
                {
                    Console.WriteLine($"{lineNumber}) {item.GetName()}: {item.GetPoints()}");
                    uncompletedItems.Add(item);
                    lineNumber ++;
                }
            }
        
            Console.Write(message);
            string userInputString = Console.ReadLine().ToLower();
            if(userInputString == "back")
            {
                return;
            }
            try
            {
                int userInputIndex = int.Parse(userInputString) - 1;
                var chosenGoal = _itemList[userInputIndex];
                chosenGoal.Complete();
            }
            catch(Exception)
            {
                Console.WriteLine(errorMessage);
            }
        }
    }
    
    protected void GetItemsDisplay()
    {
        foreach(var item in _itemList)
        {
            item.Display();
        }
    }
    public List<string> GetItemData()
    {
        var dataCollection = new List<string>();
        foreach(var item in _itemList)
        {
            dataCollection.Add(item.GetData());
        }
        return dataCollection;
    }
    public int GetTotalPoints()
    {
        int totalPoints = 0;
        foreach(var goal in _itemList)
        {
            totalPoints += goal.EarnPoints();
        }
        return totalPoints;
    }
}