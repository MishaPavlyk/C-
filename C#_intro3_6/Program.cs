using System;
using System.Text;

class SentenceCapitalizer
{
    static void Main()
    {
        Console.WriteLine("Enter your text:");
        string input = Console.ReadLine();

        string result = CapitalizeSentences(input);

        Console.WriteLine("\nCapitalized text:");
        Console.WriteLine(result);
    }

    static string CapitalizeSentences(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        StringBuilder result = new StringBuilder();
        bool capitalizeNext = true;

        for (int i = 0; i < text.Length; i++)
        {
            char currentChar = text[i];

            if (capitalizeNext && char.IsLetter(currentChar))
            {
                result.Append(char.ToUpper(currentChar));
                capitalizeNext = false;
            }
            else
            {
                result.Append(currentChar);
            }

            if (currentChar == '.' || currentChar == '!' || currentChar == '?')
            {
                capitalizeNext = true;
            }
        }

        return result.ToString();
    }
}