try
{
    Console.WriteLine("Введите координаты точки A через запятуюя (x0, y0):");
    string[] A = Console.ReadLine().Split(',');
    int x0 = int.Parse(A[0]);
    int y0 = int.Parse(A[1]);
    Console.WriteLine("Введите координаты точки B (x1, y1):");
    string[] B = Console.ReadLine().Split(',');
    int x1 = int.Parse(B[0]);
    int y1 = int.Parse(B[1]);
    double distanceA = Math.Sqrt(Math.Pow(x0, 2) + Math.Pow(y0, 2));
    double distanceB = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
    if (distanceA < distanceB)
    {
        Console.WriteLine("Точка A ближе к началу координат.");
    }
    else if (distanceB < distanceA)
    {
        Console.WriteLine("Точка B ближе к началу координат.");
    }
    else
    {
        Console.WriteLine("Точки A и B находятся на одинаковом расстоянии от начала координат.");
    }
}
catch
{
    Console.WriteLine("Введите данные правильно");
}