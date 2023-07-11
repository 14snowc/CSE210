class StartingRoom: RoomBase
{
    public StartingRoom(): base()
    {
        _hasPlayer = true;
        _isRevealed = true;
        SetImage();
    }
}