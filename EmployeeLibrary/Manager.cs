namespace EmployeeLibrary
{

    public class Manager : Employee
    {
        public decimal Bonus { get; set; }


        public Manager(string firstName, string lastName, string id, decimal baseSalary, decimal bonus)
            : base(firstName, lastName, id, baseSalary)
        {
            Bonus = bonus;
        }


        public override decimal CalculateSalary()
        {
            return BaseSalary + Bonus;
        }
    }
}