class DragonRoom: RoomBase
{
    public DragonRoom(): base()
    {
        _isNearDragon = true;
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
        _image = "[Dra]";
    }

    public override string ReturnRoomType()
    {
        return "dragon";
    }
    public override void StartingExecution()
    {
        int direction = 0;
        foreach(var room in _nearbyRooms)
        {
            room.SetBoolisNear(direction, "dragon", true, 1);
            direction += 1;
        }
    }
}