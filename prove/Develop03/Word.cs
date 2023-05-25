public class Word
{
    private bool _ishidden;
    private string _letters;
    private bool _canHide;

    public Word(string text, bool canHide = true)
    {
        _letters = text;
        _canHide = canHide;
        _ishidden = !canHide;
    }

    public string GetLetters()
    {
        if(!_canHide)
        {
            return _letters;
        }
        if(_ishidden)
        {
            string text = "";
            for(int _ = 0; _ < _letters.Length; _++)
            {
                text += "_";
            }
            return text;
        }
        return _letters;
    }

    public bool GetisHidden()
    {
        return _ishidden;
    }
    public void SetHidden(bool hidden)
    {
        _ishidden = hidden;
    }
}