using System;

class Program
{
    static void Main(string[] args)
    {
        string text = Input("Enter first number: ");
        Console.WriteLine(text);
    }

    static string Input(string text)
    {
        Console.Write(text);
        string user_input = Console.ReadLine();
        return user_input;
    }
}