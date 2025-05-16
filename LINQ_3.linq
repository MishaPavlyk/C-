<Query Kind="Statements" />

void Main()
{

    var students = new[] {
        new Student { FirstName = "Boris", LastName = "Brown", Age = 21, University = "MIT" },
        new Student { FirstName = "Alice", LastName = "Brooks", Age = 20, University = "Oxford" },
        new Student { FirstName = "John", LastName = "Smith", Age = 22, University = "Harvard" },
        new Student { FirstName = "Nina", LastName = "Brody", Age = 19, University = "Oxford" },
        new Student { FirstName = "Boris", LastName = "Ivanov", Age = 18, University = "MIT" },
        new Student { FirstName = "Kate", LastName = "Bromley", Age = 23, University = "Oxford" }
    };


    students.Dump("1. Увесь масив студентів");


    students.Where(s => s.FirstName == "Boris").Dump("2. Студенти з ім’ям Boris");


    students.Where(s => s.LastName.StartsWith("Bro")).Dump("3. Прізвища починаються з 'Bro'");


    students.Where(s => s.Age > 19).Dump("4. Студенти старші за 19 років");


    students.Where(s => s.Age > 20 && s.Age < 23).Dump("5. Вік між 20 і 23");

    
    students.Where(s => s.University == "MIT").Dump("6. Студенти з MIT");


    students
        .Where(s => s.University == "Oxford" && s.Age > 18)
        .OrderByDescending(s => s.Age)
        .Dump("7. Oxford & >18, відсортовано за віком (спадання)");
}


class Student
{
    public string FirstName;
    public string LastName;
    public int Age;
    public string University;

    public override string ToString() => $"{FirstName} {LastName}, {Age} років, {University}";
}
