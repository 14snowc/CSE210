
class ListingActivity: Activity
{
    List<string> _prompts = new List<string>{
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are ssome of your personal heros?"
    };
    int _items;

    public ListingActivity()
    {
        _name = "Listing Activiy";
        _discription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _items = 0;
    }

    public void ListingMain()
    {
        begingPrompt();
        
        Console.WriteLine(ChooseString(_prompts));
        showTimer(7);

        var endTime = DateTime.Now.AddSeconds(_seconds);
        while(DateTime.Now < endTime)
        {
            Console.ReadLine();
            _items ++;
        }

        Console.WriteLine($"\nYou wrote {_items} items.");
        showSpinner(2);
        endingMessage();
    }
}