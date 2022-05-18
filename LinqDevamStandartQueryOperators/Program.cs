// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Threading.Channels;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;

IList<Student> studentList = new List<Student>()
{
    new Student() { StudentID = 1, StudentName = "John", Age = 13 },
    new Student() { StudentID = 2, StudentName = "Moin", Age = 20 },
    new Student() { StudentID = 3, StudentName = "Bill", Age = 18 },
    new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
    new Student() { StudentID = 5, StudentName = "Jennifer", Age = 18 },
};


var filteredResult = from s in studentList where s.Age is > 12 and < 20 select s;
foreach (var s in filteredResult)
{
    Console.WriteLine(s.StudentName);
}

Func<Student, bool> isTeenAger = delegate(Student s) { return s.Age > 12 && s.Age < 12; };

bool isTeenAger1(Student student)
{
    return student.Age > 12 && student.Age < 20;
}

filteredResult = from s in studentList where isTeenAger1(s) select s;

foreach (var s in filteredResult)
{
    Console.WriteLine(s.StudentName + " asdasd ");
}

Student student9 = new Student() { };

var asdasd = studentList.Where(p => p == student9).ToList();

var filteredResult1 = studentList.Where((s, i) =>
{
    if (i % 2 == 0)
    {
        return true;
    }

    return false;
});


foreach (var student in filteredResult1)
{
    Console.WriteLine(student.StudentName);
}


//Parametresiz delege 
Func<int> nameLenght = () =>
{
    Console.WriteLine("Uzunluk 5");
    return 5;
};
int sonuc = nameLenght();
Console.WriteLine(sonuc);


IList liste = new ArrayList();

liste.Add(123);

liste.Add(new Student() { Age = 15 });

liste.Add("Deneme");

Action<Student> degereler = (s) =>
{
    if (liste.OfType<Student>().Count() != 0)
    {
    }
};


var result = liste.OfType<Student>().ToList();
foreach (var student in result)
{
    Console.WriteLine(student.Age);
}


var result1 = studentList.OrderBy(p => p.Age);

var result2 = studentList.OrderBy(p => p.Age).ThenBy(p => p.StudentName).ThenByDescending(p => p.StudentID);

var result3 = from s in studentList
    orderby s.Age, s.StudentName, s.StudentID
    select new { s.Age, s.StudentName, s.StudentID };


//Group by sadece listeyi gropluyor
var groupResult = from s in studentList group s by s.StudentName;
Console.WriteLine("******");
foreach (var students in groupResult)
{
    Console.WriteLine(students.Key);
    foreach (var a in students)
    {
        Console.WriteLine(a.StudentID);
    }
}

Console.WriteLine("*-*****");

var result5 = studentList.GroupBy(p => p.Age);
Console.WriteLine("Group By ");
foreach (var students in result5)
{
    Console.WriteLine("Group By Age : " + students.Key);
    foreach (var student in students)
    {
        Console.WriteLine($"{student.StudentName}");
    }
}

Console.WriteLine("Group By End");

var result6 = studentList.ToLookup(p => p.StudentName);

foreach (var students in result6)
{
    Console.WriteLine(students.Key);
    foreach (var student in students)
    {
        Console.WriteLine(student.StudentID);
    }
}

IList<string> strList1 = new List<string>()
{
    "Bir", "İki", "Üç", "Dört", "Beş"
};
IList<string> strList2 = new List<string>()
{
    "Bir", "İki", "Üç", "Altı", "Yedi"
};


var innerJoin = strList1.Join(strList2, str1 => str1, str2 => str2, (str1, str2) => str1);
Console.WriteLine("/////////////");
foreach (var s in innerJoin)
{
    Console.WriteLine(s);
}

