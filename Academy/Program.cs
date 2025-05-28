using System.Xml.Linq;

SELECT T1.Name AS TeacherName, T1.Surname AS TeacherSurname, G.Name AS GroupName
FROM Teachers T1
CROSS JOIN Groups G;

SELECT F.Name
FROM Faculties F
WHERE EXISTS (
    SELECT 1
    FROM Departments D
    WHERE D.FacultyId = F.Id
    GROUP BY D.FacultyId
    HAVING SUM(D.Financing) > F.Financing
);

SELECT C.Surname, G.Name
FROM GroupsCurators GC
JOIN Curators C ON GC.CuratorId = C.Id
JOIN Groups G ON GC.GroupId = G.Id;

SELECT DISTINCT T.Surname
FROM Lectures L
JOIN Teachers T ON L.TeacherId = T.Id
JOIN GroupsLectures GL ON GL.LectureId = L.Id
JOIN Groups G ON GL.GroupId = G.Id
WHERE G.Name = 'P107';

SELECT DISTINCT T.Surname, F.Name AS FacultyName
FROM Lectures L
JOIN Teachers T ON L.TeacherId = T.Id
JOIN GroupsLectures GL ON GL.LectureId = L.Id
JOIN Groups G ON GL.GroupId = G.Id
JOIN Departments D ON G.DepartmentId = D.Id
JOIN Faculties F ON D.FacultyId = F.Id;

SELECT DISTINCT D.Name AS DepartmentName, G.Name AS GroupName
FROM Groups G
JOIN Departments D ON G.DepartmentId = D.Id;

SELECT DISTINCT S.Name
FROM Lectures L
JOIN Subjects S ON L.SubjectId = S.Id
JOIN Teachers T ON L.TeacherId = T.Id
WHERE T.Name = 'Samantha' AND T.Surname = 'Adams';

SELECT DISTINCT D.Name
FROM Departments D
JOIN Groups G ON G.DepartmentId = D.Id
JOIN GroupsLectures GL ON GL.GroupId = G.Id
JOIN Lectures L ON L.Id = GL.LectureId
JOIN Subjects S ON S.Id = L.SubjectId
WHERE S.Name = 'Теорія баз даних';

SELECT DISTINCT G.Name
FROM Groups G
JOIN Departments D ON G.DepartmentId = D.Id
JOIN Faculties F ON D.FacultyId = F.Id
WHERE F.Name = 'Комп''ютерні науки';

SELECT G.Name, F.Name AS FacultyName
FROM Groups G
JOIN Departments D ON G.DepartmentId = D.Id
JOIN Faculties F ON D.FacultyId = F.Id
WHERE G.Year = 5;

SELECT DISTINCT T.Surname, S.Name AS SubjectName, G.Name AS GroupName
FROM Lectures L
JOIN Teachers T ON L.TeacherId = T.Id
JOIN Subjects S ON L.SubjectId = S.Id
JOIN GroupsLectures GL ON GL.LectureId = L.Id
JOIN Groups G ON GL.GroupId = G.Id
WHERE L.LectureRoom = 'B103';
