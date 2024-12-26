public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Введите значения для нового объекта (или 'exit' для завершения):");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
                break;
            double a = InputHelper.GetDoubleFromConsole("Введите значение A: ");
            double b = InputHelper.GetDoubleFromConsole("Введите значение B: ");
            MyObject currentObject = new MyObject(a, b);

            double result = currentObject.CalculateSumOfSquares();
            Console.WriteLine($"A: {currentObject.A}, B: {currentObject.B}, A^2 + B^2: {result}\n");
        }
        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}