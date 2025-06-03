using System.Text.RegularExpressions;

SELECT Building
FROM Departments
GROUP BY Building
HAVING SUM(Financing) > 100000;

SELECT g.Name
FROM Groups g
JOIN Departments d ON g.DepartmentId = d.Id
JOIN GroupsLectures gl ON g.Id = gl.GroupId
JOIN Lectures l ON gl.LectureId = l.Id
WHERE g.Year = 5 AND d.Name = 'Software Development' AND DATEPART(WEEK, l.Date) = 1
GROUP BY g.Name
HAVING COUNT(*) > 10;

SELECT g.Name
FROM Groups g
JOIN GroupsStudents gs ON g.Id = gs.GroupId
JOIN Students s ON gs.StudentId = s.Id
GROUP BY g.Name
HAVING AVG(s.Rating) > (
    SELECT AVG(s2.Rating)
    FROM GroupsStudents gs2
    JOIN Students s2 ON gs2.StudentId = s2.Id
    JOIN Groups g2 ON gs2.GroupId = g2.Id
    WHERE g2.Name = 'D221'
);

SELECT Name, Surname
FROM Teachers
WHERE Salary > (
    SELECT AVG(Salary)
    FROM Teachers
    WHERE IsProfessor = 1
);

SELECT g.Name
FROM Groups g
JOIN GroupsCurators gc ON g.Id = gc.GroupId
GROUP BY g.Name
HAVING COUNT(gc.CuratorId) > 1;

SELECT g.Name
FROM Groups g
JOIN GroupsStudents gs ON g.Id = gs.GroupId
JOIN Students s ON gs.StudentId = s.Id
GROUP BY g.Name
HAVING AVG(s.Rating) < (
    SELECT MIN(avg_rating)
    FROM (
        SELECT AVG(s2.Rating) AS avg_rating
        FROM Groups g2
        JOIN GroupsStudents gs2 ON g2.Id = gs2.GroupId
        JOIN Students s2 ON gs2.StudentId = s2.Id
        WHERE g2.Year = 5
        GROUP BY g2.Id
    ) AS SubQuery
);

SELECT f.Name
FROM Faculties f
JOIN Departments d ON f.Id = d.FacultyId
GROUP BY f.Name
HAVING SUM(d.Financing) > (
    SELECT SUM(d2.Financing)
    FROM Faculties f2
    JOIN Departments d2 ON f2.Id = d2.FacultyId
    WHERE f2.Name = 'Computer Science'
);

SELECT s.Name AS SubjectName, t.Name, t.Surname
FROM Lectures l
JOIN Subjects s ON l.SubjectId = s.Id
JOIN Teachers t ON l.TeacherId = t.Id
GROUP BY s.Name, t.Name, t.Surname
HAVING COUNT(*) = (
    SELECT MAX(cnt)
    FROM (
        SELECT COUNT(*) AS cnt
        FROM Lectures
        GROUP BY SubjectId, TeacherId
    ) AS SubQuery
);

SELECT s.Name
FROM Subjects s
JOIN Lectures l ON s.Id = l.SubjectId
GROUP BY s.Id, s.Name
ORDER BY COUNT(l.Id)
OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY;

SELECT
    (SELECT COUNT(DISTINCT gs.StudentId)
     FROM Groups g
     JOIN GroupsStudents gs ON g.Id = gs.GroupId
     WHERE g.DepartmentId = (
         SELECT Id FROM Departments WHERE Name = 'Software Development'
     )) AS StudentsCount,

    (SELECT COUNT(DISTINCT l.SubjectId)
     FROM Groups g
     JOIN GroupsLectures gl ON g.Id = gl.GroupId
     JOIN Lectures l ON gl.LectureId = l.Id
     WHERE g.DepartmentId = (
         SELECT Id FROM Departments WHERE Name = 'Software Development'
     )) AS SubjectsCount;
