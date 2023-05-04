using System;

class Program
{
    static void Main(string[] args)
    {
       var personOne = new Person("Layne", "Moseley");
       var personTwo = new Person("David", "Hasselhoff");

        personOne.Talk();

    }

}

public class Person {
    string firstName;
    string lastName;

    public Person(string fN, string lN){
        firstName = fN;
        lastName = lN;
    }


    public void Breathe() {
        Console.WriteLine($"{firstName} {lastName} is breathing.");
    }

    public void Walk() {
        Console.WriteLine($"{firstName} {lastName} is Walking.");
    }

    public void Talk() {
        Console.WriteLine($"My name is {lastName}, {Fullname()}.");
    }

    public string Fullname() {
        return firstName + " " + lastName;
    }

}