// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Data;
using System.Diagnostics.SymbolStore;
using GenFu;

IList<Student> studentList = new List<Student>()
{
    new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 },
    new Student() { StudentID = 2, StudentName = "Steve", Age = 21, StandardID = 1 },
    new Student() { StudentID = 3, StudentName = "Bill", Age = 18, StandardID = 2 },
    new Student() { StudentID = 4, StudentName = "Ram", Age = 20, StandardID = 2 },
    new Student() { StudentID = 5, StudentName = "Ron", Age = 21 }
};
IList<Standard> standardList = new List<Standard>()
{
    new Standard() { StandardID = 1, StandardName = "Standard 1" },
    new Standard() { StandardID = 2, StandardName = "Standard 2" },
    new Standard() { StandardID = 3, StandardName = "Standard 3" }
};

var studentNames = studentList.Where(s => s.Age > 18).Select(s => s).Where(st => st.StandardID > 0)
    .Select(s => s.StudentName);


void Listele(IEnumerable liste)
{
    foreach (var item in liste)
    {
        Console.WriteLine(item);
    }
}

Console.WriteLine("Student List");
Listele(studentNames);

Console.WriteLine("/*/*/*/*/*/*/");
var teenStudentsName = from s in studentList where s.Age > 12 && s.Age < 20 select new { StudentName = s.StudentName };

teenStudentsName.ToList().ForEach(s => Console.WriteLine(s.StudentName));

var studentsGroupByStandard =
    from s in studentList where s.StandardID > 0 group s by s.StandardID into sg select new { sg.Key, sg };

foreach (var group in studentsGroupByStandard)
{
    Console.WriteLine("StandardId :" + group.Key);
    group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName));
    Console.WriteLine("");
}

var studentsGroup = from stad in standardList
    join s in studentList on stad.StandardID equals s.StandardID into sg
    select new
    {
        StandardName = stad.StandardName,
        Students = sg
    };

foreach (var group in studentsGroup)
{
    Console.WriteLine(group.StandardName);
    group.Students.ToList().ForEach(s => Console.WriteLine(s.StudentName));
}


var studentsWithStandard = from stad in standardList
    join s in studentList on stad.StandardID equals s.StandardID into sg
    from std_grp in sg
    orderby stad.StandardName, std_grp.StudentName
    select new
    {
        StudentName = std_grp.StudentName,
        StandardName = stad.StandardName
    };

foreach (var result in studentsWithStandard)
{
    Console.WriteLine($"{result.StudentName} is in {result.StandardName}");
}

var sortedStudents = from s in studentList
    orderby s.StandardID, s.Age
    select new
    {
        StudentName = s.StudentName,
        Age = s.Age,
        StandardId = s.StandardID
    };

sortedStudents.ToList().ForEach(s => Console.WriteLine($"Student Name : {s.StudentName}, Age: {s.Age}"));


var nestedQueries = from s in studentList
    where s.Age >18 && s.StandardID ==
        (from std in standardList where std.StandardName == "Standard 1" select std.StandardID).FirstOrDefault()
    select s;

List<int> numbers = new();

Console.WriteLine("Chunk kullanımı");
var people = A.ListOf<Person>(103);
var teamId = 1;
foreach (var team in people.Chunk(10))
{
    Console.WriteLine($"Team : {teamId} ");
    var leader = team.MaxBy(p => p.Age);
    Console.WriteLine("Leader  :" + leader.FirstName + " " + leader.LastName);
    Console.WriteLine(string.Join(",", team.Select(p => $"{p.FirstName} {p.LastName}")));
    teamId++;
}

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int StandardID { get; set; }
    public int Age { get; set; }
}

public class Standard
{
    public int StandardID { get; set; }
    public string StandardName { get; set; }
}