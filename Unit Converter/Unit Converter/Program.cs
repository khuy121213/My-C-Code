using System;

class Program
{
    static void Main()
    {
        float result;
        Console.WriteLine("Welcome to my basic unit converter!");

        Console.WriteLine("Choose what do you wanna convert (KtM,MtK,MttF,FtMt,KgtP,PtKg,CtF,FtC): \nKilometers to Miles\nMiles to Kilometers\nMeters to Feet\nFeet to Meters\nWeight/Mass\nKilograms to Pounds\nPounds to Kilograms\nTemperature\nCelsius to Fahrenheit\nFahrenheit to Celsius\n----------------------------------");
        string convert = Console.ReadLine();

        switch (convert)
        {
            case ("KtM"):
                {
                    Console.Write("How many Kilometer/s: ");

                    string stringKilometer = Console.ReadLine();
                    if(!float.TryParse(stringKilometer, out float kilometer))
                    {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                    result = kilometer * 0.621371f;
                    Console.WriteLine($"{kilometer} in Miles is: {result}!");
                    break;
                }
            case ("MtK"):
                {
                    Console.Write("How many Kilometer/s: ");

                    string stringMiles = Console.ReadLine();
                    if(!float.TryParse(stringMiles, out float Miles))
                    {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                    result = Miles / 0.621371f;
                    Console.WriteLine($"{Miles} in Kilometers is: {result}!");
                    break;
                }
            case ("MttF"):
                {
                    Console.Write("How many Meter/s: ");

                    string stringMeters = Console.ReadLine();
                    if(!float.TryParse(stringMeters, out float Meter))
                    {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                    result = Meter * 3.28084f;
                    Console.WriteLine($"{Meter} in Feet is: {result}!");
                    break;
                }
            case ("FtMt"):
                {
                    Console.Write("How many Feet: ");

                    string stringFeet = Console.ReadLine();
                    if(!float.TryParse(stringFeet, out float Feet))
                    {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                    result = Feet / 3.28084f;
                    Console.WriteLine($"{Feet} in Meters is: {result}!");
                    break;
                }
            case ("KgtP"):
                {
                    Console.Write("How many Kilogram/s: ");

                    string stringKilo = Console.ReadLine();
                    if(!float.TryParse(stringKilo, out float Kilo))
                    {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                    result = Kilo * 2.20462f;
                    Console.WriteLine($"{Kilo} in Pounds is: {result}!");
                    break;
                }
            
        }
    }
}
