using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep1 World!");
        string first_name = GetInput("What is your first name? ");
        string last_name = GetInput("What is your last name? ");
        Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}");
    }
    
    static string GetInput(string text)
    {
        Console.Write(text);
        string user_text = Console.ReadLine();
        return user_text;
    }
}