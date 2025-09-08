using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("\nWhat is your score?: ");
            string stringScore = Console.ReadLine();
            if (!int.TryParse(stringScore, out int Score))
            {
                Console.WriteLine("Invalid input!");
            }
            else if(Score > 100)
            {
                Console.WriteLine("Score cant be more then 100!");
                
            }
            else
            {
                string result = "";
                if(Score < 60)
                {
                    result = "F";
                }
                else if(Score == 67)
                {
                    Console.WriteLine("TUFF AHH SIX SEVEN");
                    continue;//continues automatically
                }
                else if (Score >= 60 && Score <= 69)
                {
                    result = "D";
                }
                else if (Score >= 70 && Score <= 79)
                {
                    result = "C";
                }
                else if (Score >= 80 && Score <= 89)
                {
                    result = "B";
                }
                else
                {
                    result = "A";
                }


                    Console.WriteLine($"Your grade is: {result}");
            }
                Console.WriteLine("Enter any key to restart or 'q' to quit");
            if(Console.ReadKey().KeyChar == 'q')
            {
                break;
            }
        }
    }
}
