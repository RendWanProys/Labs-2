public static class InputHelper
{
    public static double GetDoubleFromConsole(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }
    }
}