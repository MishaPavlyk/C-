using System;

class MatrixMultiplier
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of rows: ");
        string rowInput = Console.ReadLine();

        Console.Write("Enter number of columns: ");
        string colInput = Console.ReadLine();

        Console.Write("Enter multiplier: ");
        string multInput = Console.ReadLine();

        if (!int.TryParse(rowInput, out int rows) ||
            !int.TryParse(colInput, out int cols) ||
            !double.TryParse(multInput, out double multiplier))
        {
            Console.WriteLine("Error: All parameters must be numbers");
            return;
        }

        if (rows <= 0 || cols <= 0)
        {
            Console.WriteLine("Error: Rows and columns must be positive integers");
            return;
        }

        double[,] matrix = GenerateRandomMatrix(rows, cols);

        Console.WriteLine("\nOriginal Matrix:");
        PrintMatrix(matrix);

        MultiplyMatrix(ref matrix, multiplier);

        Console.WriteLine($"\nMatrix multiplied by {multiplier}:");
        PrintMatrix(matrix);
    }

    static double[,] GenerateRandomMatrix(int rows, int cols)
    {
        Random rand = new Random();
        double[,] matrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = Math.Round(rand.NextDouble() * 100, 2);
            }
        }
        return matrix;
    }

    static void MultiplyMatrix(ref double[,] matrix, double multiplier)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = Math.Round(matrix[i, j] * multiplier, 2);
            }
        }
    }

    static void PrintMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],8:F2} ");
            }
            Console.WriteLine();
        }
    }
}