IList<Student> studentList1 = new List<Student>()
{
    new Student() { StudentID = 1, StudentName = "John", StandardID = 1 },
    new Student() { StudentID = 2, StudentName = "Moin", StandardID = 1 },
    new Student() { StudentID = 3, StudentName = "Bill", StandardID = 2 },
    new Student() { StudentID = 4, StudentName = "Ram", StandardID = 2 },
    new Student() { StudentID = 5, StudentName = "Jennifer" }
};
IList<Standard> standardList = new List<Standard>()
{
    new Standard() { StandardID = 1, StandardName = "Standard 1" },
    new Standard() { StandardID = 2, StandardName = "Standard 2" },
    new Standard() { StandardID = 3, StandardName = "Standard 3" }
};


var innerJoin1 = studentList1.Join(standardList, student => student.StandardID, standard => standard.StandardID,
    (student, standard) => new
    {
        Student = student,
        StudentName = student.StudentName,
        StandardName = standard.StandardName
    });
Console.WriteLine("----------");
foreach (var x1 in innerJoin1)
{
    Console.WriteLine($" {x1.StudentName} , {x1.StandardName}");
}

var innerJoin2 = from s in studentList1
    join st in standardList on s.StandardID equals st.StandardID
    select new { StudenName = s.StudentName, StandardName = st.StandardName };


var groupJoin = standardList.GroupJoin(studentList1, std => std.StandardID, s => s.StandardID, (std, studentGroup) =>
    new
    {
        Students = studentGroup,
        StandardFulldName = std.StandardName
    });
Console.WriteLine("+++++++++++++++");
foreach (var item in groupJoin)
{
    Console.WriteLine(item.StandardFulldName);
    foreach (var x in item.Students)
    {
        Console.WriteLine(x.StudentName);
    }
}

var groupJoin1 = from st in standardList
    join student in studentList1 on st.StandardID equals student.StandardID into studentGroup
    select new
    {
        Students = studentGroup,
        StandardName = st.StandardName
    };
Console.WriteLine("------------");
foreach (var item in groupJoin1)
{
    Console.WriteLine(item.StandardName);
    foreach (var student in item.Students)
    {
        Console.WriteLine(student.StudentName);
    }
}


var innerJoin3 = studentList1.Join(standardList, student => student.StandardID, standard => standard.StandardID,
    (student, standard) => new
    {
        Student = student,
        StudentName = student.StudentName,
        StandardName = standard.StandardName
    });
Console.WriteLine("StudentList baglanıldı");
foreach (var x1 in innerJoin3)
{
    Console.WriteLine($" {x1.StudentName} , {x1.StandardName}");
}

var innerJoin4 = standardList.Join(studentList1, st => st.StandardID, stList => stList.StandardID, (stList, st) => new
{
    StandardName = stList.StandardName,
    StudentName = st.StudentName
});
Console.WriteLine("Standard Listeden baglanıldı");
Console.WriteLine("İnnerjoin 4 Adet: " + innerJoin4.Count());
foreach (var x1 in innerJoin4)
{
    Console.WriteLine($" {x1.StudentName} , {x1.StandardName}");
}

Console.WriteLine("Deneme");


var innerJoin5 = from student in studentList
    join standard in standardList on student.StandardID equals standard.StandardID
    select new
    {
        StudenName = student.StudentName,
        StandardName = standard.StandardName
    };

foreach (var item in innerJoin5)
{
    Console.WriteLine($"{item.StandardName},{item.StudenName}");
}

var groupJoin2 = standardList.GroupJoin(studentList1, standard => standard.StandardID, student => student.StandardID, (
    (standard, studentsGroup) => new
    {
        Students = studentsGroup,
        StandardFullName = standard.StandardName
    }));
Console.WriteLine("GroupBy2");
foreach (var item in groupJoin2)
{
    Console.WriteLine($"{item.StandardFullName} ait ögrenciler");
    foreach (var student in item.Students)
    {
        Console.WriteLine(student.StudentName);
    }
}

var result7 = studentList1.Select(p => new { p.Age, p.StudentName, p.StandardID, p.StudentID }).ToList();

foreach (var x1 in result7)
{
    Console.WriteLine($"{x1.StandardID},{x1.StudentName}");
}

var result8 = studentList1.All(p => p.StudentID >= 1);
Console.WriteLine(result8);

