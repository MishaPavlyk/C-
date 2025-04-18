using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();
        int vowelCount = CountVowels(input);
        Console.WriteLine($"Number of vowels: {vowelCount}");
    }

    static int CountVowels(string text)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        int count = 0;

        foreach (char c in text)
        {
            if (Array.IndexOf(vowels, c) >= 0)
            {
                count++;
            }
        }

        return count;
    }
}