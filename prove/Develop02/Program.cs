using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        File file = new File();

        bool inUse = true;
        int userChoice;
        string filename;
        string entryTime;
        string entryPrompt;
        string entryText;

        while(inUse)
        {
            Console.WriteLine();
            userChoice = menu.MenuMain();
            if (userChoice == 1)
            {
                //Write a new entry
                Console.Write("Enter the date: ");
                entryTime = Console.ReadLine();

                entryPrompt = promptGenerator.getPrompt();
                Console.WriteLine(entryPrompt);

                Console.Write("-");
                entryText = Console.ReadLine();

                Entry entry = new Entry(entryTime, entryPrompt, entryText);
                journal.entries.Add(entry);
            }
            else if(userChoice == 2)
            {
                //Display the journal
                journal.display();
            }
            else if(userChoice == 3)
            {
                //Save the journal to a file
                Console.Write("Enter the filename here: ");
                filename = Console.ReadLine();
                file.Save(journal, filename);
            }
            else if(userChoice == 4)
            {
                //Load the journal from a file
                Console.Write("Enter the filename here: ");
                filename = Console.ReadLine();
                file.Load(journal, filename);
            }
            else if(userChoice == 5)
            {
                //Quit
                inUse = false;
            }
            else
            {
                //Invalid entry
                Console.WriteLine("Invalid.");
            }
        }
        Console.WriteLine("Goodbye.");


    }
}

public class Menu
{
    public List<string> Options;

    public Menu(){
        Options = new List<string>();
        Options.Add("Write a new entry");
        Options.Add("Display the journal");
        Options.Add("Save the journal to a file");
        Options.Add("Load the journal from a file");
        Options.Add("Quit");
        
    }

    public int MenuMain()
    {
        Console.WriteLine("Would you like to: ");
        displayOptions();
        return getUserChoice();
    }

    public void displayOptions()
    {
        int optionNumber = 0;
        foreach(string Option in Options){
            optionNumber += 1;
            Console.WriteLine($"{optionNumber}: {Option}.");
        }
    } 

    public int getUserChoice()
    {
        Console.Write("Please enter a number: ");
        int UserChoice = int.Parse(Console.ReadLine());
        return UserChoice;
    }
}

public class PromptGenerator
{
    List<string> Prompts;
    Random randomChoice;

    public PromptGenerator()
    {
        Prompts = new List<string>();
        Prompts.Add("Who was the most interesting person I interacted with today?");
        Prompts.Add("What was the best part of my day?");
        Prompts.Add("How did I see hand of the Lord in my life today?");
        Prompts.Add("What was the strongest emotion I felt today?");
        Prompts.Add("If I had one thing I could do over today, what would it be?");

        randomChoice = new Random();
    }

    public string getPrompt()
    {
        return Prompts[randomChoice.Next(0, Prompts.Count())];
    }
}

public class Journal
{
    public List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void display()
    {
        foreach(Entry entry in entries)
        {
            entry.display();
        }
    }
}

public class Entry
{
    string prompt;
    string text;
    string date;
    
    public Entry(string dateEntered, string generatedPrompt, string userText)
    {
        prompt = generatedPrompt;
        text = userText;
        date = dateEntered;
    }

    public string data()
    {
        string combinedData = $"{date}\n{prompt}\n-{text}";
        return combinedData;
    }
    
    public void display()
    {
        Console.WriteLine();
        Console.WriteLine(data());
    }
}


public class File
{
    StreamReader reader;
    StreamWriter writer;
    string line;
    string lineDate;
    string linePrompt;
    public void Save(Journal journal, string Filename)
    {
        writer = new StreamWriter(Filename);
        foreach(Entry entry in journal.entries)
        {
            writer.WriteLine(entry.data());
        }
        writer.Close();
    }
    public void Load(Journal journal, string Filename)
    {
        reader = new StreamReader(Filename);
        //Journal journal = new Journal();
        line = reader.ReadLine();
        while(line != null)
        {
            lineDate = line;
            line = reader.ReadLine();
            linePrompt = line;
            line = reader.ReadLine();
            Entry entry = new Entry(lineDate, linePrompt, line);
            journal.entries.Add(entry);
            line = reader.ReadLine();
        }
        reader.Close();

        //return journal;
    }
}