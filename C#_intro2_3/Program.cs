using System;
using System.Linq;

class SequenceCounter
{
    static void Main()
    {
        Console.WriteLine("Sequence Occurrence Counter");
        Console.WriteLine("--------------------------");

        int[] searchSequence = GetUserSequence();

        int[] targetArray = GetTargetArray();

        int count = CountSequenceOccurrences(searchSequence, targetArray);

        DisplayResults(searchSequence, targetArray, count);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static int[] GetUserSequence()
    {
        while (true)
        {
            Console.WriteLine("\nEnter three integers separated by spaces (the sequence to search for):");
            string input = Console.ReadLine()?.Trim();

            try
            {
                int[] sequence = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

                if (sequence.Length == 3)
                {
                    return sequence;
                }

                Console.WriteLine("Error: Please enter exactly three numbers.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please enter three integers separated by spaces.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: One or more numbers are too large or too small for int type.");
            }
        }
    }

    static int[] GetTargetArray()
    {
        while (true)
        {
            Console.WriteLine("\nEnter the array of integers to search in (separated by spaces):");
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

    static int CountSequenceOccurrences(int[] sequence, int[] array)
    {
        if (sequence.Length != 3 || array.Length < 3)
        {
            return 0;
        }

        int count = 0;

        for (int i = 0; i <= array.Length - 3; i++)
        {
            if (array[i] == sequence[0] &&
                array[i + 1] == sequence[1] &&
                array[i + 2] == sequence[2])
            {
                count++;
            }
        }

        return count;
    }

    static void DisplayResults(int[] sequence, int[] array, int count)
    {
        Console.WriteLine("\n=== Results ===");
        Console.WriteLine($"Search sequence: [{string.Join(", ", sequence)}]");
        Console.WriteLine($"Target array: [{string.Join(", ", array)}]");
        Console.WriteLine($"Number of occurrences: {count}");
    }
}