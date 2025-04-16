using System;

class ArmstrongNumberChecker
{
    static void Main()
    {
        Console.Write("Enter a number to check if it's an Armstrong number: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int number) || number < 0)
        {
            Console.WriteLine("Invalid input! Please enter a positive integer.");
            return;
        }

        if (IsArmstrongNumber(number))
        {
            Console.WriteLine($"{number} is an Armstrong number.");
        }
        else
        {
            Console.WriteLine($"{number} is NOT an Armstrong number.");
        }
    }

    public static bool IsArmstrongNumber(int number)
    {
        int originalNumber = number;
        int sum = 0;
        int digitCount = (int)Math.Floor(Math.Log10(number)) + 1;

        while (number > 0)
        {
            int digit = number % 10;
            sum += (int)Math.Pow(digit, digitCount);
            number /= 10;
        }

        return sum == originalNumber;
    }
}