using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {


        Console.Write("Введiть рядок: ");
        string input = Console.ReadLine();

        var permutations = GeneratePermutations(input);

        foreach (var permutation in permutations)
        {
            Console.WriteLine(permutation);
        }
    }

    static List<string> GeneratePermutations(string str)
    {
        var result = new List<string>();
        Permute(str.ToCharArray(), 0, str.Length - 1, result);
        return result;
    }

    static void Permute(char[] array, int start, int end, List<string> result)
    {
        if (start == end)
        {
            result.Add(new string(array));
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                Swap(ref array[start], ref array[i]);
                Permute(array, start + 1, end, result);
                Swap(ref array[start], ref array[i]);
            }
        }
    }

    static void Swap(ref char a, ref char b)
    {
        if (a == b) return;

        var temp = a;
        a = b;
        b = temp;
    }
}