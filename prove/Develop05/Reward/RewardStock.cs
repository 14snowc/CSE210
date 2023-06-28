class RewardStock: Goal
{
    //Type of reward that can be gotten a set amount of times
    private int _stock;
    private int _startingStock;
    public RewardStock(string name, string discription, int cost, int stock): base(name, discription, cost)
    {
        _startingStock = stock;
        _stock = stock;
    }

    public RewardStock(string name, string discription, int cost, bool isComplete, int startingStock, int stock): base(name, discription, cost)
    {
        _isComplete = isComplete;
        _startingStock = startingStock;
        _stock = stock;
    }
    
    public override void Display()
    {
        if(_isComplete)
        {
            return;
        }
        Console.WriteLine($"[{_stock}]{_name}: {_points} points\n -{_discription}\n");
    }
    public override int EarnPoints()
    {
        return (_startingStock - _stock) * -_points;
    }
    public override void Buy(int points)
    {
        if(_isComplete)
        {
            return;
        }
        else if(points < _points)
        {
            Console.WriteLine("\"A thousand pardons, but you don't have the points needed.\"");
            return;
        }
        _stock --;
        Console.WriteLine($"A well earned {_name}, waits for you.");
        if(_stock <= 0)
        {
            _stock = 0;
            _isComplete = true;
            Console.WriteLine($"\"It would appear that that was the last stock I have for {_name}, sorry.\"");
        }
    }
    public override string GetData()
    {
        return $"RewardStock;{_name};{_discription};{_points};{_isComplete};{_startingStock};{_stock}";
    }
}