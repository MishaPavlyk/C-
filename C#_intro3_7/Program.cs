using System;
using System.Collections.Generic;
using System.Text;

class TextFilter
{
    static void Main()
    {
        string text = @"To be, or not to be, that is the question,
Whether 'tis nobler in the mind to suffer
The slings and arrows of outrageous fortune,
Or to take arms against a sea of troubles,
And by opposing end them? To die: to sleep;
No more; and by a sleep to say we end
The heart-ache and the thousand natural shocks
That flesh is heir to, 'tis a consummation
Devoutly to be wish'd. To die, to sleep";

        Console.WriteLine("Original text:");
        Console.WriteLine(text);
        Console.WriteLine("\nEnter forbidden words (comma separated):");
        string forbiddenInput = Console.ReadLine();

        string[] forbiddenWords = forbiddenInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            forbiddenWords[i] = forbiddenWords[i].Trim().ToLower();
        }

        var result = FilterText(text, forbiddenWords);

        Console.WriteLine("\nFiltered text:");
        Console.WriteLine(result.FilteredText);

        Console.WriteLine("\nStatistics:");
        foreach (var stat in result.Statistics)
        {
            Console.WriteLine($"{stat.Key}: {stat.Value} replacement(s)");
        }
    }

    static FilterResult FilterText(string text, string[] forbiddenWords)
    {
        var statistics = new Dictionary<string, int>();
        foreach (var word in forbiddenWords)
        {
            statistics[word] = 0;
        }

        StringBuilder filteredText = new StringBuilder(text);

        foreach (var forbiddenWord in forbiddenWords)
        {
            int index = 0;
            while (true)
            {
                index = text.IndexOf(forbiddenWord, index, StringComparison.OrdinalIgnoreCase);
                if (index == -1) break;

                if (IsWholeWord(text, index, forbiddenWord.Length))
                {
                    filteredText.Remove(index, forbiddenWord.Length);
                    filteredText.Insert(index, new string('*', forbiddenWord.Length));
                    statistics[forbiddenWord]++;
                }
                index += forbiddenWord.Length;
            }
        }

        return new FilterResult
        {
            FilteredText = filteredText.ToString(),
            Statistics = statistics
        };
    }

    static bool IsWholeWord(string text, int index, int length)
    {
        if (index > 0 && char.IsLetterOrDigit(text[index - 1]))
            return false;

        if (index + length < text.Length && char.IsLetterOrDigit(text[index + length]))
            return false;

        return true;
    }
}

class FilterResult
{
    public string FilteredText { get; set; }
    public Dictionary<string, int> Statistics { get; set; }
}