var result9 = studentList1.Any(p => p.StudentID == 5);
Console.WriteLine(result9);

var person = studentList1.First(p => p.StudentID == 1);
var resul10 = studentList1.Contains(person);
Console.WriteLine("Sınıfı içeriyormu?" + resul10);


Student std = new Student() { StudentID = 3, StudentName = "Bill" };
var result11 = studentList1.Contains(std, new StudentComparer());
Console.WriteLine("Comparer ile kontrol :" + result11);


//Aggregate toplama işlemi yapıyor tip farketmeksizin
IList<int> rakamlar = new List<int>() { 1, 2, 3, 4, 5 };
var comaSeperatedİnt = rakamlar.Aggregate((s1, s2) => s1 + s2);
Console.WriteLine(comaSeperatedİnt);

IList<string> strList = new List<string>() { "Bir", "İki", "Üç", "Dört" };

var comaSeperatedString = strList.Aggregate((s1, s2) => s1 + "," + s2);
Console.WriteLine(comaSeperatedString);

string commaSeparatedStudentsName =
    studentList1.Aggregate<Student, string>("Student Names:", (str, s) => str += s.StudentName + ", ");
Console.WriteLine("*****************************");
Console.WriteLine(commaSeparatedStudentsName);

int SumOfTudentsAge = studentList1.Aggregate<Student, int>(0, (total, std) => total += std.Age);
string commaSeparatedStudentNames =
    studentList1.Aggregate<Student, string, string>(seed: string.Empty,
        ((s, student) => s += student.StudentName + ", "), s => s.Substring(0, s.Length - 1));

Console.WriteLine("*-*-*-*-*-*-*-*-*-");
Console.WriteLine(commaSeparatedStudentNames);


IList<int> intList = new List<int>() { 10, 10, 20, 30, 20, 50, 40 };

var avg = intList.Average();
Console.WriteLine("Average : {0}", avg);

var avgAge = studentList.Average(p => p.Age);
Console.WriteLine("Average Age: " + avgAge);

var totalElements = intList.Count();

Console.WriteLine(totalElements);

var evenElements = intList.Count(p => p % 2 == 0);
Console.WriteLine(evenElements);

//Sorgu ifadeleri toplama operatörlerini desteklemez

var totalAge = (from s in studentList1 select s.Age).Count();

var largest = intList.Max();
Console.WriteLine("Largest Element : {0}", largest);

var largestEvenElements = intList.Max(i =>
{
    if (i % 2 == 0)
    {
        return i;
    }

    return 0;
});

Console.WriteLine("Largest Even Element:{0}", largestEvenElements);


var oldest = studentList.Max(p => p.Age);
Console.WriteLine("Oldest Student Age : {0}", oldest);


var studentWithLongName = studentList1.Max();
Console.WriteLine($"Student Name: {studentWithLongName.StudentName}  Student Id: {studentWithLongName.StudentID}");

IList<int> intList2 = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
IList<string> strList3 = new List<string>() { null, "Two", "Three", "Four", "Five" };
IList<string> emptyList = new List<string>();

Console.WriteLine("1st Element in intList: " + intList2.FirstOrDefault());
Console.WriteLine("1st Element in intList: " + intList2.First());
Console.WriteLine("1st Element in intList: " + intList2.FirstOrDefault(p => p.Equals(50)));
// Console.WriteLine("1st Element in stringList: "+strList3.FirstOrDefault(p=>p.Contains("a")));
Console.WriteLine("Last Element in intList {0}", intList2.Last());
Console.WriteLine("Last Even Element in intList {0}", intList2.Last(i => i % 2 == 0));
Console.WriteLine("Last Even Element in intList {0}", intList2.Last(i => i % 2 == 0));
Console.WriteLine(intList2.LastOrDefault(p => p == 7));

Student st2 = new Student()
{
    StudentID = 1, Age = 15, StudentName = "Deneme", StandardID = 5
};
Student st3 = new Student()
{
    StudentID = 1, Age = 16, StudentName = "Deneme", StandardID = 5
};


