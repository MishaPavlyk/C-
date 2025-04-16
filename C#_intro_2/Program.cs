using System;

class Program
{
    static void Main()
    {
        double number = GetValidInput("Введiть число:");
        double percent = GetValidInput("Введiть вiдсоток:");

        double result = CalculatePercentage(number, percent);

        Console.WriteLine($"{percent}% вiд {number} = {result}");
    }

    static double CalculatePercentage(double number, double percent)
    {
        return number * percent / 100;
    }

    static double GetValidInput(string message)
    {
        double value;
        Console.WriteLine(message);
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Некоректне введення. Будь ласка, введiть число:");
        }
        return value;
    }
}