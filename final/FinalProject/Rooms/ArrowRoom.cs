class ArrowRoom: RoomBase
{
    public ArrowRoom(): base()
    {
        _image = "[arw]";
    }
    protected override void SetImage()
    {
        if(_isRevealed)
            base.SetImage();
        else
            _image = "[arw]";
    }
    public override string ReturnRoomType()
    {
        return "arrow";
    }
}