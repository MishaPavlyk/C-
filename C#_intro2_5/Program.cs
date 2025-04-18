using System;

class TwoDArrayAnalyzer
{
    static void Main()
    {
        Console.WriteLine("2D Array Min/Max Finder");
        Console.WriteLine("-----------------------");

        (int rows, int cols) = GetArrayDimensions();

        int[,] array = CreateAndFill2DArray(rows, cols);

        (int min, int max) = FindMinMax(array);

        DisplayResults(array, min, max);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static (int rows, int cols) GetArrayDimensions()
    {
        int rows = GetPositiveInteger("Enter number of rows: ");
        int cols = GetPositiveInteger("Enter number of columns: ");
        return (rows, cols);
    }

    static int GetPositiveInteger(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                return number;
            }
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    static int[,] CreateAndFill2DArray(int rows, int cols)
    {
        int[,] array = new int[rows, cols];
        Console.WriteLine($"\nEnter {rows}x{cols} array values (row by row):");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = GetInteger($"Enter value for [{i},{j}]: ");
            }
        }

        return array;
    }

    static int GetInteger(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                return number;
            }
            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }

    static (int min, int max) FindMinMax(int[,] array)
    {
        if (array.Length == 0)
            throw new ArgumentException("Array cannot be empty");

        int min = array[0, 0];
        int max = array[0, 0];

        foreach (int value in array)
        {
            if (value < min) min = value;
            if (value > max) max = value;
        }

        return (min, max);
    }

    static void DisplayResults(int[,] array, int min, int max)
    {
        Console.WriteLine("\n=== 2D Array ===");
        Print2DArray(array);

        Console.WriteLine("\n=== Results ===");
        Console.WriteLine($"Minimum value: {min}");
        Console.WriteLine($"Maximum value: {max}");
    }

    static void Print2DArray(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{array[i, j],5}"); 
            }
            Console.WriteLine();
        }
    }
}
