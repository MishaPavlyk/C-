using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a 6-digit number: ");
        string input = Console.ReadLine();

        // Validate 6-digit number
        if (input.Length != 6 || !int.TryParse(input, out int number))
        {
            Console.WriteLine("Error! Please enter a valid 6-digit number.");
            return;
        }

        Console.Write("Enter first digit position to swap (1-6): ");
        if (!int.TryParse(Console.ReadLine(), out int position1) || position1 < 1 || position1 > 6)
        {
            Console.WriteLine("Error! Please enter a digit position between 1 and 6.");
            return;
        }

        Console.Write("Enter second digit position to swap (1-6): ");
        if (!int.TryParse(Console.ReadLine(), out int position2) || position2 < 1 || position2 > 6)
        {
            Console.WriteLine("Error! Please enter a digit position between 1 and 6.");
            return;
        }

        // Perform digit swap
        char[] digits = input.ToCharArray();
        char temp = digits[position1 - 1];
        digits[position1 - 1] = digits[position2 - 1];
        digits[position2 - 1] = temp;

        string result = new string(digits);
        Console.WriteLine($"Result: {result}");
    }
}