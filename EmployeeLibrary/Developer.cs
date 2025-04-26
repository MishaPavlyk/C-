namespace EmployeeLibrary
{

    public class Developer : Employee
    {
        public List<string> Projects { get; set; }
        public decimal ProjectBonus { get; set; }

 
        public Developer(string firstName, string lastName, string id, decimal baseSalary, decimal projectBonus)
            : base(firstName, lastName, id, baseSalary)
        {
            Projects = new List<string>();
            ProjectBonus = projectBonus;
        }

        public override decimal CalculateSalary()
        {
            return BaseSalary + (Projects.Count * ProjectBonus);
        }
    }
}