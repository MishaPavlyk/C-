using System;

class Program
{
    static void Main()
    {
        int[] digits = new int[4];

        // Отримання цифр від користувача
        for (int i = 0; i < 4; i++)
        {
            Console.Write($"Введіть цифру {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out digits[i]) || digits[i] < 0 || digits[i] > 9)
            {
                Console.WriteLine("Помилка! Введіть одну цифру (0-9):");
                Console.Write($"Введіть цифру {i + 1}: ");
            }
        }

        // Формування числа
        int number = CombineDigits(digits[0], digits[1], digits[2], digits[3]);

        Console.WriteLine($"Сформоване число: {number}");
    }

    public static int CombineDigits(int d1, int d2, int d3, int d4)
    {
        return d1 * 1000 + d2 * 100 + d3 * 10 + d4;
    }
}