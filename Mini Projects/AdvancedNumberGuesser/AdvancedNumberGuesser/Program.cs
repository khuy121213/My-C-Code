using System;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string num = InputNum();
            Thread.Sleep(1000);
            Console.WriteLine("Inventing new equations for your ass...");
            Thread.Sleep(1000);
            Console.WriteLine("Wasting 1 gazzilion gallons of water for this useless program...");
            Thread.Sleep(1000);
            Console.WriteLine($"I guess you entered...");
            Thread.Sleep(1000);
            Console.WriteLine(num + "!");            
            //Console.WriteLine("Done with the program and learned custom methods");
            Console.Write("Restart(any key) or quit(q): ");
            if(Console.ReadKey().KeyChar == 'q') 
            {
                break;
            }
            else
            {
                continue;
            }
        }
    }
    public static string InputNum()
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write("Give me a number and I will guess it with complex calculations: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int num))
            {
                Console.WriteLine("Invalid input!, press any key to restart or q to quit: ");
                if (Console.ReadKey().KeyChar == 'q')
                {
                    return null;
                }
            }
            else
            {
                return input;
            }

        }
    }
}
