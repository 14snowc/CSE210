class BreathingActivity: Activity
{
    private bool _isBreathIn;
    private int _breathInTime;
    private int _breathOutTime;

    public BreathingActivity()
    {
        _isBreathIn = true;
        _breathInTime = 5;
        _breathOutTime = 4;
        _name = "Breathing activity";
        _discription = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void breathMain()
    {
        begingPrompt();
        showTimer(5);
        var endTime = DateTime.Now.AddSeconds(_seconds);
        while(DateTime.Now < endTime)
        {
            breathAlternate();
            _isBreathIn = !_isBreathIn;
        }
        endingMessage();
    }

    public void breathAlternate()
    {
        Console.Write("Breath ");
        if(_isBreathIn)
        {
            Console.WriteLine("in...");
            showTimer(_breathInTime);
        }
        else
        {
            Console.WriteLine("out...");
            showTimer(_breathOutTime);
        }
    }

}