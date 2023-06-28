class Goal
{
    protected string _name;
    protected string _discription;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string discription, int points)
    {
        _name = name;
        _discription = discription;
        _points = points;
        _isComplete = false;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }

    public string GetDiscription()
    {
        return _discription;
    }

    public virtual int EarnPoints()
    {
        if(_isComplete)
        {
            return _points;
        }
        else
        {
            return 0;
        }
    }
    public virtual void Buy(int points)
    {

    }
    public virtual void Display()
    {
        Console.Write("[");
        if(_isComplete){
            Console.Write("X");
        }
        else{
            Console.Write(" ");
        }
        Console.WriteLine($"] {_name} ({_discription}): {_points}");
    }
    public bool GetisComplete()
    {
        return _isComplete;
    }
    public virtual void Complete(){
        _isComplete = !_isComplete;
    }
    public virtual string GetData(){
        return $"Simple;{_name};{_discription};{_points};{_isComplete}";
    }
}