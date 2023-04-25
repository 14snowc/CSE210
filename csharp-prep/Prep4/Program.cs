using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> UserNumbers = new List<int>();
        UserNumbers = LoopFillListInt(UserNumbers);
        int Sum = GetSum(UserNumbers);
        float Average = GetAverage(UserNumbers, Sum);
        int LargestNumber = GetLargestNumber(UserNumbers);
        Console.WriteLine($"The sum is: {Sum}");
        Console.WriteLine($"The Average is: {Average}");
        Console.WriteLine($"The largest number is: {LargestNumber}");

        int SmallestPositiveNumber = GetSmallestPositiveNumber(UserNumbers);
        Console.WriteLine($"The smallest positive number is: {SmallestPositiveNumber}");
        UserNumbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach(int UserNumber in UserNumbers)
        {
            Console.WriteLine(UserNumber);
        }
    }

    static int GetUserNumber(string Message)
    {
        Console.Write(Message);
        string UserInputString = Console.ReadLine();
        return int.Parse(UserInputString);
    }

    static List<int> LoopFillListInt(List<int> UserNumbers)
    {
        int UserNumber = 0;
        do{
            UserNumber = GetUserNumber("Enter a number to add to the list or enter 0 to finish: ");
            if (UserNumber != 0)
            {
                UserNumbers.Add(UserNumber);
            }
        } while(UserNumber != 0);
        return UserNumbers;
    }

    static int GetSum(List<int> UserNumbers)
    {
        int Sum = 0;
        foreach (int UserNumber in UserNumbers)
        {
            Sum += UserNumber;
        }
        return Sum;
    }

    static float GetAverage(List<int> UserNumbers, int Sum)
    {
        int TotalNumbers = UserNumbers.Count;
        float Average = Sum / TotalNumbers;
        return Average;
    }
    
    static int GetLargestNumber(List<int> UserNumbers)
    {
        int LargestNumber = UserNumbers[0];
        foreach (int UserNumber in UserNumbers)
        {
            if (LargestNumber < UserNumber)
            {
                LargestNumber = UserNumber;
            }
        }
        return LargestNumber;
    }

    static int GetSmallestPositiveNumber(List<int> UserNumbers)
    {
        int SmallestPositiveNumber = UserNumbers[0];

        foreach(int UserNumber in UserNumbers)
        {
            if (UserNumber > 0)
            {
                if (UserNumber < SmallestPositiveNumber)
                {
                    SmallestPositiveNumber = UserNumber;
                }
                if (SmallestPositiveNumber < 0)
                {
                    SmallestPositiveNumber = UserNumber;
                }
            } 
        }
        if (SmallestPositiveNumber < 0)
        {
            SmallestPositiveNumber = 0;
        }
        return SmallestPositiveNumber;
    }
}