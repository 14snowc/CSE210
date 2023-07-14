class Keyboard
{
    private List<Key> _keys;

    public Keyboard()
    {
        _keys = new List<Key>();
    }

    public void AddKey(char character, string function)
    {
        foreach(var _key in _keys)
        {
            if(_key.key == character)
            {
                if(function != "unbind")
                    _key.function = function;
                else
                    _keys.Remove(_key);
                return;
            }
        }
        _keys.Add(new Key(character, function));
    }
    public string GetKeyPress(bool loop = true)
    {
        do
        {
            var key = Console.ReadKey().KeyChar;
            foreach(var _key in _keys)
            {
                if(key == _key.key)
                {
                    return _key.function;
                }
            }
        } while(loop);
        return "invalid";
    }
    public void ListKeys()
    {
        foreach(var key in _keys)
        {
            Console.WriteLine($"{key.function}: {key.key}");
        }
        Console.WriteLine("\n");
    }
}