class LinearEquationError : Exception
{
    public LinearEquationError(string message) : base(message) { }
}

class LinearEquationException : Exception
{
    public double A { get; }
    public double B { get; }
    public LinearEquationException(string message, double a, double b) : base(message)
    {
        A = a;
        B = b;
    }
    public string GetErrorDetails()
    {
        return $"Ошибка: {Message}. A = {A}, B = {B}";
    }
}
class Program
{
    static double CalculateRoot(double a, double b, int exceptionType)
    {
        if (a == 0)
        {
            switch (exceptionType)
            {
                case 1:
                    throw new LinearEquationError("Коэффициент 'a' равен 0.");
                case 2:
                    throw new ArgumentException("Коэффициент 'a' не может быть равен нулю.");
                case 3:
                    throw new LinearEquationException("Линейное уравнение не имеет решения (a = 0).", a, b);
                default:
                    throw new ArgumentException("Неверный тип исключения.");
            }
        }
        return -b / a;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Решение линейного уравнения ax + b = 0");
        Console.WriteLine("Выберите вариант обработки исключений:");
        Console.WriteLine("1. LinearEquationError");
        Console.WriteLine("2. ArgumentException");
        Console.WriteLine("3. ArgumentException (неверный тип)");
        Console.WriteLine("4. LinearEquationException (собственное)");

        int choice;
        while (true)
        {
            Console.Write("Ваш выбор 1, 2, 3 или 4: ");
            string choiceStr = Console.ReadLine();

            if (int.TryParse(choiceStr, out choice) && choice >= 1 && choice <= 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите число от 1 до 4.");
            }
        }
        Console.Write("Введите коэффициент a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Введите коэффициент b: ");
        double b = double.Parse(Console.ReadLine());

        try
        {
            double root = CalculateRoot(a, b, choice);
            Console.WriteLine("Корень уравнения: " + root);
        }
        catch (LinearEquationError ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (LinearEquationException ex)
        {
            Console.WriteLine(ex.GetErrorDetails());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла неожиданная ошибка: " + ex.Message);
        }
    }
}
