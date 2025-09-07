//this is to make up for my other "calculator"
using System.Runtime.InteropServices;
using System;

class Program
{
    static void Main()
    {
        double result = 0;
        Console.WriteLine("Welcome to the calculator!");

        Console.Write("Choose your first number: ");
        string stringnum1 = Console.ReadLine();

        if (!double.TryParse(stringnum1, out double num1))
        {
            Console.Write("Invalid number for the first number!");
            return;
        }

        Console.Write("Choose an operator (+ - * /): ");
        string Operator = Console.ReadLine();

        Console.Write("Choose your second number: ");
        string stringnum2 = Console.ReadLine();

        if (!double.TryParse(stringnum2, out double num2))
        {
            Console.Write("Invalid number for the second number!");
            return;
        }

        switch (Operator)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if(num2 == 0)
                {
                    Console.WriteLine("Cannot divide by zero!");
                    return;
                }
                result = num1 / num2;
                break;
            default:
                Console.WriteLine("Invalid operator!");
                return;
        }

            Console.WriteLine($"The result of {num1} {Operator} {num2} is: {result}");
        Console.WriteLine("Finished calculator!");
    }
}