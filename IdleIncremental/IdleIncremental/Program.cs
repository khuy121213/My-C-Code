using System;
using System.Threading;

namespace IdleIncrement
{
    public class MainGame
    {
        public static void Main()
        {
            while (true) // Game restart loop
            {
                var state = new GameState();
                int speedCost = 10;
                int cpsCost = 20;
                int mpCost = 1;

                string lastMessage = "";
                int messageTime = 0;
                int lastCointick = Environment.TickCount;

                var renderer = new Renderer(80, 20);
                Console.CursorVisible = false;

                ShowTutorial(renderer);

                Console.Clear();

                // Main game loop
                while (true)
                {
                    // Handle input
                    if (Console.KeyAvailable)
                    {
                        var keyInfo = Console.ReadKey(true);
                        char key = char.ToLower(keyInfo.KeyChar);

                        switch (key)
                        {
                            case 'e':
                                lastMessage = Upgrades.UpgradeSpeed(state, ref speedCost);
                                messageTime = Environment.TickCount;
                                break;

                            case 'f':
                                lastMessage = Upgrades.UpgradeCPS(state, ref cpsCost);
                                messageTime = Environment.TickCount;
                                break;

                            case 'p':
                                if (state.Coins >= 1000)
                                {
                                    state.Coins -= 1000;
                                    state.MP++;
                                    state.CoinsPS = 1;
                                    state.currentCd = 1000;
                                    speedCost = 10;
                                    cpsCost = 20;
                                    lastMessage = $"You gained 1 MP! (Total MP: {state.MP}) - Reset!";
                                }
                                else lastMessage = "Not enough coins for MP!";
                                messageTime = Environment.TickCount;
                                break;

                            case 'm':
                                if (state.MP >= mpCost && !state.MPUpgradeIsPurchased)
                                {
                                    lastMessage = Upgrades.UpgradeMPSpeed(state, ref mpCost);
                                    messageTime = Environment.TickCount;
                                }
                                else if (state.MPUpgradeIsPurchased)
                                {
                                    lastMessage = "MP upgrade already purchased!";
                                    messageTime = Environment.TickCount;
                                }
                                else
                                {
                                    lastMessage = "Not enough MP!";
                                    messageTime = Environment.TickCount;
                                }
                                break;

                            case 'r': // Restart the game manually
                                state.Coins = 0;
                                state.CoinsPS = 1;
                                state.MP = 0;
                                state.MPUpgradeIsPurchased = false;
                                speedCost = 10;
                                cpsCost = 20;
                                lastMessage = "Game reset! Good luck!";
                                messageTime = Environment.TickCount;
                                break;
                        }

                        while (Console.KeyAvailable) Console.ReadKey(true);
                    }

                    // Passive coin tick
                    if (Environment.TickCount - lastCointick >= state.currentCd)
                    {
                        state.Coins += state.CoinsPS;
                        lastCointick = Environment.TickCount;
                    }

                    // Drawing logic
                    renderer.Clear();
                    DrawUI(renderer, state, speedCost, cpsCost, mpCost, lastMessage, messageTime);
                    renderer.Render();

                    // Win condition
                    if (state.Coins >= 1_000_000_000)
                    {
                        renderer.Clear();
                        renderer.Draw(2, 9, "You won!");
                        renderer.Draw(2, 10, "Press R to restart or any other key to quit...");
                        renderer.Render();

                        var input = Console.ReadKey(true);
                        if (char.ToLower(input.KeyChar) == 'r')
                            break;
                        else
                            return;
                    }

                    Thread.Sleep(10);
                }
            }
        }

        static void ShowTutorial(Renderer renderer)
        {
            renderer.Clear();
            renderer.Draw(2, 1, "Hello and welcome to my game!");
            renderer.Draw(2, 3, "Tutorial:");
            renderer.Draw(2, 4, "You have a coin counter and a coin-per-sec counter.");
            renderer.Draw(2, 5, "Upgrade them with:");
            renderer.Draw(2, 6, " E = Speed, F = CPS, P = MP, M = MP upgrades.");
            renderer.Draw(2, 7, "Goal: Get 1 billion coins to pay off your bad debt. Good luck!");
            renderer.Draw(2, 9, "Press any key to start...");
            renderer.Render();
            Console.ReadKey(true);
        }

        static void DrawUI(Renderer renderer, GameState state, int speedCost, int cpsCost, int mpCost, string lastMessage, int messageTime)
        {
            // Borders
            renderer.Draw(0, 0, "+" + new string('-', 78) + "+");
            renderer.Draw(0, 2, "+" + new string('-', 78) + "+");
            renderer.Draw(0, 8, "+" + new string('-', 78) + "+");
            renderer.Draw(0, 10, "+" + new string('-', 78) + "+");
            renderer.Draw(0, 13, "+" + new string('-', 78) + "+");

            // Titles
            renderer.Draw(2, 1, "Idle Incremental Game");
            renderer.Draw(2, 3, "Stats");
            renderer.Draw(40, 3, "Upgrades");
            renderer.Draw(2, 9, "Controls: E=Speed | F=CPS | P=MP | M=MP Upgrade | R=Restart");
            renderer.Draw(2, 11, "Message:");

            // Dynamic Info
            renderer.Draw(2, 4, $"Coins: {state.Coins,15}");
            renderer.Draw(2, 5, $"CPS:   {state.CoinsPS,15}");
            renderer.Draw(2, 6, $"Speed: {state.currentCd,15} ms");
            renderer.Draw(2, 7, $"MP:    {state.MP,15}");

            renderer.Draw(40, 4, $"(E) Speed: {speedCost,10} Coins");
            renderer.Draw(40, 5, $"(F) CPS:   {cpsCost,10} Coins");
            renderer.Draw(40, 6, $"(P) MP:    {1000,10} Coins");
            renderer.Draw(40, 7, $"(M) MP Upg:{mpCost,10} MP");

            if (Environment.TickCount - messageTime < 1000)
            {
                renderer.Draw(2, 12, lastMessage);
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
    public static string UpgradeSpeed(GameState state, ref int speedCost)
    {
        if (state.Coins >= speedCost)
        {
            state.Coins -= speedCost;
            state.currentCd = Math.Max(100, state.currentCd - 20);
            speedCost += speedCost * 15 / 100;
            return $"Speed upgraded! Cooldown: {state.currentCd} ms";
        }
        return "Not enough coins!";
    }

    public static string UpgradeCPS(GameState state, ref int cpsCost)
    {
        if (state.Coins >= cpsCost)
        {
            state.Coins -= cpsCost;
            state.CoinsPS++;
            cpsCost += cpsCost * 20 / 100;
            return $"CPS upgraded! CPS: {state.CoinsPS}";
        }
        return "Not enough coins!";
    }

    public static string UpgradeMPSpeed(GameState state, ref int mpCost)
    {
        if (state.MP >= mpCost)
        {
            state.MP -= mpCost;
            state.CoinsPS += 4;
            state.MPUpgradeIsPurchased = true;
            return $"MP upgrade purchased! CPS: {state.CoinsPS}";
        }
        return "Not enough MP!";
    }
}
