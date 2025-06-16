using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите массив целых чисел через пробел:");
        string input = Console.ReadLine();
        try
        {
            List<int> numbers = input.Split(' ').Select(int.Parse).ToList();
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Четные элементы: " + string.Join(" ", evenNumbers));
            var endsWithZero = numbers.Where(n => n % 10 == 0);
            Console.WriteLine("Элементы, оканчивающиеся нулем: " + string.Join(" ", endsWithZero));
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введены некорректные числа. Введите целые числа, разделенные пробелами.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }
}

