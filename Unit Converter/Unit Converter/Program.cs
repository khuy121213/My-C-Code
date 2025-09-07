using System;

class Program
{
    static void Main()
    {
        float result;
        Console.WriteLine("Welcome to my basic unit converter!");

        Console.WriteLine("Choose what do you wanna convert (KtM,MtK,MttF,FtMt,KtP,PtK,CtF,FtC): \nKilometers to Miles\nMiles to Kilometers\nMeters to Feet\nFeet to Meters\nWeight/Mass\nKilograms to Pounds\nPounds to Kilograms\nTemperature\nCelsius to Fahrenheit\nFahrenheit to Celsius\n----------------------------------");
        string convert = Console.ReadLine();

        switch (convert)
        {
            case ("KtM"):
                {
                    Console.Write("How many Kilometers: ");

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
            
        }
    }
}
