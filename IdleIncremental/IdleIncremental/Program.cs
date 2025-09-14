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
        Console.Clear(); // Fix the capitalization
        int speedCost = 10;
        int cpsCost = 20;
        int mpCost = 1; // Add mpCost variable
        string lastMessage = "";
        int messageTime = 0;
        int lastCointick = Environment.TickCount;
        Console.WriteLine("Hello and welcome to my game, here is the tutorial: \nYou have a coin counter and a coin per sec counter, \nyou can upgrade them by pressing E for speed and F for CPS. \nThe goal is to get 1 billion coins to pay off your very bad financial debt. \nGood luck!");

        Console.Write("Press any key to start the game!:");
        Console.ReadKey(true);
        for (int i = 0; i < 7; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        Console.WriteLine("Press E to upgrade speed , F to upgrade coin/s per sec , P to get MP , M for MP upgrades.");
        while (true)
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("\r" + new string(' ', 50)); // clear the line
            Console.SetCursorPosition(0, 1);
            Console.Write($"\rCoins: {state.Coins}");

            Console.SetCursorPosition(0, 4);
            Console.Write("\r" + new string(' ', 50));  // clear line
            Console.SetCursorPosition(0, 4);
            Console.Write($"\r Stats: Speed: {state.currentCd} ms , CPS: {state.CoinsPS} coin per sec");

            Console.SetCursorPosition(0, 3);
            Console.Write("\r" + new string(' ', 50));  // clear line
            Console.SetCursorPosition(0, 3);
            Console.Write("Prices: Speed: " + speedCost + " , CPS: " + cpsCost + " , MP Upgrade: 1");

            Console.SetCursorPosition(0, 5);
            Console.Write("\r" + new string(' ', 50));  // clear line
            Console.SetCursorPosition(0, 5);
            Console.Write($"MP: {state.MP}");

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
                else if (key == 'p')
                {
                    if(state.Coins >= 1000)
                    {
                        state.Coins -= 1000;
                        state.MP += 1;
                        Console.WriteLine($"You got {state.MP} MP!");
                        Console.WriteLine("Your stats and upgrades will be reset"); // Add missing semicolon
                        state.CoinsPS = 1;
                        state.currentCd = 1000;
                        state.Coins = 0;
                        // Reset upgrade costs as well
                        speedCost = 10;
                        cpsCost = 20;
                    }
                    else
                    {
                        Console.WriteLine("You dont have enough coins!");
                    }
                }
                else if(key == 'm')
                {
                    if(state.MP >= 1 && state.MPUpgradeIsPurchased == false)
                    {
                        lastMessage = Upgrades.UpgradeMPSpeed(state , ref mpCost);
                        messageTime = Environment.TickCount;
                    }
                    else if(state.MP >= 1 && state.MPUpgradeIsPurchased == true)
                    {
                        Console.WriteLine("You have alrady purchased this upgrade!You can only buy one of each MP upgrade"); // Add missing semicolon
                    }
                    else
                    {
                        Console.WriteLine("You dont have enough MP!");
                    }
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
            Console.SetCursorPosition(0, 2);
            Console.Write("\r" + new string(' ', 50));
            int currentTime = Environment.TickCount;
            if ( currentTime - messageTime < 1000)
            {
                Console.SetCursorPosition(0, 2);
                Console.Write(lastMessage);
            }
            Thread.Sleep(10);

            

            if (state.Coins >= 1000000000)

            {
                Console.WriteLine("You won!");
                Console.WriteLine("Press R to restart or any other key to exit");
                var input = Console.ReadKey();
                if(char.ToLower(input.KeyChar) == 'r')
                {
                    Main();
                }
                else
                {
                    break;
                }
                    
            }
        }
        }
    }

public class GameState
{
    public int currentCd = 1000;
    public int Coins { get; set; } = 0;
    public int CoinsPS { get; set; } = 1;
    public int MP { get; set; } = 0;
    public bool MPUpgradeIsPurchased { get; set; } = false;
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

    public static string UpgradeMPSpeed(GameState state , ref int mpCost)
    {
        if (state.MP >= mpCost)
        {
            state.MP -= mpCost;
            state.CoinsPS += 4;
            state.MPUpgradeIsPurchased = true;
            Console.WriteLine();
            return $"You upgraded!Your new CPS is {state.CoinsPS} per sec";
        }
        else
        {
            return "You dont have enough coins!";
        }
    }

}
//Made by Khachuy