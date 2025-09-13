using System;
using System.Reflection.Metadata.Ecma335;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            if (name == "bill")
            {
                Console.WriteLine("Poopoo");
            } else
            {
                Console.WriteLine("Hello" + " " + name);
            }
        }
    }
}