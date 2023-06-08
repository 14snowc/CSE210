using System;

class Program
{
    static void Main(string[] args)
    {
        bool continueLoop = true;
        var Breathing = new BreathingActivity();
        var Reflection = new ReflectionActivity();
        var Listing = new ListingActivity();
        while(continueLoop)
        {
            Console.Clear();
            DisplayMenu();
            Console.Write("Enter a number: ");
            int userOptionInput = int.Parse(Console.ReadLine());
            
            if(userOptionInput == 1)
            {
                Breathing.breathMain();
            }
            else if(userOptionInput == 2)
            {
                Reflection.RefelctionMain();
            }
            else if(userOptionInput == 3)
            {
                Listing.ListingMain();
            }
            else if(userOptionInput == 4)
            {
                continueLoop = false;
            }

        }

        var activity = new BreathingActivity();
    }
    static void DisplayMenu()
    {
        Console.WriteLine("Mindfullness\nSelect your option.\n1. Breathing Activity.\n2. Reflection Activity.\n3. Listing Activity.\n4. Quit.\n");
    }
    
}