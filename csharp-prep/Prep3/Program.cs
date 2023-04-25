using System;

class Program
{
    static void Main(string[] args)
    {
        int MaxNumber = 0;
        int ChosenNumber = 0;
        int AttemptsNumber = 0;
        Random randomGenerator = new Random();
        string UserResponse = "";
        do
        {
            MaxNumber = GetUserNumber("What is the max number that can be chosen by the AI: ");
            ChosenNumber = GetNumber(randomGenerator, MaxNumber);
            AttemptsNumber = GameplayLoop(ChosenNumber);
            Console.WriteLine($"Congradulations your found the number, {ChosenNumber}, in {AttemptsNumber} attempts.");
            UserResponse = GetUserStringLower("Do you want to play again? (Yes/No) ");
        }   while (UserResponse == "yes");
        Console.Write("Have a good day.");
    }
    static string GetUserStringLower(string Message)
    {
        Console.Write(Message);
        string UserInputString = Console.ReadLine();
        return UserInputString.ToLower();
    }
    static int GetUserNumber(string Message)
    {
        Console.Write(Message);
        string UserInputString = Console.ReadLine();
        return int.Parse(UserInputString);
    }
    static int GetNumber(Random Generator, int HighestNumber)
    {
        return Generator.Next(1, HighestNumber);
    }

    static int GameplayLoop(int ChosenNumber)
    {
        int Attempts = 0;
        int UserInputNumber = 0;
        do{
            Attempts += 1;
            UserInputNumber = GetUserNumber("What is your first guess: ");
            if (UserInputNumber > ChosenNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (UserInputNumber < ChosenNumber)
            {
                Console.WriteLine("Higher");
            }
        } while(UserInputNumber != ChosenNumber);
        return Attempts;
    }
}