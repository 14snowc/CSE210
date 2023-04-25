using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome("Welcome to the program!");
        string UserName = PromptUserName("Please enter your name: ");
        int UserNumber = PromptUserNumber("Please enter your favorite number: ");
        int SquaredNumber = SquareNumber(UserNumber);
        DisplayResult(UserName, SquaredNumber);
    }

    static void DisplayWelcome(string Message)
    {
        Console.WriteLine(Message);
    }

    static string PromptUserName(string Message)
    {
        Console.Write(Message);
        return Console.ReadLine();
    }

    static int PromptUserNumber(string Message)
    {
        string UserString = PromptUserName(Message);
        return int.Parse(UserString);
    }

    static int SquareNumber(int UserNumber)
    {
        return UserNumber * UserNumber;
    }

    static void DisplayResult(string UserName, int SquaredNumber)
    {
        Console.Write(UserName);
        Console.Write(", the square of your number is ");
        Console.WriteLine(SquaredNumber);
    }
}