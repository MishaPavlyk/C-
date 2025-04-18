using System;

class MatrixOperations
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMatrix Operations Menu:");
            Console.WriteLine("1. Multiply matrix by number");
            Console.WriteLine("2. Add matrices");
            Console.WriteLine("3. Multiply matrices");
            Console.WriteLine("4. Exit");
            Console.Write("Select operation (1-4): ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 4) break;

            switch (choice)
            {
                case 1:
                    MatrixScalarMultiplication();
                    break;
                case 2:
                    MatrixAddition();
                    break;
                case 3:
                    MatrixMultiplication();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    static void MatrixScalarMultiplication()
    {
        Console.WriteLine("\nMatrix Scalar Multiplication");
        var matrix = InputMatrix("Enter matrix dimensions (rows columns): ");
        Console.Write("Enter scalar value: ");
        double scalar = double.Parse(Console.ReadLine());

        Console.WriteLine("\nResult:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] *= scalar;
                Console.Write($"{matrix[i, j],8:F2}");
            }
            Console.WriteLine();
        }
    }

    static void MatrixAddition()
    {
        Console.WriteLine("\nMatrix Addition");
        var matrix1 = InputMatrix("Enter first matrix dimensions: ");
        var matrix2 = InputMatrix("Enter second matrix dimensions: ");

        if (matrix1.GetLength(0) != matrix2.GetLength(0) ||
            matrix1.GetLength(1) != matrix2.GetLength(1))
        {
            Console.WriteLine("Matrices must have the same dimensions!");
            return;
        }

        Console.WriteLine("\nResult:");
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                double sum = matrix1[i, j] + matrix2[i, j];
                Console.Write($"{sum,8:F2}");
            }
            Console.WriteLine();
        }
    }

    static void MatrixMultiplication()
    {
        Console.WriteLine("\nMatrix Multiplication");
        var matrix1 = InputMatrix("Enter first matrix dimensions (rows columns): ");
        var matrix2 = InputMatrix("Enter second matrix dimensions: ");

        if (matrix1.GetLength(1) != matrix2.GetLength(0))
        {
            Console.WriteLine("Number of columns in first matrix must equal rows in second matrix!");
            return;
        }

        Console.WriteLine("\nResult:");
        double[,] result = new double[matrix1.GetLength(0), matrix2.GetLength(1)];

        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                for (int k = 0; k < matrix1.GetLength(1); k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
                Console.Write($"{result[i, j],8:F2}");
            }
            Console.WriteLine();
        }
    }

    static double[,] InputMatrix(string prompt)
    {
        Console.Write(prompt);
        string[] dimensions = Console.ReadLine().Split();
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        double[,] matrix = new double[rows, cols];

        Console.WriteLine($"Enter {rows}x{cols} matrix values (row by row):");
        for (int i = 0; i < rows; i++)
        {
            string[] rowValues = Console.ReadLine().Split();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = double.Parse(rowValues[j]);
            }
        }

        return matrix;
    }
}