IList<Student> students2 = new List<Student>() { st2 };
IList<Student> students3 = new List<Student>() { st3 };


Console.WriteLine("Öğrenci listelere birbirine eşit mi?:" + students2.SequenceEqual(students3));

//StudentComparer referans tiplerinde idlerini kontrol etmek için kullamılır
bool isEqual = students2.SequenceEqual(students3, new StudentComparer());
Console.WriteLine("Student Comparer ile kontrol : " + isEqual);

var concatedStudenList = students3.Concat(students2);

foreach (var student in concatedStudenList)
{
    Console.WriteLine(student.Age);
}


IList<string> emptyList1 = new List<string>();

var newList1 = emptyList1.DefaultIfEmpty();
var newList2 = emptyList1.DefaultIfEmpty("None");

Console.WriteLine("Count " + newList1.Count());
Console.WriteLine("Value : " + newList1.ElementAt(0));

Console.WriteLine("Count : " + newList2.Count());
Console.WriteLine("Value :" + newList2.ElementAt(0));


IList<Student> emptyStudentList = new List<Student>();

var newStudentList1 = studentList.DefaultIfEmpty(new Student());

var newStudentList2 = studentList.DefaultIfEmpty(new Student()
{
    StudentID = 0,
    StudentName = ""
});

Console.WriteLine("Count: {0} ", newStudentList1.Count());
Console.WriteLine("Student ID: {0} ", newStudentList1.ElementAt(0));

Console.WriteLine("Count: {0} ", newStudentList2.Count());
Console.WriteLine("Student ID: {0} ", newStudentList2.ElementAt(0).StudentID);


var intCollection = Enumerable.Range(10, 10).ToList();

Console.WriteLine(intCollection.Count());

foreach (var i in intCollection)
{
    Console.WriteLine($"Value at index :{intCollection.IndexOf(i)} : {i}");
}

Console.WriteLine("*******Enumerable Empty*****5");
var emptyCollection1 = Enumerable.Empty<string>();
var emptyCollection2 = Enumerable.Empty<Student>();

Console.WriteLine($"Count: {emptyCollection1.Count()}");
Console.WriteLine($"Type: {emptyCollection1.GetType().Name}");

Console.WriteLine($"Count: {emptyCollection2.Count()}");
Console.WriteLine($"Type: {emptyCollection2.GetType().Name}");

var intCollection2 = Enumerable.Repeat<int>(10, 10).ToList();

Console.WriteLine($"Total Count : {intCollection2.Count()}");
int sayac = 0;
foreach (var i in intCollection2)
{
    Console.WriteLine($"{sayac} index , deger {i}");
    sayac++;
}

IList<string> strList5 = new List<string>() { "One", "Two", "Three", "Two", "Three" };

IList<int> intList5 = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };


var re = strList5.Distinct().ToList();
var re1 = intList5.Distinct().ToList();

IList<Student> studentList5 = new List<Student>()
{
    new Student() { StudentID = 1, StudentName = "John", Age = 18 },
    new Student() { StudentID = 2, StudentName = "Steve", Age = 15 },
    new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
    new Student() { StudentID = 5, StudentName = "Ron", Age = 19 }
};

IList<Student> studentList7 = new List<Student>()
{
    new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
    new Student() { StudentID = 5, StudentName = "Ron", Age = 19 }
};


var result12 = studentList5.Except(studentList7, new StudentComparer());
Console.WriteLine("*************");
foreach (var student in result12)
{
    Console.WriteLine(student.StudentName + "      ********");
}

IList<int> intList6 = new List<int>() { 1, 2, 4, 3, 5 };
IList<int> intList7 = new List<int>() { 1, 2, 3, 2 };

var result13 = intList7.Except(intList6);

foreach (var student in result13)
{
    Console.WriteLine(student);
}

IList<string> strList8 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
IList<string> strList9 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

