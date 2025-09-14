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
        Console.CursorVisible = false;
        int speedCost = 10;
        int cpsCost = 20;
        Console.WriteLine("Press E to upgrade speed , F to upgrade coin/s per sec");
        string lastMessage = "";
        int messageTime = 0;
        int lastCointick = Environment.TickCount;
        while (true)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write("\r" + new string(' ', 50)); // clear the line
            Console.SetCursorPosition(0, 2);
            Console.Write($"\rCoins: {state.Coins}");
            Console.SetCursorPosition(0, 4);
            Console.Write("\r" + new string(' ', 50));  // clear line
            Console.SetCursorPosition(0, 4);
            Console.Write("Prices: Speed: " + speedCost + " , CPS: " + cpsCost);
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                char key = char.ToLower(keyInfo.KeyChar);
                if(key == 'e')
                {
                    lastMessage = Upgrades.UpgradeSpeed(state , ref speedCost);
                    messageTime = Environment.TickCount;
                    
                }
                else if (key == 'f')
                {
                    lastMessage = Upgrades.UpgradeCPS(state , ref cpsCost);
                    messageTime = Environment.TickCount;
                }
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true); // read and discard everything left
                    }
            }
            if(Environment.TickCount - lastCointick >= state.currentCd)
            {
                state.Coins += state.CoinsPS;
                lastCointick = Environment.TickCount;
            }
            Console.SetCursorPosition(0, 3);
            Console.Write("\r" + new string(' ', 50));
            int currentTime = Environment.TickCount;
            if ( currentTime - messageTime < 1000)
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(lastMessage);
            }
            Thread.Sleep(10);
            if (state.Coins >= 1000)
            {
                break;
            }
        }
        }
    }

public class GameState
{
    public int currentCd = 1000;
    public int Coins { get; set; } = 0;
    public int CoinsPS { get; set; } = 1;
}

public class Upgrades
{
    public static string UpgradeSpeed(GameState state , ref int speedCost)
    {
        if (state.Coins >= speedCost)
        {
            state.Coins -= speedCost;
            state.currentCd = Math.Max(100, state.currentCd - 20);
            speedCost += speedCost * 15 / 100;
            Console.WriteLine();
            return $"You upgraded!Your new cooldown is {state.currentCd} ms";

        }
        else
        {
            return "You dont have enough coins!";
        }
    }

    public static string UpgradeCPS(GameState state , ref int cpsCost)
    {
        if (state.Coins >= cpsCost)
        {
            state.Coins -= cpsCost;
            state.CoinsPS += 1;
            cpsCost += cpsCost * 20 / 100;
            Console.WriteLine();
            return $"You upgraded!Your new CPS is {state.CoinsPS} per sec";
        }
        else
        {
            return "You dont have enough coins!";
        }
    }
}