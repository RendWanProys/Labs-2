namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                double a = InputHelper.GetDoubleFromConsole("Введите значение a:");
                double b = InputHelper.GetDoubleFromConsole("Введите значение b:");
                MyObject obj = new MyObject(a, b);
                double result = obj.CalculateSumOfSquares();
                Console.WriteLine($"Сумма квадратов a^2 + b^2 = {result}");
            }
        }
    }
    
