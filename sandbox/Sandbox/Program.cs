using System;

class Program
{
    static void Main(string[] args)
    {
       var list1 = new List<int>();
       list1.Add(1);
       list1.Add(2);
       list1.Add(3);

       var list2 = new List<int>();
       list2.Remove(3);

        foreach(int number in list1){
            Console.WriteLine(number);
        }
        foreach(int number in list2){
        Console.WriteLine(number);
       }
    }

   
}
