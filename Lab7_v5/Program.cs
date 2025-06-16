using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введите N: ");
        int n = int.Parse(Console.ReadLine());

        List<int> array = new List<int>();
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            array.Add(int.Parse(Console.ReadLine()));
        }

        int min = array.Min();

        Console.WriteLine("Наименьший элемент: " + min);
    }
}
