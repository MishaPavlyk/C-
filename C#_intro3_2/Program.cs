using System;

class Program
{
    static void Main()
    {
        int[,] matrix = new int[5, 5];
        Random rnd = new Random();

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix[i, j] = rnd.Next(-100, 101);
                Console.Write($"{matrix[i, j],5} ");
            }
            Console.WriteLine();
        }

        int min = matrix[0, 0], max = matrix[0, 0];
        int minRow = 0, minCol = 0, maxRow = 0, maxCol = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minRow = i;
                    minCol = j;
                }
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxRow = i;
                    maxCol = j;
                }
            }
        }

        Console.WriteLine($"\nMin: {min} at [{minRow},{minCol}]");
        Console.WriteLine($"Max: {max} at [{maxRow},{maxCol}]");

        int sum = 0;
        bool startSumming = false;
        bool reverseDirection = false;

        for (int i = 0; i < 5; i++)
        {
            int start = reverseDirection ? 4 : 0;
            int end = reverseDirection ? -1 : 5;
            int step = reverseDirection ? -1 : 1;

            for (int j = start; j != end; j += step)
            {
                if ((i == minRow && j == minCol) || (i == maxRow && j == maxCol))
                {
                    if (startSumming)
                    {
                        startSumming = false;
                        break;
                    }
                    else
                    {
                        startSumming = true;
                        continue;
                    }
                }

                if (startSumming)
                {
                    sum += matrix[i, j];
                }
            }

            reverseDirection = !reverseDirection;
        }

        Console.WriteLine($"\nSum between min and max: {sum}");
    }
}