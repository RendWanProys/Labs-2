try
{
    {
        Console.WriteLine("Вводите числа, отрицательное число завершает ввод:");
        double number;
        bool minus = false;
        List<double> numbers = new List<double>();
        do
        {
            if (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Некорректный ввод. Введите число.");
                continue;
            }
            if (number < 0)
            {
                minus = true;
            }
            else if (!minus)
            {
                numbers.Add(number);
            }
        } while (!minus);

        Console.WriteLine("Числа в интервале от 3 до 13: ");
        foreach (double num in numbers)
        {
            if (num >= 3 && num <= 13)
            {
                Console.Write(num + " ");
            }
        }
        Console.WriteLine();
    }
}
catch
{
    
}