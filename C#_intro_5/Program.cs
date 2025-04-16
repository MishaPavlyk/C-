using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter date in format dd.MM.yyyy (e.g. 22.12.2021):");
        string input = Console.ReadLine()?.Trim();

        if (!IsValidDate(input, out DateTime date))
        {
            Console.WriteLine("Error! Invalid date format or impossible date.");
            return;
        }

        (string season, string dayOfWeek) = GetDateInfo(date);
        Console.WriteLine($"{season} {dayOfWeek}");
    }

    public static bool IsValidDate(string input, out DateTime date)
    {
        return DateTime.TryParseExact(
            input,
            "dd.MM.yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out date
        );
    }

    public static (string season, string dayOfWeek) GetDateInfo(DateTime date)
    {
        return (
            season: CalculateSeason(date),
            dayOfWeek: date.ToString("dddd", new CultureInfo("en-US"))
        );
    }

    public static string CalculateSeason(DateTime date)
    {
        int dayOfYear = date.DayOfYear;
        bool isLeapYear = DateTime.IsLeapYear(date.Year);

        // Approximate astronomical season boundaries
        int winterStart = isLeapYear ? 356 : 355;
        int springStart = isLeapYear ? 80 : 79;
        int summerStart = isLeapYear ? 172 : 171;
        int autumnStart = isLeapYear ? 266 : 265;

        return dayOfYear switch
        {
            _ when dayOfYear >= winterStart || dayOfYear < springStart => "Winter",
            _ when dayOfYear >= springStart && dayOfYear < summerStart => "Spring",
            _ when dayOfYear >= summerStart && dayOfYear < autumnStart => "Summer",
            _ => "Autumn"
        };
    }
}