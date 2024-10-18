try
{
    Console.WriteLine("Введите X");
    int x = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите Y");
    int y = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите радиус");
    int R = Convert.ToInt32(Console.ReadLine());
    double distance = Math.Sqrt(x * x + y * y);
    if (distance <= R)
    {
        Console.WriteLine($"данная точка лежит внутри круга ({x},{y})");
    }
    else
    {
        Console.WriteLine($"данная точка не лежит внутри круга ({x},{y})");
    }
}
catch
{
    Console.WriteLine("Некорретктные данные");
}