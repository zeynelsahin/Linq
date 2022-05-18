using System.Security.Cryptography;

Console.WriteLine("Hello, World!");
List<Person> persons = new List<Person>()
{
    new Person() { Id = 1, FirstName = "Zeynel", LastName = "Şahinn" },
    new Person() { Id = 2, FirstName = "Hatice", LastName = "Şahin" },
    new Person() { Id = 3, FirstName = "Hatice", LastName = "Şahin" }
};
string[] names = new[] { "Zeynel", "Şahin", "Kartal" };

int[] numbers = new int[] { 1, 2, 3, 4, 5 };


int result = numbers.Aggregate((a, b) => a * 2);
result = numbers.Aggregate(10, (a, b) => a + b);
var result2 = numbers.Average(); //dizi ortalamasını hesaplar
var result3 = persons.Count();
var result4 = persons.LongCount();
var result5 = persons.Max(p => p.Id); //en büyük değeri verir Min() de en küçük değeri verir
var result6 = names.AsEnumerable();
foreach (var s in result6)
{
    Console.WriteLine(s);
}

List<string> sebzeler = new List<string>() { "Marul", "Ispanak", "Pırasa" };

var result7 = sebzeler.Cast<int>();

//OfType
object[] objects =new object[] { "Thomas", 31, 5.02, null ,"Joey"};

var result8 = objects.OfType<string>();
foreach (var s in result8)
{
    Console.WriteLine(s);
}

//OfType Bitiş

//ToArray,ToDictionary

int[] number1 = { 1, 2, 3 };
var result9 = number1.ToArray();

List<Person> persons1 = new List<Person>()
{
    new Person() { Id = 1, FirstName = "Zeynel", LastName = "Şahinn" },
    new Person() { Id = 2, FirstName = "Hatice", LastName = "Şahin" },
    new Person() { Id = 3, FirstName = "Hatice", LastName = "Şahin" }
};

var result10 = persons1.ToDictionary(p => p.Id, v => v.FirstName);
var result11 = persons1.ToDictionary(p => p.Id, v => v.FirstName=="Zeynel"?"Oğul":"Anne");
var result12 = number1.ToList();//koleksiyonları listeye çevirir
foreach (var keyValuePair in result11)
{
    Console.WriteLine($"Key: {keyValuePair.Key} , Value: {keyValuePair.Value}");
}

var result13 = sebzeler.ElementAt(0);


var result14 = persons.Single(p => p.Id == 1);


var result15 = persons.DefaultIfEmpty();




Console.WriteLine($"Result : {result}");
Console.WriteLine($"Result 2: {result2}");
Console.WriteLine($"Result3 count: {result3}");
Console.WriteLine($"Result 5 listenin en büyük değeri: {result5}");
Console.WriteLine($"Result 14: {result14.FirstName}");

void Toplama()
{
    int toplamId = persons.Sum(p => p.Id); //Idlerin toplamını verir
    Console.WriteLine($"Toplam Id {toplamId}");

    toplamId = persons.Where(p => p.FirstName == "Hatice").Sum(p => p.Id);

    Console.WriteLine($"FirstName Hatice ise toplam id ={toplamId}");
}

//persons = persons.Where(p => p.FirstName.Contains("Z")).ToList();
//persons = (persons.OrderByDescending(p => p.FirstName).ThenByDescending(p=>p.Id).ToList());


// Toplama();
// Listele();
void GetPersonById()
{
    Person person = persons.Find(p => p.Id == 1);
    Console.WriteLine(person.FirstName);

    person.FirstName = "Muharrem";
}

void Listele()
{
    foreach (var person in persons)
    {
        Console.WriteLine(person.Id + " ," + person.FirstName + ", " + person.LastName);
    }

    Console.WriteLine(persons.Count());
}

// Listele();

class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}


