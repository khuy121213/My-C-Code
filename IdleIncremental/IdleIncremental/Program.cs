using System;
namespace IdleIncrement;
public class MainGame
{

    public static void Main()
    {
        int currencyCD = 1000;
        Currency currency = new Currency();
        while (true)
        {
            currency.Coins += currency.CoinsPS;
            Thread.Sleep(currencyCD);
            Console.WriteLine($"\rYou have {currency.Coins} coins");
            if (currency.Coins == 10)
            {
                break;
            }
        }
    }

}

public class Currency
{
    public double Coins { get; set; } = 0;
    public double CoinsPS { get; set; } = 1;
}