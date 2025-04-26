namespace EmployeeLibrary
{

    public abstract class Employee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public decimal BaseSalary { get; set; }


        protected Employee(string firstName, string lastName, string id, decimal baseSalary)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            BaseSalary = baseSalary;
        }

        public abstract decimal CalculateSalary();
    }
}