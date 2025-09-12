using System;

class Program
{
    static void Main()
    {
        bool Retry = true;
        
            float result;
            Console.WriteLine("\nWelcome to my basic unit converter!");
            while (Retry)
            {

            Console.WriteLine("Choose what do you wanna convert (KtM,MtK,MttF,FtMt,KgtP,PtKg,CtF,FtC): \nKilometers to Miles\nMiles to Kilometers\nMeters to Feet\nFeet to Meters\n----------------------\nWeight/Mass\nKilograms to Pounds\nPounds to Kilograms\n--------------------\nTemperature\nCelsius to Fahrenheit\nFahrenheit to Celsius\n----------------------------------");
            string convert = Console.ReadLine();

            switch (convert)
            {
                case ("KtM"):
                    {
                        Console.Write("How many Kilometer/s: ");

                        string stringKilometer = Console.ReadLine();
                        if (!float.TryParse(stringKilometer, out float kilometer))
                        {
                            Console.WriteLine("Invalid input!");
                            return;
                        }
                        result = kilometer * 0.621371f;
                        Console.WriteLine($"{kilometer} in Miles is: {result}!");
                        Console.WriteLine("Type any key to restart or q to quit");
                        char retry = Console.ReadKey().KeyChar;
                        if(retry == 'q')
                        {
                            Retry = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                        
                    }
                case ("MtK"):
                    {
                        Console.Write("How many Kilometer/s: ");

                        string stringMiles = Console.ReadLine();
                        if (!float.TryParse(stringMiles, out float Miles))
                        {
                            Console.WriteLine("Invalid input!");
                            return;
                        }
                        result = Miles / 0.621371f;
                        Console.WriteLine($"{Miles} in Kilometers is: {result}!");
                        
                        Console.WriteLine("Type any key to restart or q to quit");
                        
                        char retry = Console.ReadKey().KeyChar;
                        if (retry == 'q')
                        {
                            Retry = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                case ("MttF"):
                    {
                        Console.Write("How many Meter/s: ");

                        string stringMeters = Console.ReadLine();
                        if (!float.TryParse(stringMeters, out float Meter))
                        {
                            Console.WriteLine("Invalid input!");
                            return;
                        }
                        result = Meter * 3.28084f;
                        Console.WriteLine($"{Meter} in Feet is: {result}!");

                        Console.WriteLine("Type any key to restart or q to quit");
                        
                        char retry = Console.ReadKey().KeyChar;
                        if (retry == 'q')
                        {
                            Retry = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                case ("FtMt"):
                    {
                        Console.Write("How many Feet: ");

                        string stringFeet = Console.ReadLine();
                        if (!float.TryParse(stringFeet, out float Feet))
                        {
                            Console.WriteLine("Invalid input!");
                            return;
                        }
                        result = Feet / 3.28084f;
                        Console.WriteLine($"{Feet} in Meters is: {result}!");

                        Console.WriteLine("Type any key to restart or q to quit");

                        char retry = Console.ReadKey().KeyChar;
                        if (retry == 'q')
                        {
                            Retry = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                case ("KgtP"):
                    {
                        Console.Write("How many Kilogram/s: ");

                        string stringKilo = Console.ReadLine();
                        if (!float.TryParse(stringKilo, out float Kilo))
                        {
                            Console.WriteLine("Invalid input!");
                            return;
                        }
                        result = Kilo * 2.20462f;
                        Console.WriteLine($"{Kilo} in Pounds is: {result}!");

                        Console.WriteLine("Type any key to restart or q to quit");

                        char retry = Console.ReadKey().KeyChar;
                        if (retry == 'q')
                        {
                            Retry = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                case ("PtKg"):
                    {
                        Console.Write("How many Pound/s: ");

                        string stringPounds = Console.ReadLine();
                        if (!float.TryParse(stringPounds, out float Pounds))
                        {
                            Console.WriteLine("Invalid input!");
                            return;
                        }
                        result = Pounds / 2.20462f;
                        Console.WriteLine($"{Pounds} in Pounds is: {result}!");

                        Console.WriteLine("Type any key to restart or q to quit");

                        char retry = Console.ReadKey().KeyChar;
                        if (retry == 'q')
                        {
                            Retry = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                case ("CtF"):
                    {
                        Console.Write("How many Celsius/s: ");

                        string stringCelsius = Console.ReadLine();
                        if (!float.TryParse(stringCelsius, out float Celsius))
                        {
                            Console.WriteLine("Invalid input!");
                            return;
                        }
                        result = (Celsius * 9f / 5f) + 32f;
                        Console.WriteLine($"{Celsius} in Fahrenheit is: {result}!");

                        Console.WriteLine("Type any key to restart or q to quit");

                        char retry = Console.ReadKey().KeyChar;
                        if (retry == 'q')
                        {
                            Retry = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                case ("FtC"):
                    {
                        Console.Write("How many Fahrenheit: ");

                        string stringFahrenheit = Console.ReadLine();
                        if (!float.TryParse(stringFahrenheit, out float Fahrenheit))
                        {
                            Console.WriteLine("Invalid input!");
                            return;
                        }
                        result = (Fahrenheit - 32f) * 5 / 9;
                        Console.WriteLine($"{Fahrenheit} in Celsius is: {result}!");

                        Console.WriteLine("Type any key to restart or q to quit");

                        char retry = Console.ReadKey().KeyChar;
                        if (retry == 'q')
                        {
                            Retry = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                default:
                    {
                        Console.WriteLine("Invalid converter,goodbye");

                        Console.WriteLine("Type any key to restart or q to quit");

                        char retry = Console.ReadKey().KeyChar;
                        if (retry == 'q')
                        {
                            Retry = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

            }
        }
       
    }
}
