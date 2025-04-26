namespace EmployeeLibrary
{
    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Id { get; set; }
        decimal BaseSalary { get; set; }

        decimal CalculateSalary();
    }
}