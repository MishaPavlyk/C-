<Query Kind="Program" />

void Main()
{
    // Створюємо компанії та співробітників
    var company1 = new Company("TechSolutions");
    company1.AddEmployee(new Employee("Lionel Messi", "Developer", "231234567", "lionel.m@tech.com", 5000));
    company1.AddEmployee(new Employee("Alice Brown", "Manager", "123456789", "alice@tech.com", 6500));

    var company2 = new Company("BestGoods");
    company2.AddEmployee(new Employee("Lionel Richie", "Manager", "234567891", "lionel.r@bestgoods.com", 7500));
    company2.AddEmployee(new Employee("Diana Prince", "Accountant", "345678912", "diana@bestgoods.com", 5500));

    var companies = new List<Company> { company1, company2 };

    // Усі співробітники TechSolutions
    "Усі співробітники TechSolutions".Dump();
    company1.Employees.Dump();

    // Співробітники BestGoods з зарплатою > 5500
    "Співробітники BestGoods з зарплатою > 5500".Dump();
    company2.Employees.Where(e => e.Salary > 5500).Dump();

    // Усі менеджери
    "Усі менеджери".Dump();
    companies.SelectMany(c => c.Employees)
             .Where(e => e.Position == "Manager")
             .Dump();

    // Телефони на '23'
    "Телефони на '23'".Dump();
    companies.SelectMany(c => c.Employees)
             .Where(e => e.Phone.StartsWith("23"))
             .Dump();

    // Email починається з 'di'
    "Email починається з 'di'".Dump();
    companies.SelectMany(c => c.Employees)
             .Where(e => e.Email.StartsWith("di", StringComparison.OrdinalIgnoreCase))
             .Dump();

    // Ім'я Lionel
    "Ім'я Lionel".Dump();
    companies.SelectMany(c => c.Employees)
             .Where(e => e.FullName.StartsWith("Lionel"))
             .Dump();
}

// Класи
public class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }

    public Employee(string fullName, string position, string phone, string email, decimal salary)
    {
        FullName = fullName;
        Position = position;
        Phone = phone;
        Email = email;
        Salary = salary;
    }

    public override string ToString() => $"{FullName} | {Position} | {Phone} | {Email} | {Salary:C}";
}

public class Company
{
    public string Name { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();

    public Company(string name)
    {
        Name = name;
    }

    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

    public override string ToString() => Name;
}
