using System;

class Program
{
    static void Main(string[] args)
    {
        int grade_percent = InputInt("Enter a grade number: ");
        string letter_grade = GetLetterGrade(grade_percent);
        Console.WriteLine(letter_grade);
    }

    static int InputInt(string text)
    {
        Console.Write(text);
        string user_input_string = Console.ReadLine();
        int user_input = int.Parse(user_input_string);
        return user_input;
    }

    static string GetLetterGrade(int grade_percent)
    {
        string letter_grade;
        if (grade_percent >= 90)
        {
            letter_grade = "A";
        }
        else if (grade_percent >= 80)
        {
            letter_grade = "B";
        }
        else if(grade_percent >= 70)
        {
            letter_grade = "C";
        }
        else if(grade_percent >= 60)
        {
            letter_grade = "D";
        }
        else
        {
            return "F";
        }
        if (grade_percent % 10 >= 7) 
        {
            if (letter_grade != "A")
            {
                letter_grade += "+";
            }
        }
        else if (grade_percent % 10 < 3)
        {
            letter_grade += "-";
        }
        return letter_grade;
    }
}