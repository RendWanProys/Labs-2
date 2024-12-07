public class programm
{
    public static int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    public static int FindLCM(int a, int b)
    {
        if (a == 0 || b == 0)
        {
            return 0;
        }
        return (a * b) / FindGCD(a, b);
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите первое натуральное число:");
        int num1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите второе натуральное число:");
        int num2 = int.Parse(Console.ReadLine());

        if (num1 <= 0 || num2 <= 0)
        {
            Console.WriteLine("Числа должны быть натуральными (больше 0)");
            return;
        }
        int lcm = FindLCM(num1, num2);
        Console.WriteLine($"Наименьшее общее кратное {num1} и {num2} равно: {lcm}");
    }
}

