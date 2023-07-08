class SlideRoom: RoomBase
{
    
    private int _offset;

    public SlideRoom(): base()
    {
        var choice = new Random();
        _offset = choice.Next(0, 2);

        SetImage();
    }

    protected override void SetImage()
    {
        if(_offset == 1)
        {
            _image = "[ / ]";
        }
        else if(_offset == 0)
        {
            _image = "[-|-]";
        }
        else if(_offset == 2)
        {
            _image = "[ \\ ]";
        }
    }
    public int GetNewDirection(int direction)
    {
        switch(_offset)
        {
            case(0): //Continue
                return direction;

            case(1): //0 and 1 vs 2 and 3
                if(direction % 2 == 0)
                    return direction + 1;
                else
                    return direction - 1;
            
            case(2): //0 and 3 vs 1 and 2
                if(direction % 2 == 0)
                    return (direction - 1) % 4;
                else
                    return (direction + 1) % 4;
        }
        
        return 0;
    }

    public override RoomBase PlayerMoveInto(int direction)
    {
        _isRevealed = true;
        int newDirection = GetNewDirection(direction);
        return _nearbyRooms[newDirection].PlayerMoveInto(newDirection);
    }

    public override void SetBoolisNear(int direction, string boolName, bool boolValue, int range)
    {
        int newDirection = GetNewDirection(direction);
        _nearbyRooms[newDirection].SetBoolisNear(newDirection, boolName, boolValue, range);
    }
}