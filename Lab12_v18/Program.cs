using System.Collections.Generic;
using System.Linq;
class Program
{
    class Programmer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public string Education { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}, {BirthDate.ToShortDateString()}";
        }
    }
    static void Main()
    {
        List<Programmer> programmers = new List<Programmer>()
        {
            new Programmer { LastName = "Иванов", FirstName = "Иван", MiddleName = "Иванович", BirthDate = new DateTime(2000, 05, 10) },
            new Programmer { LastName = "Петров", FirstName = "Петр", MiddleName = "Петрович", BirthDate = new DateTime(1990, 10, 15) },
            new Programmer { LastName = "Сидоров", FirstName = "Сидор", MiddleName = "Сидорович", BirthDate = new DateTime(2002, 01, 20) }
        };
        var youngProgrammers = programmers.Where(p => DateTime.Now.Year - p.BirthDate.Year < 25);
        Console.WriteLine("Программисты младше 25 лет:");
        foreach (var programmer in youngProgrammers)
        {
            Console.WriteLine(programmer);
        }
    }
}

