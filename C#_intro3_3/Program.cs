using System;

class CaesarCipher
{
    public static string Encrypt(string text, int shift)
    {
        char[] buffer = text.ToCharArray();

        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            if (char.IsLetter(letter))
            {
                char offset = char.IsUpper(letter) ? 'A' : 'a';
                letter = (char)(((letter + shift - offset) % 26 + 26) % 26 + offset);
            }
            buffer[i] = letter;
        }
        return new string(buffer);
    }

    public static string Decrypt(string text, int shift)
    {
        return Encrypt(text, -shift);
    }

    static void Main()
    {
        Console.WriteLine("Caesar Cipher Program");
        Console.WriteLine("1. Encrypt");
        Console.WriteLine("2. Decrypt");
        Console.Write("Choose an option (1/2): ");

        int option = int.Parse(Console.ReadLine());
        Console.Write("Enter your text: ");
        string text = Console.ReadLine();
        Console.Write("Enter shift value: ");
        int shift = int.Parse(Console.ReadLine());

        string result = "";

        if (option == 1)
        {
            result = Encrypt(text, shift);
            Console.WriteLine($"Encrypted text: {result}");
        }
        else if (option == 2)
        {
            result = Decrypt(text, shift);
            Console.WriteLine($"Decrypted text: {result}");
        }
        else
        {
            Console.WriteLine("Invalid option!");
        }
    }
}