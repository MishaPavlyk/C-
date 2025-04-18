using System;
using System.Collections.Generic;

namespace CSharpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть рядок: ");
            string input = Console.ReadLine();

            var frequencies = GetCharacterFrequencies(input);

            foreach (var pair in frequencies)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        static Dictionary<char, int> GetCharacterFrequencies(string text)
        {
            var result = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (c == ' ') continue;

                if (result.ContainsKey(c))
                    result[c]++;
                else
                    result[c] = 1;
            }

            return result;
        }
    }
}
