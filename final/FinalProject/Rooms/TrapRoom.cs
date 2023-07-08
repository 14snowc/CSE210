class TrapRoom: RoomBase
{
    public TrapRoom(): base()
    {
        _isNearTrap = true;
        SetImage();
    }
    public override RoomBase PlayerMoveInto(int direction)
    {
        _isRevealed = true;
        _hasPlayer = true;
        return this;
    }
    protected override void SetImage()
    {
        _image = "[Tra]";
    }
    public override string ReturnRoomType()
    {
        return "trap";
    }
    public override void StartingExecution()
    {
        int direction = 0;
        foreach(var room in _nearbyRooms)
        {
            room.SetBoolisNear(direction, "trap", true, 0);
            direction += 1;
        }
    }
}