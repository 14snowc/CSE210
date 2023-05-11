using System;

class Program
{
    static void Main(string[] args)
    {
        string textNormal = "Hello\nHow are you doing?\nIm fine.";
        string[] textSplit = textNormal.Split("\n");
        Console.Write(textSplit[2]);
    }

}
