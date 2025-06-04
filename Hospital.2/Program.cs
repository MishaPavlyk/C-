using System.Xml.Linq;

SELECT w.Name, w.Places
FROM Wards w
JOIN Departments d ON w.DepartmentId = d.Id
WHERE d.Building = 5 AND w.Places >= 5
  AND EXISTS (
    SELECT 1
    FROM Wards w2
    JOIN Departments d2 ON w2.DepartmentId = d2.Id
    WHERE d2.Building = 5 AND w2.Places > 15
  );

SELECT DISTINCT d.Name
FROM Departments d
JOIN Wards w ON w.DepartmentId = d.Id
JOIN DoctorsExaminations de ON de.WardId = w.Id
WHERE de.Date >= DATEADD(DAY, -7, GETDATE());

SELECT di.Name
FROM Diseases di
LEFT JOIN DoctorsExaminations de ON de.DiseaseId = di.Id
WHERE de.Id IS NULL;

SELECT d.Name, d.Surname
FROM Doctors d
LEFT JOIN DoctorsExaminations de ON d.Id = de.DoctorId
WHERE de.Id IS NULL;

SELECT d.Name
FROM Departments d
LEFT JOIN Wards w ON w.DepartmentId = d.Id
LEFT JOIN DoctorsExaminations de ON de.WardId = w.Id
WHERE de.Id IS NULL;

SELECT doc.Surname
FROM Doctors doc
JOIN Interns i ON doc.Id = i.DoctorId;

SELECT d.Surname
FROM Doctors d
JOIN Interns i ON d.Id = i.DoctorId
WHERE d.Salary > (
  SELECT MIN(Salary)
  FROM Doctors
  WHERE Id NOT IN (SELECT DoctorId FROM Interns)
);

SELECT w.Name
FROM Wards w
WHERE w.Places > ALL (
  SELECT w2.Places
  FROM Wards w2
  JOIN Departments d2 ON w2.DepartmentId = d2.Id
  WHERE d2.Building = 3
);

SELECT DISTINCT d.Surname
FROM Doctors d
JOIN DoctorsExaminations de ON d.Id = de.DoctorId
JOIN Wards w ON de.WardId = w.Id
JOIN Departments dp ON w.DepartmentId = dp.Id
WHERE dp.Name IN ('Ophthalmology', 'Physiotherapy');

SELECT DISTINCT d.Name
FROM Departments d
JOIN Wards w ON w.DepartmentId = d.Id
JOIN DoctorsExaminations de ON de.WardId = w.Id
JOIN Doctors doc ON de.DoctorId = doc.Id
WHERE doc.Id IN (SELECT DoctorId FROM Interns)
  AND doc.Id IN (SELECT DoctorId FROM Professors);

SELECT DISTINCT doc.Name + ' ' + doc.Surname AS FullName, dep.Name AS DepartmentName
FROM Doctors doc
JOIN DoctorsExaminations de ON doc.Id = de.DoctorId
JOIN Wards w ON de.WardId = w.Id
JOIN Departments dep ON w.DepartmentId = dep.Id
WHERE dep.Financing > 20000;

SELECT TOP 1 dep.Name
FROM Doctors doc
JOIN DoctorsExaminations de ON doc.Id = de.DoctorId
JOIN Wards w ON de.WardId = w.Id
JOIN Departments dep ON w.DepartmentId = dep.Id
ORDER BY doc.Salary DESC;

SELECT di.Name, COUNT(de.Id) AS ExaminationCount
FROM Diseases di
LEFT JOIN DoctorsExaminations de ON de.DiseaseId = di.Id
GROUP BY di.Name;
