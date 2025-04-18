using System;
using System.Linq;

class ReverseWords
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            string reversed = string.Join(" ",
                input.Split(' ')
                .Select(word => new string(word.Reverse().ToArray())));

            Console.WriteLine("\nReversed words:");
            Console.WriteLine(reversed);
        }
        else
        {
            Console.WriteLine("No input provided.");
        }
    }
}