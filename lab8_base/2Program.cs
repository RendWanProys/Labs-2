public class programm
{
    public static void Main(string[] args)
    {
        DateTime birth;
        while (true)
        {
            Console.WriteLine("Введите дату рождения сотрудника (гггг-мм-дд):");
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out birth))
            {
                break;
            }
            else
            {
                Console.WriteLine("Неверный формат даты. Попробуйте еще раз.");
            }
        }
        Console.WriteLine("\nЮбилейные даты:");
        for (int age = 5; age <= 100; age += 5)
        {
            DateTime jubel = birth.AddYears(age);
            int dayOfWeek = (int)jubel.DayOfWeek == 0 ? 7 : (int)jubel.DayOfWeek;
            Console.WriteLine($"{jubel:yyyy-MM-dd} - {jubel.Year - birth.Year} лет - День недели: {dayOfWeek}");
        }
    }
}
