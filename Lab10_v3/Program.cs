using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите задачу (1 или 2):");
        Console.WriteLine("1. Общие элементы двух списков");
        Console.WriteLine("2. Результаты выборов");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                FindCommonElements();
                break;
            case 2:
                CalculateElectionResults();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }

    static void FindCommonElements()
    {
        Console.WriteLine("Введите первый список чисел через пробел:");
        string input1 = Console.ReadLine();

        Console.WriteLine("Введите второй список чисел через пробел:");
        string input2 = Console.ReadLine();

        try
        {
            List<int> list1 = input1.Split(' ').Select(int.Parse).ToList();
            List<int> list2 = input2.Split(' ').Select(int.Parse).ToList();

            HashSet<int> set1 = new HashSet<int>(list1);
            HashSet<int> set2 = new HashSet<int>(list2);

            set1.IntersectWith(set2); // Находим пересечение

            List<int> result = set1.ToList();
            result.Sort();

            Console.WriteLine("Числа, входящие в оба списка (по возрастанию): " + string.Join(" ", result));
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введены некорректные числа. Пожалуйста, введите целые числа, разделенные пробелами.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    static void CalculateElectionResults()
    {
        Console.Write("Введите количество записей: ");
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, int> votes = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите запись {i + 1} (Фамилия Голоса):");
            string[] input = Console.ReadLine().Split(' ');
            string candidate = input[0];
            int count = int.Parse(input[1]);

            if (votes.ContainsKey(candidate))
            {
                votes[candidate] += count;
            }
            else
            {
                votes.Add(candidate, count);
            }
        }

        var sortedVotes = votes.OrderBy(x => x.Key);

        Console.WriteLine("Результаты выборов:");
        foreach (var pair in sortedVotes)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }
}



