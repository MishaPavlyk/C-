using EmployeeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagerApp
{
    class Program
    {
        private static EmployeeService _employeeService = new EmployeeService();

        static void Main(string[] args)
        {
            Console.WriteLine("Employee Management System");
            Console.WriteLine("--------------------------");

            while (true)
            {
                DisplayMenu();
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        ViewAllEmployees();
                        break;
                    case "3":
                        UpdateEmployee();
                        break;
                    case "4":
                        RemoveEmployee();
                        break;
                    case "5":
                        CalculateTotalSalaries();
                        break;
                    case "6":
                        ViewEmployeesByType();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Remove Employee");
            Console.WriteLine("5. Calculate Total Salaries");
            Console.WriteLine("6. View Employees by Type");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
        }

        static void AddEmployee()
        {
            Console.WriteLine("\nAdd Employee");
            Console.WriteLine("------------");

            Console.Write("Enter employee type (1 - Manager, 2 - Developer): ");
            var typeChoice = Console.ReadLine();

            Console.Write("First Name: ");
            var firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();

            Console.Write("ID: ");
            var id = Console.ReadLine();

            Console.Write("Base Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out var baseSalary))
            {
                Console.WriteLine("Invalid salary amount.");
                return;
            }

            try
            {
                if (typeChoice == "1")
                {
                    Console.Write("Bonus: ");
                    if (!decimal.TryParse(Console.ReadLine(), out var bonus))
                    {
                        Console.WriteLine("Invalid bonus amount.");
                        return;
                    }

                    var manager = new Manager(firstName, lastName, id, baseSalary, bonus);
                    _employeeService.AddEmployee(manager);
                }
                else if (typeChoice == "2")
                {
                    Console.Write("Project Bonus (per project): ");
                    if (!decimal.TryParse(Console.ReadLine(), out var projectBonus))
                    {
                        Console.WriteLine("Invalid project bonus amount.");
                        return;
                    }

                    var developer = new Developer(firstName, lastName, id, baseSalary, projectBonus);

                    Console.WriteLine("Enter projects (comma separated): ");
                    var projects = Console.ReadLine()?.Split(',');
                    if (projects != null)
                    {
                        foreach (var project in projects)
                        {
                            if (!string.IsNullOrWhiteSpace(project))
                            {
                                developer.Projects.Add(project.Trim());
                            }
                        }
                    }

                    _employeeService.AddEmployee(developer);
                }
                else
                {
                    Console.WriteLine("Invalid employee type.");
                    return;
                }

                Console.WriteLine("Employee added successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAllEmployees()
        {
            Console.WriteLine("\nAll Employees");
            Console.WriteLine("------------");

            var employees = _employeeService.GetAllEmployees();
            if (!employees.Any())
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (var employee in employees)
            {
                DisplayEmployeeDetails(employee);
            }
        }

        static void UpdateEmployee()
        {
            Console.WriteLine("\nUpdate Employee");
            Console.WriteLine("--------------");

            Console.Write("Enter employee ID to update: ");
            var id = Console.ReadLine();

            var existingEmployee = _employeeService.GetEmployee(id);
            if (existingEmployee == null)
            {
                Console.WriteLine($"Employee with ID {id} not found.");
                return;
            }

            Console.WriteLine("Current employee details:");
            DisplayEmployeeDetails(existingEmployee);

            Console.WriteLine("\nEnter new details:");

            Console.Write("First Name: ");
            var firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();

            Console.Write("Base Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out var baseSalary))
            {
                Console.WriteLine("Invalid salary amount.");
                return;
            }

            try
            {
                if (existingEmployee is Manager manager)
                {
                    Console.Write("Bonus: ");
                    if (!decimal.TryParse(Console.ReadLine(), out var bonus))
                    {
                        Console.WriteLine("Invalid bonus amount.");
                        return;
                    }

                    var updatedManager = new Manager(firstName, lastName, id, baseSalary, bonus);
                    _employeeService.UpdateEmployee(id, updatedManager);
                }
                else if (existingEmployee is Developer developer)
                {
                    Console.Write("Project Bonus (per project): ");
                    if (!decimal.TryParse(Console.ReadLine(), out var projectBonus))
                    {
                        Console.WriteLine("Invalid project bonus amount.");
                        return;
                    }

                    var updatedDeveloper = new Developer(firstName, lastName, id, baseSalary, projectBonus);

                    Console.WriteLine("Enter projects (comma separated): ");
                    var projects = Console.ReadLine()?.Split(',');
                    if (projects != null)
                    {
                        foreach (var project in projects)
                        {
                            if (!string.IsNullOrWhiteSpace(project))
                            {
                                updatedDeveloper.Projects.Add(project.Trim());
                            }
                        }
                    }

                    _employeeService.UpdateEmployee(id, updatedDeveloper);
                }

                Console.WriteLine("Employee updated successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void RemoveEmployee()
        {
            Console.WriteLine("\nRemove Employee");
            Console.WriteLine("--------------");

            Console.Write("Enter employee ID to remove: ");
            var id = Console.ReadLine();

            try
            {
                _employeeService.RemoveEmployee(id);
                Console.WriteLine("Employee removed successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void CalculateTotalSalaries()
        {
            Console.WriteLine("\nTotal Salaries");
            Console.WriteLine("-------------");

            var total = _employeeService.CalculateTotalSalaries();
            Console.WriteLine($"Total salaries for all employees: {total:C}");
        }

        static void ViewEmployeesByType()
        {
            Console.WriteLine("\nView Employees by Type");
            Console.WriteLine("----------------------");

            Console.Write("Enter employee type (1 - Manager, 2 - Developer): ");
            var typeChoice = Console.ReadLine();

            if (typeChoice == "1")
            {
                var managers = _employeeService.GetEmployeesByType<Manager>();
                Console.WriteLine("\nManagers:");
                foreach (var manager in managers)
                {
                    DisplayEmployeeDetails(manager);
                }
            }
            else if (typeChoice == "2")
            {
                var developers = _employeeService.GetEmployeesByType<Developer>();
                Console.WriteLine("\nDevelopers:");
                foreach (var developer in developers)
                {
                    DisplayEmployeeDetails(developer);
                    Console.WriteLine($"  Projects: {string.Join(", ", developer.Projects)}");
                }
            }
            else
            {
                Console.WriteLine("Invalid employee type.");
            }
        }

        static void DisplayEmployeeDetails(Employee employee)
        {
            Console.WriteLine($"\nID: {employee.Id}");
            Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
            Console.WriteLine($"Base Salary: {employee.BaseSalary:C}");
            Console.WriteLine($"Calculated Salary: {employee.CalculateSalary():C}");

            if (employee is Manager manager)
            {
                Console.WriteLine($"Type: Manager");
                Console.WriteLine($"Bonus: {manager.Bonus:C}");
            }
            else if (employee is Developer developer)
            {
                Console.WriteLine($"Type: Developer");
                Console.WriteLine($"Project Bonus (per project): {developer.ProjectBonus:C}");
                Console.WriteLine($"Number of Projects: {developer.Projects.Count}");
            }
        }
    }
}