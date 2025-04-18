using System;

class SubstringCounter
{
    static void Main()
    {
        Console.WriteLine("Enter the source string:");
        string source = Console.ReadLine();

        Console.WriteLine("Enter the substring to search:");
        string substring = Console.ReadLine();

        int count = CountSubstringOccurrences(source, substring);
        Console.WriteLine($"Search result: {count}");
    }

    static int CountSubstringOccurrences(string source, string substring)
    {
        int count = 0;
        int index = 0;

        while ((index = source.IndexOf(substring, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            index += substring.Length;
            count++;
        }

        return count;
    }
}