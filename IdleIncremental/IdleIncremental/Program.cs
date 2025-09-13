using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
namespace IdleIncrement;
public class MainGame
{

    public static void Main()
    {
        var state = new GameState();
        Console.WriteLine("Press E to upgrade speed");
        string lastMessage = "";
        int messageTime = 0;
        while (true)
        {
            state.Coins += state.CoinsPS;
            Console.SetCursorPosition(0, 1);
            Console.Write("\r" + new string(' ', 50)); // clear the line
            Console.SetCursorPosition(0, 1);
            Console.Write($"\rCoins: {state.Coins}");
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                char key = char.ToLower(keyInfo.KeyChar);
                if(key == 'e')
                {
                    lastMessage = Upgrades.UpgradeSpeed(state);
                    messageTime = Environment.TickCount;
                    
                }
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true); // read and discard everything left
                }
            }
            Console.SetCursorPosition(0, 2);
            Console.Write("\r" + new string(' ', 50));
            int currentTime = Environment.TickCount;
            if ( currentTime - messageTime < 1000)
            {
                Console.SetCursorPosition(0, 2);
                Console.Write(lastMessage);
            }
            Thread.Sleep(state.currentCd);
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
    public static string UpgradeSpeed(GameState state)
    {
        if (state.Coins >= 10)
        {
            state.Coins -= 10;
            state.currentCd = Math.Max(100, state.currentCd - 50);
            Console.WriteLine();
            return $"You upgraded!Your new cooldown is {state.currentCd} ms";

        }
        else
        {
            return "You dont have enough coins!";
        }
    }
}