while (true)
{
    Console.Write("Whats your name: ");
    string name = Console.ReadLine();

    if (name == "bill" || name == "BILL" || name == "Bill")
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
        Console.WriteLine($"Hello {name}!");
    }
    Console.WriteLine();
    Console.Write("Enter a key to restart: ");
    Console.ReadKey(true);
    Console.Clear();
    continue;
}