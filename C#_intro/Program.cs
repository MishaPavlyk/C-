using System;

public class FizzBuzz
{
    public static string GetFizzBuzzOutput(int number)
    {
        if (number < 1 || number > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 1 and 100.");
        }

        if (number % 3 == 0 && number % 5 == 0)
        {
            return "Fizz Buzz";
        }
        if (number % 3 == 0)
        {
            return "Fizz";
        }
        if (number % 5 == 0)
        {
            return "Buzz";
        }

        return number.ToString();
    }

    public static void Main()
    {
        try
        {
            Console.Write("Enter a number between 1 and 100: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                string result = GetFizzBuzzOutput(number);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}