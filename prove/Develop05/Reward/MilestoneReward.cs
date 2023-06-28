class MilestoneReward: Goal
{
    //Big reward that you invest small amounts of points into
    private int _investedPoints;
    public MilestoneReward(string name, string discription, int cost): base(name, discription, cost)
    {
        _investedPoints = 0;
    }

    public MilestoneReward(string name, string discription, int cost, bool isComplete, int investedPoints): base(name, discription, cost)
    {
        _isComplete = isComplete;
        _investedPoints = investedPoints;
    }

    public override void Display()
    {
        if(_isComplete)
        {
            return;
        }
        Console.WriteLine($"{_name}: {_points - _investedPoints}({_investedPoints}/{_points})\n -{_discription}\n");
    }
    public override int EarnPoints()
    {
        return -_investedPoints;
    }
    public override void Buy(int totalPoints)
    {
        if(_isComplete)
        {
            return;
        }
        
        bool loop = true;
        int points = 0;
        while(loop)
        { 
            try
            {
                Console.Write($"How many points do you want to invest?(max: {totalPoints}) ");
                points = int.Parse(Console.ReadLine());
                loop = false;
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }
        if(points > totalPoints)
        {
            points = totalPoints;
        }

        _investedPoints += points;
        if(_investedPoints >= _points)
        {
            _investedPoints = _points;
            _isComplete = true;
            Console.WriteLine($"\"Fantastic job, all your hard work earned you {_name}, please take a moment to bask in this accomplishment.\"");
        }
        else
        {
            Console.WriteLine($"\"You now need {_points - _investedPoints} points to get {_name}. You can do it.");
        }
    }
    public override string GetData()
    {
        return $"MilestoneReward;{_name};{_discription};{_points};{_isComplete};{_investedPoints}";
    }
}