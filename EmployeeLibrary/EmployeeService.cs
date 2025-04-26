using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeLibrary
{
    /// <summary>
    /// Service for managing employee operations
    /// </summary>
    public class EmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        /// <summary>
        /// Adds a new employee to the system
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when employee with same ID already exists</exception>
        public void AddEmployee(Employee employee)
        {
            if (_employees.Any(e => e.Id == employee.Id))
            {
                throw new ArgumentException($"Employee with ID {employee.Id} already exists.");
            }

            _employees.Add(employee);
        }

        /// <summary>
        /// Removes an employee by ID
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when employee with specified ID is not found</exception>
        public void RemoveEmployee(string id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new ArgumentException($"Employee with ID {id} not found.");
            }

            _employees.Remove(employee);
        }

        /// <summary>
        /// Gets an employee by ID
        /// </summary>
        public Employee GetEmployee(string id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }


        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees.AsReadOnly();
        }

        /// <summary>
        /// Updates an existing employee
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when employee with specified ID is not found</exception>
        public void UpdateEmployee(string id, Employee updatedEmployee)
        {
            var existingEmployee = GetEmployee(id);
            if (existingEmployee == null)
            {
                throw new ArgumentException($"Employee with ID {id} not found.");
            }

            // Preserve the original ID
            updatedEmployee.Id = id;

            _employees.Remove(existingEmployee);
            _employees.Add(updatedEmployee);
        }

        /// <summary>
        /// Calculates the total salary for all employees
        /// </summary>
        public decimal CalculateTotalSalaries()
        {
            return _employees.Sum(e => e.CalculateSalary());
        }

        /// <summary>
        /// Gets employees of a specific type
        /// </summary>
        public IEnumerable<T> GetEmployeesByType<T>() where T : Employee
        {
            return _employees.OfType<T>();
        }
    }
}