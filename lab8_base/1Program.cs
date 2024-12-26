public class 1Program
{
    static void Main(string[] args)
    {
        DateTime time;
        Console.WriteLine("Введите дату и время (гггг-мм-дд чч:мм):");
        string vrema = Console.ReadLine();
        while (true)
        {
            if (DateTime.TryParse(vrema, out time))
            {
                break;
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
        DateTime startmonth = new DateTime(time.Year, time.Month, 1, 0, 0, 0);
        TimeSpan timehours = time - startmonth;
        double hours = timehours.TotalHours;
        Console.WriteLine($"Введенная дата и время: {time}");
        Console.WriteLine($"Прошло часов от начала месяца: {hours}");
    }
}
