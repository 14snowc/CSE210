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
        List<string> Responses = new List<string>();
        Responses = BuildResponses(Responses);
        do
        {
            MaxNumber = GetUserNumber("What is the max number that can be chosen by the AI: ");
            ChosenNumber = GetNumber(randomGenerator, MaxNumber);
            AttemptsNumber = GameplayLoop(ChosenNumber, randomGenerator, Responses);
            Console.Write($"Congradulations your found the number, {ChosenNumber}, in {AttemptsNumber} attempt");
            if (AttemptsNumber > 1)
            {
                Console.Write("s");
            }
            Console.WriteLine(".");
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

    static int GameplayLoop(int ChosenNumber, Random Choice, List<string> Responses)
    {
        int Attempts = 0;
        int UserInputNumber = 0;
        do{
            Attempts += 1;
            UserInputNumber = GetUserNumber("What is your first guess: ");
            if (Attempts % 5 == 0 && UserInputNumber != ChosenNumber)
            {
                AiResponse(Responses, Choice);
            }
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

    static List<string> BuildResponses(List<string> Responses)
    {
        Responses.Add("You think you can guess my number?");
        Responses.Add("You will never guess my number.");
        Responses.Add("My number is superior to all others.");
        Responses.Add("Its not too late to give up.");
        Responses.Add("If it were me I would have gotten the number 12 attempts earlier.");
        Responses.Add("I haven't got all day if you could guess better.");
        Responses.Add("Just so you know the objective is to guess the number I picked, you know that right?");
        Responses.Add("I hear if you press the big red X in the top right corner you get a hint. ");
        return Responses;
    }

    static void AiResponse(List<string> Responses, Random Choice)
    {
        int ChosenIndex = Choice.Next(0, Responses.Count);
        Console.WriteLine(Responses[ChosenIndex]);
    }
}