using System;

class TemperatureConverter
{
    static void Main()
    {
        Console.WriteLine("Temperature Converter");
        Console.WriteLine("1. Fahrenheit to Celsius");
        Console.WriteLine("2. Celsius to Fahrenheit");
        Console.Write("Choose conversion (1 or 2): ");

        string choice = Console.ReadLine();

        Console.Write("Enter temperature: ");
        if (!double.TryParse(Console.ReadLine(), out double temperature))
        {
            Console.WriteLine("Invalid temperature value!");
            return;
        }

        double convertedTemp;
        string result;

        switch (choice)
        {
            case "1":
                convertedTemp = FahrenheitToCelsius(temperature);
                result = $"{temperature}°F = {convertedTemp:0.0}°C";
                break;
            case "2":
                convertedTemp = CelsiusToFahrenheit(temperature);
                result = $"{temperature}°C = {convertedTemp:0.0}°F";
                break;
            default:
                Console.WriteLine("Invalid choice! Please select 1 or 2.");
                return;
        }

        Console.WriteLine(result);
    }

    public static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    public static double CelsiusToFahrenheit(double celsius)
    {
        return celsius * 9 / 5 + 32;
    }
}