class Activity
{
    protected int _seconds;
    protected string _name;
    protected string _discription;
    protected List<string> _animations = new List<string>()
    {
        "-",
        "\\",
        "|",
        "/"
    };
    protected Random _choice = new Random();


    public void showTimer(int duration)
    {
        while(duration > 0)
        {
            Console.Write(duration);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            duration --;
        }
    }

    public void showSpinner(int duration)
    {
        var startTime = DateTime.Now;
        var endTime = startTime.AddSeconds(duration);

        int animationIndex = 0;
        while(DateTime.Now < endTime)
        {
            string frame = _animations[animationIndex];
            Console.Write(frame);

            Thread.Sleep(250);

            Console.Write("\b \b");

            animationIndex ++;
            if(animationIndex >= _animations.Count)
            {
                animationIndex = 0;
            }
        }
    }
    public void begingPrompt()
    {
        Console.WriteLine(_name);
        showSpinner(2);
        Console.WriteLine(_discription);
        showSpinner(6);
        Console.Write("How many seconds do you want: ");
        _seconds = int.Parse(Console.ReadLine());
    }
    public void endingMessage()
    {
        Console.WriteLine("Great job.");
        showSpinner(3);
        Console.WriteLine($"You compleated the {_name} excersise in {_seconds} seconds.");
        showSpinner(7);
    }

    public string ChooseString(List<string> StringGroup, bool Remove = false)
    {
        int GroupIndex = _choice.Next(0, StringGroup.Count);
        string SelectedString = StringGroup[GroupIndex];
        if(Remove)
        {
            StringGroup.Remove(SelectedString);
        }

        return SelectedString;
    }

    
}