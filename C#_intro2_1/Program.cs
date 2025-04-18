using System;
using System.Collections.Generic;
using System.Linq;

class EnhancedArrayAnalyzer
{
    static void Main()
    {
        Console.WriteLine("Enhanced Array Analyzer");
        Console.WriteLine("-----------------------");

        int[] numbers = GetValidatedArrayFromUser();

        var analysisResults = AnalyzeArray(numbers);

        DisplayResults(analysisResults, numbers);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static int[] GetValidatedArrayFromUser()
    {
        while (true)
        {
            Console.WriteLine("Enter integer array elements separated by spaces (e.g., '1 2 3 4'):");
            string input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error: Input cannot be empty. Please try again.");
                continue;
            }

            try
            {
                return input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please enter only integers separated by spaces.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: One or more numbers are too large or too small for an integer.");
            }
        }
    }

    static (int evenCount, int oddCount, int uniqueCount, int[] uniqueElements) AnalyzeArray(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            return (0, 0, 0, Array.Empty<int>());

        int evenCount = numbers.Count(n => n % 2 == 0);
        int oddCount = numbers.Length - evenCount;
        int[] uniqueElements = numbers.Distinct().ToArray();

        return (evenCount, oddCount, uniqueElements.Length, uniqueElements);
    }

    static void DisplayResults((int even, int odd, int unique, int[] uniqueElements) results, int[] originalArray)
    {
        Console.WriteLine("\n=== Analysis Results ===");
        Console.WriteLine($"Original array: {string.Join(", ", originalArray)}");
        Console.WriteLine($"Total elements: {originalArray.Length}");
        Console.WriteLine($"Even numbers: {results.even}");
        Console.WriteLine($"Odd numbers: {results.odd}");
        Console.WriteLine($"Unique numbers: {results.unique}");
        Console.WriteLine($"Unique elements list: {string.Join(", ", results.uniqueElements)}");

        Console.WriteLine("\nAdditional Statistics:");
        Console.WriteLine($"Even percentage: {(double)results.even / originalArray.Length * 100:0.00}%");
        Console.WriteLine($"Odd percentage: {(double)results.odd / originalArray.Length * 100:0.00}%");
    }
}