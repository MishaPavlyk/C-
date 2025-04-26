using EmployeeLibrary;
using System;
using Xunit;

namespace EmployeeLibraryTests
{
    public class EmployeeServiceTests
    {
        private readonly EmployeeService _service;

        public EmployeeServiceTests()
        {
            _service = new EmployeeService();
        }

        [Fact]
        public void AddEmployee_ShouldAddEmployee_WhenIdIsUnique()
        {
            // Arrange
            var employee = new Manager("John", "Doe", "001", 50000, 10000);

            // Act
            _service.AddEmployee(employee);

            // Assert
            var result = _service.GetEmployee("001");
            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
        }

        [Fact]
        public void AddEmployee_ShouldThrowException_WhenIdExists()
        {
            // Arrange
            var employee1 = new Manager("John", "Doe", "001", 50000, 10000);
            var employee2 = new Developer("Jane", "Smith", "001", 60000, 5000);

            // Act
            _service.AddEmployee(employee1);

            // Assert
            Assert.Throws<ArgumentException>(() => _service.AddEmployee(employee2));
        }

        [Fact]
        public void RemoveEmployee_ShouldRemoveEmployee_WhenIdExists()
        {
            // Arrange
            var employee = new Manager("John", "Doe", "001", 50000, 10000);
            _service.AddEmployee(employee);

            // Act
            _service.RemoveEmployee("001");

            // Assert
            Assert.Null(_service.GetEmployee("001"));
        }

        [Fact]
        public void RemoveEmployee_ShouldThrowException_WhenIdDoesNotExist()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _service.RemoveEmployee("999"));
        }

        [Fact]
        public void UpdateEmployee_ShouldUpdateEmployee_WhenIdExists()
        {
            // Arrange
            var original = new Manager("John", "Doe", "001", 50000, 10000);
            _service.AddEmployee(original);
            var updated = new Manager("John", "Smith", "001", 55000, 12000);

            // Act
            _service.UpdateEmployee("001", updated);

            // Assert
            var result = _service.GetEmployee("001") as Manager;
            Assert.Equal("Smith", result.LastName);
            Assert.Equal(55000, result.BaseSalary);
            Assert.Equal(12000, result.Bonus);
        }

        [Fact]
        public void CalculateTotalSalaries_ShouldReturnCorrectSum()
        {
            // Arrange
            _service.AddEmployee(new Manager("John", "Doe", "001", 50000, 10000));
            _service.AddEmployee(new Developer("Jane", "Smith", "002", 60000, 5000));
            var dev = _service.GetEmployee("002") as Developer;
            dev.Projects.Add("Project A");
            dev.Projects.Add("Project B");

            // Act
            var total = _service.CalculateTotalSalaries();

            // Assert
            Assert.Equal(50000 + 10000 + 60000 + (5000 * 2), total);
        }

        [Fact]
        public void GetEmployeesByType_ShouldReturnOnlyManagers()
        {
            // Arrange
            _service.AddEmployee(new Manager("John", "Doe", "001", 50000, 10000));
            _service.AddEmployee(new Developer("Jane", "Smith", "002", 60000, 5000));
            _service.AddEmployee(new Manager("Bob", "Johnson", "003", 55000, 12000));

            // Act
            var managers = _service.GetEmployeesByType<Manager>();

            // Assert
            Assert.Equal(2, managers.Count());
            Assert.All(managers, m => Assert.IsType<Manager>(m));
        }
    }
}

public class EmployeeTests
{
    [Fact]
    public void Manager_CalculateSalary_ShouldIncludeBonus()
    {
        // Arrange
        var manager = new Manager("John", "Doe", "001", 50000, 10000);

        // Act
        var salary = manager.CalculateSalary();

        // Assert
        Assert.Equal(60000, salary);
    }

    [Fact]
    public void Developer_CalculateSalary_ShouldIncludeProjectBonuses()
    {
        // Arrange
        var developer = new Developer("Jane", "Smith", "002", 60000, 5000);
        developer.Projects.Add("Project A");
        developer.Projects.Add("Project B");
        developer.Projects.Add("Project C");

        // Act
        var salary = developer.CalculateSalary();

        // Assert
        Assert.Equal(60000 + (5000 * 3), salary);
    }
}