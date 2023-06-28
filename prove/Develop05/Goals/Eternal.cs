class Eternal : Goal
{
    protected int _completedCount;

    public Eternal(string name, string discription, int points) : base(name, discription, points)
    {
        _completedCount = 0;
    }
    public Eternal(string name, string discription, int points, int completedCount) : base(name, discription, points)
    {
        _completedCount = completedCount;
    }
    public override void Complete()
    {
        _completedCount ++;
    }
    public override int EarnPoints()
    {
        return _points * _completedCount;
    }
    public string GetRomanNumeral(int number)
    {
        if(number == 0)
        {
            return "0";
        }

        string romanNumeral = "";
        while(number / 10 > 0)
        {
            //10
            romanNumeral += "X";
            number -= 10;
        }
        //9
        if(number == 9)
        {
            romanNumeral += "IX";
            return romanNumeral;
        }
        while(number / 5 > 0)
        {
            //5
            romanNumeral += "V";
            number -= 5;
        }
        //4
        if(number == 4)
        {
            romanNumeral += "IV";
            return romanNumeral;
        }
        while(number > 0)
        {
            //1
            romanNumeral += "I";
            number -= 1;
        }
        return romanNumeral;
    }
    public override void Display()
    {
        Console.WriteLine($"[{GetRomanNumeral(_completedCount)}] {_name} ({_discription}): ({_points}){EarnPoints()}");
    }
    public override string GetData()
    {
        return $"Eternal;{_name};{_discription};{_points};{_completedCount}";
    }
}
