using System;
using System.Linq;

class CommonElementsFinder
{
    static void Main()
    {
        Console.WriteLine("Common Elements Finder");
        Console.WriteLine("----------------------");

        Console.WriteLine("\nEnter elements for the first array (separated by spaces):");
        int[] arrayM = GetArrayFromUser();

        Console.WriteLine("\nEnter elements for the second array (separated by spaces):");
        int[] arrayN = GetArrayFromUser();

        int[] commonElements = FindCommonElements(arrayM, arrayN);

        DisplayResults(arrayM, arrayN, commonElements);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static int[] GetArrayFromUser()
    {
        while (true)
        {
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
                Console.WriteLine("Error: One or more numbers are too large or too small for int type.");
            }
        }
    }

    static int[] FindCommonElements(int[] arrayM, int[] arrayN)
    {
        return arrayM.Intersect(arrayN).ToArray();
    }

    static void DisplayResults(int[] arrayM, int[] arrayN, int[] commonElements)
    {
        Console.WriteLine("\n=== Results ===");
        Console.WriteLine($"First array ({arrayM.Length} elements): [{string.Join(", ", arrayM)}]");
        Console.WriteLine($"Second array ({arrayN.Length} elements): [{string.Join(", ", arrayN)}]");

        if (commonElements.Length == 0)
        {
            Console.WriteLine("No common elements found.");
        }
        else
        {
            Console.WriteLine($"Common elements ({commonElements.Length}): [{string.Join(", ", commonElements)}]");
        }
    }
}