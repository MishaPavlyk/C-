using System.Xml.Linq;

SELECT DISTINCT lr.Name
FROM Teachers t
JOIN Lectures l ON t.Id = l.TeacherId
JOIN Schedules s ON l.Id = s.LectureId
JOIN LectureRooms lr ON s.LectureRoomId = lr.Id
WHERE t.Name = 'Edward' AND t.Surname = 'Hopper';

SELECT DISTINCT t.Surname
FROM Assistants a
JOIN Teachers t ON a.TeacherId = t.Id
JOIN Lectures l ON t.Id = l.TeacherId
JOIN GroupsLectures gl ON l.Id = gl.LectureId
JOIN Groups g ON gl.GroupId = g.Id
WHERE g.Name = 'F505';

SELECT DISTINCT s.Name
FROM Teachers t
JOIN Lectures l ON t.Id = l.TeacherId
JOIN Subjects s ON l.SubjectId = s.Id
JOIN GroupsLectures gl ON l.Id = gl.LectureId
JOIN Groups g ON gl.GroupId = g.Id
WHERE t.Name = 'Alex' AND t.Surname = 'Carmack' AND g.Year = 5;

SELECT t.Surname
FROM Teachers t
WHERE NOT EXISTS (
    SELECT 1
    FROM Lectures l
    JOIN Schedules s ON l.Id = s.LectureId
    WHERE s.DayOfWeek = 1 AND l.TeacherId = t.Id
);

SELECT lr.Name, lr.Building
FROM LectureRooms lr
WHERE lr.Id NOT IN (
    SELECT s.LectureRoomId
    FROM Schedules s
    WHERE s.DayOfWeek = 3 AND s.Week = 2 AND s.Class = 3
);

SELECT DISTINCT t.Name, t.Surname
FROM Teachers t
JOIN Lectures l ON t.Id = l.TeacherId
JOIN GroupsLectures gl ON l.Id = gl.LectureId
JOIN Groups g ON gl.GroupId = g.Id
JOIN Departments d ON g.DepartmentId = d.Id
JOIN Faculties f ON d.FacultyId = f.Id
WHERE f.Name = 'Computer Science'
AND t.Id NOT IN (
    SELECT c.TeacherId
    FROM Curators c
    JOIN GroupsCurators gc ON c.Id = gc.CuratorId
    JOIN Groups g2 ON gc.GroupId = g2.Id
    JOIN Departments d2 ON g2.DepartmentId = d2.Id
    WHERE d2.Name = 'Software Development'
);

SELECT DISTINCT Building FROM Faculties
UNION
SELECT DISTINCT Building FROM Departments
UNION
SELECT DISTINCT Building FROM LectureRooms;

SELECT t.Name, t.Surname, 'Dean' AS Role
FROM Deans d
JOIN Teachers t ON d.TeacherId = t.Id
UNION
SELECT t.Name, t.Surname, 'Head' AS Role
FROM Heads h
JOIN Teachers t ON h.TeacherId = t.Id
UNION
SELECT t.Name, t.Surname, 'Teacher' AS Role
FROM Teachers t
WHERE t.Id NOT IN (SELECT TeacherId FROM Deans)
  AND t.Id NOT IN (SELECT TeacherId FROM Heads)
  AND t.Id NOT IN (SELECT TeacherId FROM Curators)
  AND t.Id NOT IN (SELECT TeacherId FROM Assistants)
UNION
SELECT t.Name, t.Surname, 'Curator' AS Role
FROM Curators c
JOIN Teachers t ON c.TeacherId = t.Id
UNION
SELECT t.Name, t.Surname, 'Assistant' AS Role
FROM Assistants a
JOIN Teachers t ON a.TeacherId = t.Id;

SELECT DISTINCT s.DayOfWeek
FROM Schedules s
JOIN LectureRooms lr ON s.LectureRoomId = lr.Id
WHERE lr.Name IN ('A311', 'A104') AND lr.Building = 6;
