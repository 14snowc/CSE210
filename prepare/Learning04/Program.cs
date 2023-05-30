using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment Richard = new Assignment("Richard Rich Richmond", "Writing"); 
        Console.WriteLine(Richard.GetSummary());

        MathAssignment Matt = new MathAssignment("Matt Mathew Matter", "Math", "3.4", "5-9");
        Console.WriteLine(Matt.GetHomeworkList());

        WritingAssignment Wright = new WritingAssignment("Wright right write", "Writing", "Write rightly, right?");
        Console.WriteLine(Wright.GetWritingInformation());
    }
}

class Assignment
{
    protected string _studentName;
    protected string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}

class MathAssignment: Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems): base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"{GetSummary()} \nSection {_textbookSection} Problems {_problems}";
    }
}

class WritingAssignment: Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title): base(studentName, topic)
    {
        _title = title;
    }
    public string GetWritingInformation()
    {
        return $"{GetSummary()} \n{_title}";
    }
}