var result14 = strList8.Intersect(strList9); //Ortak öğeleri içeren yeni bir koleksiyon döndürür
Console.WriteLine("-*-*-*-*-*-*-*");
foreach (var s in result14)
{
    Console.WriteLine(s);
}

IList<Student> studentList8 = new List<Student>()
{
    new Student() { StudentID = 1, StudentName = "John", Age = 18 },
    new Student() { StudentID = 2, StudentName = "Steve", Age = 15 },
    new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
    new Student() { StudentID = 5, StudentName = "Ron", Age = 19 }
};

IList<Student> studentList9 = new List<Student>()
{
    new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
    new Student() { StudentID = 5, StudentName = "Ron", Age = 19 }
};

Console.WriteLine("**//*/*****");

var result15 = studentList8.Intersect(studentList9, new StudentComparer());


foreach (var student in result15)
{
    Console.WriteLine(student.StudentName);
}


IList<string> strList13 = new List<string>() { "One", "Two", "three", "Four" };
IList<string> strList12 = new List<string>() { "Two", "THREE", "Four", "Five" };

var result16 = strList13.Union(strList12);
Console.WriteLine("*-*-*-*-*-*-*");
foreach (var s in result16)
{
    Console.WriteLine(s);
}

var result18 = studentList8.Union(studentList9, new StudentComparer());
Console.WriteLine("////////////////");
foreach (var student in result18)
{
    Console.WriteLine(student.StudentName);
}


var result19 = strList8.Skip(2);
foreach (var s in result19)
{
    Console.WriteLine(s);
}

IList<string> strList10 = new List<string>()
{
    "One",
    "Two",
    "Three",
    "Four",
    "Five",
    "Six"
};

var result20 = strList10.SkipWhile(p => p.Length <= 3);
Console.WriteLine("***-*-*-*-*-*-*");
foreach (var s in result20)
{
    Console.WriteLine(s);
}

Console.WriteLine("/-/-/-/-/-/-/-/-/-/-/");
var result21 = strList10.SkipWhile((p, i) => p.Length > i);
foreach (var s in result21)
{
    Console.WriteLine(s);
}

Console.WriteLine("*****************");
Action<string> skipeWhilee = (s) =>
{
    if (s.Length > 3)
    {
        Console.WriteLine(s);
    }
};


Console.WriteLine("*-*-*-*-*-*--*");
var result23 = strList10.Take(3);

foreach (var s in result23)
{
    Console.WriteLine(s);
}


// Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;
// Expression.Lambda<Func<Student, bool>>(
//     Expression.AndAlso(
//         Expression.GreaterThan(Expression.Property(pe, "Age"), Expression.Constant(12, typeof(int))),
//         Expression.LessThan(Expression.Property(pe, "Age"), Expression.Constant(20, typeof(int)))),
//     new[] { pe });

Expression<Action<Student>> printStudentName = s => Console.WriteLine(s.StudentName);

Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;

Func<Student, bool> isTeenAger2 = isTeenAgerExpr.Compile();
Console.WriteLine("*-*-*-*-*-*-*-*");
bool sonuc2 = isTeenAger2(new Student() { StudentName = "Deneme", Age = 15 });


var sonuc3 = printStudentName.Compile();

sonuc3(new Student() { StudentName = "Deneme", Age = 15 });


ParameterExpression pe = Expression.Parameter(typeof(Student), "s");
MemberExpression me = Expression.Property(pe, "Age");
ConstantExpression constant = Expression.Constant(18, typeof(int));

BinaryExpression body = Expression.GreaterThanOrEqual(me, constant);

var expressionTree = Expression.Lambda<Func<Student, bool>>(body, new[] { pe });

Console.WriteLine("Expression Tree :" + expressionTree);
Console.WriteLine("Expression Tree Body :" + expressionTree.Body);
Console.WriteLine("Number of Parameters in Expression Tree :" + expressionTree.Parameters.Count);
Console.WriteLine("Parameters in Expression Tree :" + expressionTree.Parameters[0]);

Expression<Func<Student, bool>> deneme = s => s.Age > 12;

