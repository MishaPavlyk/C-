SELECT Name
FROM Departments
WHERE Building = (
    SELECT Building
    FROM Departments
    WHERE Name = 'Cardiology'
);

SELECT Name
FROM Departments
WHERE Building IN (
    SELECT Building
    FROM Departments
    WHERE Name IN ('Gastroenterology', 'General Surgery')
);

SELECT TOP 1 d.Name
FROM Departments d
JOIN Donations don ON d.Id = don.DepartmentId
GROUP BY d.Name
ORDER BY SUM(don.Amount);

SELECT Surname
FROM Doctors
WHERE Salary > (
    SELECT Salary
    FROM Doctors
    WHERE Name = 'Thomas' AND Surname = 'Gerada'
);

SELECT w.Name
FROM Wards w
JOIN Departments d ON w.DepartmentId = d.Id
WHERE d.Name = 'Microbiology'
AND w.Places > (
    SELECT AVG(w2.Places)
    FROM Wards w2
    JOIN Departments d2 ON w2.DepartmentId = d2.Id
    WHERE d2.Name = 'Microbiology'
);

SELECT Name + ' ' + Surname AS FullName
FROM Doctors
WHERE Salary + Premium > (
    SELECT Salary + Premium + 100
    FROM Doctors
    WHERE Name = 'Anthony' AND Surname = 'Davis'
);

SELECT DISTINCT d.Name
FROM Departments d
JOIN Wards w ON d.Id = w.DepartmentId
JOIN DoctorsExaminations de ON w.Id = de.WardId
JOIN Doctors doc ON de.DoctorId = doc.Id
WHERE doc.Name = 'Joshua' AND doc.Surname = 'Bell';

SELECT Name
FROM Sponsors
WHERE Id NOT IN (
    SELECT SponsorId
    FROM Donations
    WHERE DepartmentId IN (
        SELECT Id
        FROM Departments
        WHERE Name IN ('Neurology', 'Oncology')
    )
);

SELECT DISTINCT Surname
FROM Doctors d
JOIN DoctorsExaminations de ON d.Id = de.DoctorId
WHERE StartTime >= '12:00' AND EndTime <= '15:00';
