
class Checklist : Goal
{
    protected int _bonusRequirement;
    protected int _bonusReward;
    protected int _completedCount;

    public Checklist(string name, string discription, int points, int bonusRequirement, int bonusReward): base(name, discription, points)
    {
        _bonusRequirement = bonusRequirement;
        _bonusReward = bonusReward;
        _completedCount = 0;
    }

    public Checklist(string name, string discription, int points, int bonusRequirement, int bonusReward, int completedCount): base(name, discription, points)
    {
        _bonusRequirement = bonusRequirement;
        _bonusReward = bonusReward;
        _completedCount = completedCount;
    }

    public override void Complete()
    {
        if(!_isComplete)
        {
            _completedCount ++;
            if(_completedCount >= _bonusRequirement)
            {
                _isComplete = true;
            }
        }
    }

    public override int EarnPoints()
    {
        int points = _points * _completedCount;
        if(_isComplete)
        {
            points += _bonusReward;
        }
        return points;
    }

    public override void Display()
    {
        Console.Write("[");
        if(_isComplete)
        {
            Console.Write("X");
        }
        else{
            Console.Write($"{_completedCount}/{_bonusRequirement}");
        }
        Console.WriteLine($"] {_name} ({_discription}): {EarnPoints()}");
    }
    public override string GetData()
    {
        return $"Checklist;{_name};{_discription};{_points};{_bonusRequirement};{_bonusReward};{_completedCount}";
    }
}