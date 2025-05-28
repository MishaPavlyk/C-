using System.Text.RegularExpressions;

SELECT Name, Financing, Id FROM Departments;

SELECT Name AS [Group Name], Rating AS[Group Rating] FROM Groups;

SELECT
    Surname,
    (Salary / NULLIF(Premium, 0)) * 100 AS [Salary to Premium %],
    (Salary / NULLIF((Salary + Premium), 0)) * 100 AS[Salary to Total %]
FROM Teachers;

SELECT 'The dean of faculty ' + Name + ' is ' + Dean + '.' AS Info
FROM Faculties;

SELECT Surname 
FROM Teachers 
WHERE IsProfessor = 1 AND Salary > 1050;

SELECT Name 
FROM Departments 
WHERE Financing < 11000 OR Financing > 25000;

SELECT Name 
FROM Faculties 
WHERE Name <> 'Computer Science';

SELECT Surname, Position 
FROM Teachers 
WHERE IsProfessor = 0;

SELECT Surname, Position, Salary, Premium 
FROM Teachers 
WHERE IsAssistant = 1 AND Premium BETWEEN 160 AND 550;

SELECT Surname, Salary 
FROM Teachers 
WHERE IsAssistant = 1;

SELECT Surname, Position 
FROM Teachers 
WHERE EmploymentDate < '2000-01-01';

SELECT Name AS [Name of Department]
FROM Departments 
WHERE Name < 'Software Development';

SELECT Surname 
FROM Teachers 
WHERE IsAssistant = 1 AND (Salary + Premium) <= 1200;

SELECT Name 
FROM Groups 
WHERE Year = 5 AND Rating BETWEEN 2 AND 4;

SELECT Surname 
FROM Teachers 
WHERE IsAssistant = 1 AND (Salary < 550 OR Premium < 200);
