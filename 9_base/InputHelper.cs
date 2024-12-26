namespace ConsoleApp
{
    public static class InputHelper
    {
        public static double GetDoubleFromConsole(string message)
        {
            Console.WriteLine(message);
            return double.Parse(Console.ReadLine());
        }
    }
}
