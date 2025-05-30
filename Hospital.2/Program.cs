SELECT COUNT(*) AS WardCount
FROM Wards
WHERE Places > 10;

SELECT d.Building, COUNT(w.Id) AS WardCount
FROM Departments d
JOIN Wards w ON d.Id = w.DepartmentId
GROUP BY d.Building;

SELECT d.Name AS DepartmentName, COUNT(w.Id) AS WardCount
FROM Departments d
JOIN Wards w ON d.Id = w.DepartmentId
GROUP BY d.Name;

SELECT d.Name AS DepartmentName, SUM(doc.Premium) AS TotalPremium
FROM Departments d
JOIN Wards w ON d.Id = w.DepartmentId
JOIN DoctorsExaminations de ON w.Id = de.WardId
JOIN Doctors doc ON de.DoctorId = doc.Id
GROUP BY d.Name;

SELECT d.Name AS DepartmentName
FROM Departments d
JOIN Wards w ON d.Id = w.DepartmentId
JOIN DoctorsExaminations de ON w.Id = de.WardId
GROUP BY d.Name
HAVING COUNT(DISTINCT de.DoctorId) >= 5;

SELECT COUNT(*) AS DoctorCount,
       SUM(Salary + Premium) AS TotalPay
FROM Doctors;

SELECT AVG(Salary + Premium) AS AveragePay
FROM Doctors;

SELECT Name
FROM Wards
WHERE Places = (SELECT MIN(Places) FROM Wards);

SELECT d.Building, SUM(w.Places) AS TotalPlaces
FROM Departments d
JOIN Wards w ON d.Id = w.DepartmentId
WHERE d.Building IN (1, 6, 7, 8)
  AND w.Places > 10
GROUP BY d.Building
HAVING SUM(w.Places) > 100;
