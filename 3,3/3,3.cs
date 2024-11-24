try
{
    Console.WriteLine("Введите количество повторений");
    int n= int.Parse(Console.ReadLine());
    if (n <= 0)
    {
        Console.WriteLine("не должно быть меньше 0.");
        return;
    }
    Console.WriteLine("Введите условия x");
    double sum = 0;
    int x = int.Parse(Console.ReadLine());
    if (x == -1)
        {
        Console.WriteLine("Х не должен быть -1");
        }

    for (int j = 1; j <= 2 * n - 1; j += 2)
    {
        double res = 1 / j * Math.Pow((x - 1) / (x + 1), j);
        sum += res;
    }
    Console.WriteLine(sum);
}
catch
{
    Console.WriteLine("Ошибка!");
}