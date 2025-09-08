using System;

class Program
{
    static void Main()
    {
        bool Restart = true;
        while (Restart)
        {
            Console.Write("\nPick a number: ");
            string numString = Console.ReadLine();
            if (!int.TryParse(numString, out int num))
            {
                Console.WriteLine("Invalid input!");
                Console.WriteLine("Enter any key to restart , press 'q' to quit");
                char restart = Console.ReadKey().KeyChar;
                if(restart == 'q')
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            if(num % 2 == 0)
            {
                Console.WriteLine("Even");
                Console.WriteLine("Enter any key to restart , press 'q' to quit");
                char restart = Console.ReadKey().KeyChar;
                if (restart == 'q')
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Odd");
                Console.WriteLine("Enter any key to restart , press 'q' to quit");
                char restart = Console.ReadKey().KeyChar;
                if (restart == 'q')
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