Console.WriteLine("*-*-*-**-*-");
Console.WriteLine(deneme);
Console.WriteLine(deneme.Body);
Console.WriteLine(deneme.Parameters.Count);
Console.WriteLine(deneme.Parameters[0].Type);


Expression<Func<Student, bool>> isTeenAgerExpr3 = s => s.Age > 12 && s.Age < 20;
Console.WriteLine("Expression :" + isTeenAgerExpr3);
Console.WriteLine("Expression Type :" + isTeenAgerExpr3.NodeType);
var parameters = isTeenAgerExpr3.Parameters;

Console.WriteLine("--------------");
foreach (var param in parameters)
{
    Console.WriteLine("Parameter Name :" + param.Name);
    Console.WriteLine("Parameter Type :" + param.Type);
}

var bodyExpr = isTeenAgerExpr3.Body as BinaryExpression;

Console.WriteLine("Left side of body expression :" + bodyExpr.Left);
Console.WriteLine("Binary expression type :" + bodyExpr.NodeType);
Console.WriteLine("Right side of body expression :" + bodyExpr.Right);
Console.WriteLine("Return type :" + isTeenAgerExpr3.ReturnType);

IList<Student> studentList2 = new List<Student>()
{
    new Student() { StudentID = 1, StudentName = "John", Age = 13 },
    new Student() { StudentID = 2, StudentName = "Moin", Age = 20 },
    new Student() { StudentID = 3, StudentName = "Bill", Age = 18 },
    new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
    new Student() { StudentID = 5, StudentName = "Jennifer", Age = 18 },
};

var teenAgerStudents =
    from s in studentList2 where s.Age is > 12 and < 20 select s; //Lazy evulation tembel değerlendirme 

foreach (var teenStudent in teenAgerStudents)
{
    Console.WriteLine("Student Name :" + teenStudent.StudentName);
}

studentList2.Add(new Student() { StudentName = "Zeynel", Age = 13 });

foreach (var teenStudent in teenAgerStudents)
{
    Console.WriteLine("Student Name :" + teenStudent.StudentName);
}


IList<Student> studentList3 = new List<Student>()
{
    new Student() { StudentID = 1, StudentName = "John", Age = 13 },
    new Student() { StudentID = 2, StudentName = "Moin", Age = 20 },
    new Student() { StudentID = 3, StudentName = "Bill", Age = 18 },
    new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
    new Student() { StudentID = 5, StudentName = "Jennifer", Age = 18 },
};
Console.WriteLine("*-*--*-*-*--**--*");
var teenAgerStudents2 = from s in studentList3.GetTeenAgerStudents() select s;

foreach (var student in teenAgerStudents2)
{
    Console.WriteLine("Student Name :" + student.StudentName);
}


var lowercaseStudentNames = from s in studentList9
    let lowercaseStudentName = s.StudentName.ToLower()
    where lowercaseStudentName.Contains("r")
    select lowercaseStudentName;


public static class EnumerableExtensionMethods
{
    public static IEnumerable<Student> GetTeenAgerStudents(this IEnumerable<Student> source)
    {
        foreach (Student std in source)
        {
            Console.WriteLine("Veriye Erişiliyor " + std.StudentName);
            if (std.Age > 12 && std.Age < 20)
            {
                yield return std;
            }
        }
    }
}

//Referans tipin değerlerine göre karşılaştırma yapıyor 
class StudentComparer : IEqualityComparer<Student>
{
    public bool Equals(Student x, Student y)
    {
        if (x.StudentID == y.StudentID &&
            x.StudentName.ToLower() == y.StudentName.ToLower())
            return true;

        return false;
    }

    public int GetHashCode(Student obj)
    {
        return obj.GetHashCode();
    }
}


public class Student : IComparable<Student>
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int StandardID { get; set; }
    public int Age { get; set; }

    public int CompareTo(Student other)
    {
        if (this.StudentName.Length >= other.StudentName.Length)
            return 1;

        return 0;
    }
}

public class Standard
{
    public int StandardID { get; set; }
    public string StandardName { get; set; }
}