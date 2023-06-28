class EternalReward: Goal
{
    private int _buyCount;
    public EternalReward(string name, string discription, int cost): base(name, discription, cost)
    {
        _points = cost;
        _buyCount = 0;
    }

    public EternalReward(string name, string discription, int cost, bool isComplete, int buyCount): base(name, discription, cost)
    {
        _points = cost;
        _buyCount = buyCount;
        _isComplete = isComplete;
    }

    public override void Display()
    {
        Console.WriteLine($"{_name}: {_points}\n -{_discription}\n");
    }

    public override int EarnPoints()
    {
        return _buyCount * -_points;
    }

    public override void Buy(int points)
    {
        if(points < _points)
        {
            Console.WriteLine("\"You don't have enough points but you could if you complete more quests.\"");
            return;
        }
        _buyCount ++;
        Console.WriteLine($"\"Please enjoy your {_name}.\"");
    }

    public override string GetData()
    {
        return $"EternalReward;{_name};{_discription};{_points};{_isComplete};{_buyCount}";
    }
}