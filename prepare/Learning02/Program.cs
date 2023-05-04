using System;

class Program
{
    static void Main(string[] args)
    {
        var microsoft = new Job();
        microsoft.company = "Microsoft";
        microsoft.jobTitle = "Software Engineer";
        microsoft.startYear = 1998;
        microsoft.endYear = 2000;
        microsoft.Display();

        var personalResume = new Resume();
        personalResume.name = "Allison Rose";
        personalResume.jobs = new List<string>();
        personalResume.jobs.Add("Software Engineer (Microsoft) 2019-2022");
        personalResume.jobs.Add("Manager (Apple) 2022-2023");
        personalResume.Display();
    }
}

public class Job{

    public string company;
    public string jobTitle;
    public int startYear;
    public int endYear;

    // public Job(string companyName, string job, int yearStart, int yearEnd){
    //     company = companyName;
    //     jobTitle = job;
    //     startYear = yearStart;
    //     endYear = yearEnd;
    // }

    public void Display(){
        Console.WriteLine($"{jobTitle} ({company}) {startYear}-{endYear}");
    }
}

public class Resume{
    public string name;
    public List<string> jobs;


    // public Resume(string firstName, string lastName, List<string> jobList){
    //     name = $"{firstName} {lastName}";
    //     jobs = jobList;
    // }

    public void Display(){
        Console.WriteLine($"Name: {name}");
        Console.WriteLine("Jobs: ");
        foreach (string job in jobs){
            Console.WriteLine($"-{job}");
        }
    }
}