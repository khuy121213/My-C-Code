using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Whats your name: ");
        string name = Console.ReadLine();
        Console.Write("How old are you: ");
        string ageString = Console.ReadLine();
        if(int.TryParse(ageString , out int age))
        {
            Console.Write("Whats your favorite food: ");
            string food = Console.ReadLine();
            Console.Write("Whats your second favorite food: ");
            string food2 = Console.ReadLine();
            Console.WriteLine($"Hi, my name is {name}! I am {age} years old! I like {food} and {food2}!");
        }
        else
        {
            Console.WriteLine("Invalid age number!");
        }
        
    }
}
