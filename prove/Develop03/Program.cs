using System;

class Program
{
    static void Main(string[] args)
    {
        string[] Lines = GetStringFromFile("Scripture.txt");

        Reference reference = new Reference(Lines[0]);
        Scripture scripture = new Scripture(reference, Lines);

        string userInput = "";
        bool loop = true;
        while(loop)
        {
            if(scripture.GetUnhiddenWords().Count == 0)
            {
                loop = false;
            }

            scripture.Display();

            scripture.HideRandomWord();

            Console.WriteLine();
            userInput = Console.ReadLine();
            if(userInput.ToLower() == "quit")
            {
                loop = false;
            }
        }


        string[] GetStringFromFile(string Filename)
        {
            string[] Lines = System.IO.File.ReadAllLines(Filename);
            return Lines;
        }
    }   
}