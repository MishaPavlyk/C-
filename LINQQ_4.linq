<Query Kind="Program" />

void Main()
{
    int[] numbers = { 121, 75, 81, 44, 100, 33 };

    // Сортування за зростанням суми цифр
    var ascending = numbers.OrderBy(n => SumOfDigits(n)).ToArray();
    "Сортування за зростанням суми цифр".Dump();
    ascending.Dump();

    // Сортування за спаданням суми цифр
    var descending = numbers.OrderByDescending(n => SumOfDigits(n)).ToArray();
    "Сортування за спаданням суми цифр".Dump();
    descending.Dump();
}

// Метод для обчислення суми цифр числа
int SumOfDigits(int number)
{
    return Math.Abs(number)
               .ToString()
               .Sum(c => c - '0'); // перетворюємо символ у цифру
}
