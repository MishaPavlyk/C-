<Query Kind="Program" />

public class Firm
{
    public string Name { get; set; }
    public DateTime FoundingDate { get; set; }
    public string BusinessProfile { get; set; }
    public string DirectorFullName { get; set; }
    public int EmployeeCount { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $"Назва: {Name}, Дата заснування: {FoundingDate.ToShortDateString()}, " +
               $"Профіль: {BusinessProfile}, Директор: {DirectorFullName}, " +
               $"Співробітники: {EmployeeCount}, Адреса: {Address}";
    }
}

class Program
{
    static void Main()
    {
        var firms = new List<Firm>
        {
            new Firm { Name = "FoodExpress", FoundingDate = new DateTime(2010, 5, 15), BusinessProfile = "Marketing", DirectorFullName = "John White", EmployeeCount = 150, Address = "London, UK" },
            new Firm { Name = "TechSolutions", FoundingDate = new DateTime(2015, 8, 20), BusinessProfile = "IT", DirectorFullName = "Alice Black", EmployeeCount = 200, Address = "New York, USA" },
            new Firm { Name = "HealthyFood", FoundingDate = new DateTime(2020, 3, 10), BusinessProfile = "Food", DirectorFullName = "Bob Johnson", EmployeeCount = 80, Address = "Berlin, Germany" },
            new Firm { Name = "MarketingPro", FoundingDate = new DateTime(2018, 1, 5), BusinessProfile = "Marketing", DirectorFullName = "Emily White", EmployeeCount = 120, Address = "Paris, France" },
            new Firm { Name = "ITInnovations", FoundingDate = DateTime.Now.AddDays(-123), BusinessProfile = "IT", DirectorFullName = "Michael Brown", EmployeeCount = 300, Address = "London, UK" }
        };


        Console.WriteLine("1. Всі фірми:");
        firms.ForEach(Console.WriteLine);


        Console.WriteLine("\n2. Фірми з 'Food' у назві:");
        firms.Where(f => f.Name.Contains("Food")).ToList().ForEach(Console.WriteLine);


        Console.WriteLine("\n3. Фірми у галузі маркетингу:");
        firms.Where(f => f.BusinessProfile == "Marketing").ToList().ForEach(Console.WriteLine);


        Console.WriteLine("\n4. Фірми у маркетингу або IT:");
        firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT").ToList().ForEach(Console.WriteLine);


        Console.WriteLine("\n5. Фірми з >100 співробітників:");
        firms.Where(f => f.EmployeeCount > 100).ToList().ForEach(Console.WriteLine);


        Console.WriteLine("\n6. Фірми з 100-300 співробітників:");
        firms.Where(f => f.EmployeeCount is >= 100 and <= 300).ToList().ForEach(Console.WriteLine);


        Console.WriteLine("\n7. Фірми в Лондоні:");
        firms.Where(f => f.Address.Contains("London")).ToList().ForEach(Console.WriteLine);


        Console.WriteLine("\n8. Фірми з директором White:");
        firms.Where(f => f.DirectorFullName.Contains("White")).ToList().ForEach(Console.WriteLine);


        Console.WriteLine("\n9. Фірми засновані >2 роки тому:");
        firms.Where(f => (DateTime.Now - f.FoundingDate).TotalDays > 365 * 2).ToList().ForEach(Console.WriteLine);


        Console.WriteLine("\n10. Фірми, засновані 123 дні тому:");
        firms.Where(f => (DateTime.Now - f.FoundingDate).TotalDays == 123).ToList().ForEach(Console.WriteLine);


        Console.WriteLine("\n11. Фірми: директор Black, назва містить White:");
        firms.Where(f => f.DirectorFullName.Contains("Black") && f.Name.Contains("White")).ToList().ForEach(Console.WriteLine);
    }
}