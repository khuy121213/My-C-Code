using System;
using System.Runtime.InteropServices;
using System.Threading;
namespace IdleIncrement;
public class MainGame
{

    public static void Main()
    {
        int baseCd = 1000;
        int currentCd = baseCd;
        var state = new GameState();
        Console.WriteLine("Press E to upgrade speed");
        while (true)
        {
            state.Coins += state.CoinsPS;
            Thread.Sleep(currentCd);
            Console.Write("\r" + new string(' ', 50)); // clear the line
            Console.Write($"\rYou have {state.Coins} coins");
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                char key = char.ToLower(keyInfo.KeyChar);
                if(key == 'e')
                {
                    Upgrades.UpgradeSpeed(state);
                }
            }
            if (state.Coins == 1000)
            {
                break;
            }
        }
        }
    }

public class GameState
{
    public int currentCd = 1000;
    public double Coins { get; set; } = 0;
    public double CoinsPS { get; set; } = 1;
}

public class Upgrades
{
    public static void UpgradeSpeed(GameState state)
    {
        if (state.Coins >= 10)
        {
            state.currentCd = Math.Max(100, state.currentCd - 50);
            Console.WriteLine();
            Console.WriteLine($"You upgraded!Your new cooldown is {state.currentCd}");
            Thread.Sleep(500);
            Console.Write("\r" + new string(' ', 50));
        }
    }
}