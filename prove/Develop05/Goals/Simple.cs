class Simple : Goal
{
    public Simple(string name, string discription, int points) : base(name, discription, points)
    {}
    public Simple(string name, string discription, int points, bool isComplete) : base(name, discription, points)
    {
        _isComplete = isComplete;
    }
}