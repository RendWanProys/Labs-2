try
{
    Console.WriteLine("Введите число:");
    int A = int.Parse(Console.ReadLine());
    if (A % 2 == 0 || A % 3 == 0)
    {
        Console.WriteLine("Число подходит");
    }
    else
    {
        Console.WriteLine("Число не подходит");
    }
}
catch
{
    Console.WriteLine("Некорректные данные");
} 