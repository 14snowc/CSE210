class RoomBase
{
    protected string _image;
    protected bool _isNearDragon;
    protected bool _isNearTrap;
    protected bool _isRevealed;
    protected bool _hasPlayer;
    protected List<RoomBase> _nearbyRooms;

    public RoomBase()
    {
        _isNearDragon = false;
        _isNearTrap = false;
        _isRevealed = false;
        _hasPlayer = false;
    }

    public virtual string ReturnRoomType()
    {
        return "safe";
    }
    public void SetNearbyRooms(List<RoomBase> nearbyRooms)
    {
        _nearbyRooms = new List<RoomBase>(nearbyRooms);
    }
    public RoomBase NearbyRoom(int direction)
    {
        return _nearbyRooms[direction % 4];
    }
    public virtual RoomBase PlayerMoveInto(int direction)
    {
        _isRevealed = true;
        _hasPlayer = true;
        SetImage();
        return this;
    }
    public virtual void StartingExecution()
    {
        SetImage();
    }
    public RoomBase PlayerMoveOut(int direction)
    {
        _hasPlayer = false;
        SetImage();
        return _nearbyRooms[direction].PlayerMoveInto(direction);
    }
    public void Display(bool forceReveal = false)
    {
        if(_isRevealed || forceReveal)
        {
            SetImage();
            Console.Write(_image);
        }
        else
            Console.Write("|   |");
    }
    protected virtual void SetImage()
    {
        _image = "[";

        if(_isNearTrap)
        {
            _image += "X";
        }
        else
        {
            _image += " ";
        
        }
        if(_hasPlayer)
        {
            _image += "}";
        }
        else
        {
            _image += " ";
        }
        
        if(_isNearDragon)
        {
            _image += "#";
        }
        else
        {
            _image += " ";
        }
        _image += "]";
    }
    public virtual void SetBoolisNear(int direction, string boolName, bool boolValue, int range)
    {
        if(boolName.ToLower() == "dragon")
        {
            _isNearDragon = boolValue;
        }
        else if(boolName.ToLower() == "trap")
        {
            _isNearTrap = boolValue;
        }
        SetImage();
        if(range > 0)
        {
            direction = 0;
            foreach(var room in _nearbyRooms)
            {
                room.SetBoolisNear(direction, boolName, boolValue, range -1);
                direction += 1;
            }
        }
    }
}