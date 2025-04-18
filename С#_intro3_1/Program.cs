using System;

class Program
{
    static void Main()
    {
        // Declare arrays
        int[] arrayA = new int[5];
        double[,] arrayB = new double[3, 4];

        // Fill arrayA with user input
        Console.WriteLine("Enter 5 integers for array A:");
        for (int i = 0; i < arrayA.Length; i++)
        {
            Console.Write($"A[{i}] = ");
            arrayA[i] = int.Parse(Console.ReadLine());
        }

        // Fill arrayB with random numbers
        Random rnd = new Random();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                arrayB[i, j] = rnd.NextDouble() * 100; // Random numbers between 0 and 100
            }
        }

        // Display arrayA
        Console.WriteLine("\nArray A:");
        foreach (int num in arrayA)
        {
            Console.Write(num + " ");
        }

        // Display arrayB as a matrix
        Console.WriteLine("\n\nArray B:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"{arrayB[i, j]:F2}\t");
            }
            Console.WriteLine();
        }

        // Find maximum element in both arrays
        double maxA = arrayA[0];
        foreach (int num in arrayA)
        {
            if (num > maxA) maxA = num;
        }

        double maxB = arrayB[0, 0];
        foreach (double num in arrayB)
        {
            if (num > maxB) maxB = num;
        }

        double globalMax = Math.Max(maxA, maxB);

        // Find minimum element in both arrays
        double minA = arrayA[0];
        foreach (int num in arrayA)
        {
            if (num < minA) minA = num;
        }

        double minB = arrayB[0, 0];
        foreach (double num in arrayB)
        {
            if (num < minB) minB = num;
        }

        double globalMin = Math.Min(minA, minB);

        // Calculate total sum of all elements
        double sumA = 0;
        foreach (int num in arrayA)
        {
            sumA += num;
        }

        double sumB = 0;
        foreach (double num in arrayB)
        {
            sumB += num;
        }

        double totalSum = sumA + sumB;

        // Calculate total product of all elements
        double productA = 1;
        foreach (int num in arrayA)
        {
            productA *= num;
        }

        double productB = 1;
        foreach (double num in arrayB)
        {
            productB *= num;
        }

        double totalProduct = productA * productB;

        // Sum of even elements in arrayA
        int sumEvenA = 0;
        foreach (int num in arrayA)
        {
            if (num % 2 == 0) sumEvenA += num;
        }

        // Sum of odd columns in arrayB (considering 0-based indexing)
        double sumOddColumnsB = 0;
        for (int j = 0; j < 4; j++)
        {
            if (j % 2 != 0) // columns with indices 1 and 3 (2nd and 4th columns)
            {
                for (int i = 0; i < 3; i++)
                {
                    sumOddColumnsB += arrayB[i, j];
                }
            }
        }

        // Display results
        Console.WriteLine("\nResults:");
        Console.WriteLine($"Maximum element: {globalMax}");
        Console.WriteLine($"Minimum element: {globalMin}");
        Console.WriteLine($"Total sum of all elements: {totalSum:F2}");
        Console.WriteLine($"Total product of all elements: {totalProduct:E2}");
        Console.WriteLine($"Sum of even elements in array A: {sumEvenA}");
        Console.WriteLine($"Sum of odd columns in array B: {sumOddColumnsB:F2}");
    }
}