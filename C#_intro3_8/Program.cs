using System;

class CaesarCipher
{
    static void Main(string[] args)
    {
        Console.Write("Enter text to encrypt: ");
        string text = Console.ReadLine();

        Console.Write("Enter shift key (integer): ");
        string shiftInput = Console.ReadLine();

        if (!int.TryParse(shiftInput, out int shift))
        {
            Console.WriteLine("Error: Shift key must be an integer");
            return;
        }

        string encryptedText = Encrypt(text, shift);
        Console.WriteLine($"Encrypted text: {encryptedText}");
    }

    static string Encrypt(string text, int shift)
    {
        shift = shift % 26;
        char[] buffer = text.ToCharArray();

        for (int i = 0; i < buffer.Length; i++)
        {
            char c = buffer[i];
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                c = (char)(((c - offset + shift + 26) % 26) + offset);
                buffer[i] = c;
            }
        }
        return new string(buffer);
    }
}
