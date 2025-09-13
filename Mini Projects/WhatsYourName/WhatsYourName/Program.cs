using System;

while (true)
{
    Console.Write("Whats your name: ");
    string? name = Console.ReadLine();

    // Check for Bill
    if (name != null && name.Equals("bill", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("DID U JUST SAY 67????");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("BOII");
        }
        for (int i = 0; i < 10; i++)
        {
            Console.Write("SIX ");
            Console.WriteLine("SEVEN ");
        }
    }
    else
    {
        // Normal greeting
        Console.WriteLine($"Hello {name}!");
    }

    Console.WriteLine();
    Console.Write("Press any key to restart: ");
    Console.ReadKey(true);
    Console.Clear();
    Console.WriteLine("HelloWorld(\"print\")");
}
