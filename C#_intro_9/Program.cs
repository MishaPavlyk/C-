using System;

class PerfectNumberChecker
{
    static void Main()
    {
        Console.Write("Enter a number to check if it's perfect: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int number) || number <= 0)
        {
            Console.WriteLine("Error! Please enter a positive integer.");
            return;
        }

        if (IsPerfectNumber(number))
        {
            Console.WriteLine($"{number} is a perfect number.");
        }
        else
        {
            Console.WriteLine($"{number} is NOT a perfect number.");
        }
    }

    public static bool IsPerfectNumber(int number)
    {
        if (number <= 1)
            return false;

        int sum = 1; // 1 is a divisor for all numbers > 1

        // Check divisors up to the square root of the number
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                sum += i;
                int complement = number / i;
                if (complement != i)
                    sum += complement;
            }
        }

        return sum == number;
    }
}