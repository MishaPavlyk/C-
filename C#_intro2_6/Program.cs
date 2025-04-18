using System;

class WordCounter
{
    static void Main()
    {
        Console.WriteLine("Word Counter");
        Console.WriteLine("------------");

        string sentence = GetSentenceFromUser();
        int wordCount = CountWords(sentence);

        Console.WriteLine("\n=== Results ===");
        Console.WriteLine($"Original sentence: \"{sentence}\"");
        Console.WriteLine($"Word count: {wordCount}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static string GetSentenceFromUser()
    {
        Console.WriteLine("\nEnter a sentence:");
        string input = Console.ReadLine()?.Trim();

        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Error: Empty input. Please enter a sentence:");
            input = Console.ReadLine()?.Trim();
        }

        return input;
    }

    static int CountWords(string sentence)
    {
        return sentence.Split(new[] { ' ', '\t', '\n', '\r' },
                            StringSplitOptions.RemoveEmptyEntries).Length;
    }
}