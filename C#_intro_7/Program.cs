using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers to define the range:");

        if (!int.TryParse(Console.ReadLine(), out int num1) ||
            !int.TryParse(Console.ReadLine(), out int num2))
        {
            Console.WriteLine("Error! Please enter valid integers.");
            return;
        }

        int start = Math.Min(num1, num2);
        int end = Math.Max(num1, num2);

        Console.WriteLine($"\nEven numbers in range from {start} to {end}:");

        List<int> evenNumbers = GetEvenNumbers(start, end);

        if (evenNumbers.Count == 0)
        {
            Console.WriteLine("No even numbers found in the specified range.");
        }
        else
        {
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }

    public static List<int> GetEvenNumbers(int start, int end)
    {
        List<int> evenNumbers = new List<int>();

        if (start % 2 != 0)
        {
            start++;
        }

        for (int i = start; i <= end; i += 2)
        {
            evenNumbers.Add(i);
        }

        return evenNumbers;
    }
}