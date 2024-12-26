//middle
using System;
struct FootballPlayer
{
    public string LastName;
    public DateTime DateOfBirth;
    public string Club;
    public string Position;
    public int GamesPlayed;
    public string BirthPlace;
    public FootballPlayer(string lastName, DateTime dateOfBirth, string club, string position, int gamesPlayed, string birthPlace)
    {
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Club = club;
        Position = position;
        GamesPlayed = gamesPlayed;
        BirthPlace = birthPlace;
    }

    public void Print()
    {
        Console.WriteLine($"Фамилия: {LastName}, Дата рождения: {DateOfBirth.ToShortDateString()}, Клуб: {Club}, Амплуа: {Position}, Сыграно матчей: {GamesPlayed}, Место рождения: {BirthPlace}");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        FootballPlayer[] players = new FootballPlayer[5];
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"\nВведите данные для игрока {i + 1}:");
            Console.Write("Введите фамилию:");
            string lastName = Console.ReadLine();
            Console.Write("Введите дату рождения (гггг-мм-дд):");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите клуб:");
            string club = Console.ReadLine();
            Console.Write("Введите амплуа:");
            string position = Console.ReadLine();
            Console.Write("Введите количество сыгранных матчей:");
            int gamesPlayed = int.Parse(Console.ReadLine());
            Console.Write("Введите место рождения:");
            string birthPlace = Console.ReadLine();
            players[i] = new FootballPlayer(lastName, dateOfBirth, club, position, gamesPlayed, birthPlace);
        }
        Console.WriteLine("\nЗащитники младше 20 лет, сыгравшие более 40 матчей:");
        bool foundPlayers = false;
        foreach (FootballPlayer player in players)
        {
            int age = DateTime.Now.Year - player.DateOfBirth.Year;
            if (DateTime.Now.Month < player.DateOfBirth.Month || (DateTime.Now.Month == player.DateOfBirth.Month && DateTime.Now.Day < player.DateOfBirth.Day))
            {
                age--;
            }
            if (player.Position.ToLower() == "защитник" && age < 20 && player.GamesPlayed > 40)
            {
                player.Print();
                foundPlayers = true;
            }
        }
        if (!foundPlayers)
            Console.WriteLine("Не найдено защитников, младше 20 лет, сыгравших более 40 матчей.");
    }
}
