public class Scripture
{
    private Reference _scriptureReference;
    private List<Word> _words;
    Random choice;

    public Scripture(Reference reference, string[] Lines)
    {
        choice = new Random();
        _words = new List<Word>();
        _scriptureReference = reference;
        for(int index = 1; index < Lines.Count(); index ++)
        {
            string Line = Lines[index];
            bool verse_number = true;
            foreach(string text in Line.Split(" "))
            {
                Word word;
                if(verse_number)
                {
                    word = new Word($"\n{text}:", false);
                    verse_number = false;
                }
                else
                {
                    word = new Word(text);
                }
                _words.Add(word);
                
            }

        }
        
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_scriptureReference.GetReference());
        foreach(Word word in _words)
        {
            Console.Write($"{word.GetLetters()} ");
        }
    }

    public List<Word> GetUnhiddenWords()
    {
        List<Word> unhiddenWords = new List<Word>();
    
        foreach(Word word in _words)
        {
            if(!word.GetisHidden())
            {
                unhiddenWords.Add(word);
            }
        }
        return unhiddenWords;
    }

    public void HideRandomWord()
    {
        List<Word> unhiddenWords = GetUnhiddenWords();
    

        int loopNumber = 0;
        while(loopNumber < 3 & unhiddenWords.Count > 0)
        {
            loopNumber += 1;
            int randomIndex = choice.Next(0, unhiddenWords.Count);
            Word chosenWord = unhiddenWords[randomIndex];
            chosenWord.SetHidden(true);
            unhiddenWords.Remove(chosenWord);
        }
    }
    
}
