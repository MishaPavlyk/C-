using System;
using System.Linq;

class ElementsBelowThresholdCounter
{
    static void Main()
    {
        Console.WriteLine("Array Elements Below Threshold Counter");
        Console.WriteLine("--------------------------------------");

        int[] numbers = GetArrayFromUser();

        int threshold = GetThresholdValue();

        int count = CountElementsBelowThreshold(numbers, threshold);

        DisplayResults(numbers, threshold, count);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static int[] GetArrayFromUser()
    {
        while (true)
        {
            Console.WriteLine("\nEnter integer array elements separated by spaces:");
            string input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error: Input cannot be empty. Please try again.");
                continue;
            }

            try
            {
                return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please enter only integers separated by spaces.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: One or more numbers are too large or too small for int type.");
            }
        }
    }

    static int GetThresholdValue()
    {
        while (true)
        {
            Console.WriteLine("\nEnter the threshold value for comparison:");
            string input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, out int threshold))
            {
                return threshold;
            }

            Console.WriteLine("Error: Invalid value. Please enter an integer.");
        }
    }

    static int CountElementsBelowThreshold(int[] numbers, int threshold)
    {
        return numbers.Count(n => n < threshold);
    }

    static void DisplayResults(int[] numbers, int threshold, int count)
    {
        Console.WriteLine("\n=== Results ===");
        Console.WriteLine($"Array: [{string.Join(", ", numbers)}]");
        Console.WriteLine($"Threshold value: {threshold}");
        Console.WriteLine($"Number of elements below threshold: {count}");

        if (numbers.Length > 0)
        {
            Console.WriteLine($"Percentage below threshold: {(double)count / numbers.Length * 100:0.00}%");
        }
    }
}