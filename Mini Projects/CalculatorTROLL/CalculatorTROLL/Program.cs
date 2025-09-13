using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Choose the 1st number!: ");   // prints prompt
        int num1 = int.Parse(Console.ReadLine());   // reads input and converts to int
        Console.Write("Choose the 2nd number!: ");   // prints prompt
        int num2 = int.Parse(Console.ReadLine());// reads input and converts to int
        if (num1 == null || num2 == null)
        {
            Console.WriteLine("You suck");
        }
        if (num1 >= 10 || num2 >= 10)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Calculating SUPER HARD....");
            Thread.Sleep(1000);
            Console.WriteLine("Wasting billions of gallons of water to calculate ts....");
            Thread.Sleep(1000);
            Console.WriteLine("Results are coming....");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: ts too hard to calculate");
            Console.ResetColor(); // reset color back to normal

        }
        else
        {
            Thread.Sleep(1000);
            Console.WriteLine("Calculating SUPER HARD....");
            Thread.Sleep(1000);
            Console.WriteLine("Wasting billions of gallons of water to calculate ts....");
            Thread.Sleep(1000);
            Console.WriteLine("Results are coming....");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World!");
        }
        
    }
    
}