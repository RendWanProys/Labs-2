namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = InputHelper.GetDoubleFromConsole("Введите значение a:");
            double b = InputHelper.GetDoubleFromConsole("Введите значение b:");
            double c = InputHelper.GetDoubleFromConsole("Введите значение c:");
            MyDerivedObject derivedObj = new MyDerivedObject(a, b, c);
            try {
                double result = derivedObj.CalculateSumOfSquares();
                Console.WriteLine($"Корень уравнения ax+b=c: x = {result}");
            } catch(ArgumentException e) {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
    }
}
