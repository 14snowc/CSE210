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
        Console.Write("The sum is: ");
        Console.WriteLine(Sum);
        Console.Write("The Average is: ");
        Console.WriteLine(Average);
        Console.Write("The largest number is: ");
        Console.WriteLine(LargestNumber);
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
}