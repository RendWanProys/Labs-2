class Program
{
    static void Main(string[] mas)
    {
        Console.WriteLine("Введите 17 целых чисел, разделенных пробелами:");
        string[] stroka = Console.ReadLine().Split(' ');

        if (stroka.Length != 17)
        {
            Console.WriteLine("Ошибка: Введено не 17 чисел.");
            return;
        }

        int[] mas1 = new int[17];
        for (int i = 0; i < 17; i++)
        {
            if (!int.TryParse(stroka[i], out mas1[i]))
            {
                Console.WriteLine($"Ошибка: Не удалось преобразовать '{stroka[i]}' в целое число.");
                return;
            }
        }

        long sum = 0;
        int num = 0;
        for (int i = 0; i < 17; i++)
        {
            if (mas1[i] > 0)
            {
                sum += mas1[i];
                num++;
            }
        }

        double srzn = num > 0 ? (double)sum / num : 0;

        long bignum = 0;
        int allnum = 0;
        for (int i = 0; i < 17; i++)
        {
            if (Math.Abs(mas1[i]) > srzn)
            {
                bignum += mas1[i];
                allnum++;
            }
        }

        Console.WriteLine($"Сумма элементов, абсолютное значение которых больше среднего арифметического положительных элементов: {bignum}");
        Console.WriteLine($"Количество таких элементов: {allnum}");
    }
}

