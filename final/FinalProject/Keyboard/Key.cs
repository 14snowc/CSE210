class Key
{
    public char key;
    public string function;

    public Key(char inKey, string inFunction)
    {
        key = inKey;
        function = inFunction.ToLower();
    }
}