using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<(double, double)> triangles = new Queue<(double, double)>();
        Console.Write("Введите катет a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Введите катет b: ");
        double b = double.Parse(Console.ReadLine());
        triangles.Enqueue((a, b));
        (double firstA, double firstB) = triangles.Peek();
        double hypotenuse = Math.Sqrt(firstA * firstA + firstB * firstB);
        double perimeter = firstA + firstB + hypotenuse;

        Console.WriteLine("Периметр первого треугольника: " + perimeter);
    }
}
