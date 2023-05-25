public class Reference
{
    private string _reference;

    public Reference(string reference)
    {
        _reference = reference;
    }
    public Reference(string book, int chapter, int verse)
    {
        _reference = $"{book} {chapter}:{verse}";
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _reference = $"{book} {chapter}:{startVerse}-{endVerse}";
    }

    public string GetReference()
    {
        return _reference;
    }
}