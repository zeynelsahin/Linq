// See https://aka.ms/new-console-template for more information

using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Threading.Channels;

string[] names = { "Bill", "Steve", "James", "Mohan" };

var myLinqQuery = from name in names where name.Contains('a') select name;

foreach (var s in myLinqQuery)
{
    Console.WriteLine(s + " ");
}

IList<Student> studentList = new List<Student>()
{
    new Student() { StudentID = 1, StudentName = "John", Age = 13 },
    new Student() { StudentID = 2, StudentName = "Moin", Age = 21 },
    new Student() { StudentID = 3, StudentName = "Bill", Age = 18 },
    new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
    new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
};

var teenAgerStudent = from s in studentList where (s.Age > 10 && s.Age < 20) select s;


var result = studentList.Where(s => s.Age > 10 && s.Age < 20);

//Foreach kullanılmadan her student için işlem yapılıyor
var result1 = studentList.Where((s, a) => s.Age > 10 && a == 5);
List<Student> result2 = studentList.Where(p =>
{
    if (p.Age > 10)
    {
        p.StudentName = "Zeynel";
        Console.WriteLine(p.StudentName);
        return true;
    }

    return false;
}).ToList();
var resul4 = from s in studentList where s.Age == 15 select s;
// 
Func<int, int, int> sonuç=(int s, int youngAge) =>
{
    Console.WriteLine("Lambda expression with multiple statements in the body");
    return s >= youngAge? s:youngAge;
};

Console.WriteLine(sonuç(5,6));

bool İsimKontrol(Student student, string isim)
{
    return student.StudentName == isim ? true : false;
}

Func<Student,Student, bool> yasiBuyukmu = (student, a) => student.Age > 10;
Console.WriteLine(yasiBuyukmu(new Student(){Age = 9},new Student()));
// foreach (var student in result1)
// {
//     Console.WriteLine(student.StudentName);
// }



Func<Student, bool> yas12Ile20ArasındaMi = student => student.Age is < 20 and > 12;

var teenStudent = studentList.Where(yas12Ile20ArasındaMi);

foreach (var student in teenStudent)
{
    
}

//Eğerki değer döndürmemiz gerekmiyorsa Action kullanmalıyız
Action<Student> IsimleriYazdir1 = student => Console.WriteLine("Student Name:" + student.StudentName);

IsimleriYazdir1(new Student(){StudentName = "403"});
Action<List<Student>> isimleriYazdir = student =>
{
    foreach (var student1 in student)
    {
        Console.WriteLine(student1.StudentName);
    }
};

isimleriYazdir(new List<Student>(){new Student(){StudentName = "Şahin"},new Student(){StudentName = "Zeynel"}});
public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
}