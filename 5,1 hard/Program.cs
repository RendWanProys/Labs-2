//1) Вводим данные
//2) Создаем массив
//3) Проверка на 1 = 1 ... 5 = 5
//4) if true, else false.
//Console.WriteLine("Введите слово:");
//char Console.ReadLine();
//char[] mas = new char[5];

class Program
{
    static void Main(string[] mas)
    {
        Console.WriteLine("Введите 5 символов:");
        string stroka = "";
        for (int i = 0; i < 5; i++)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (char.IsLetterOrDigit(key.KeyChar))
            {
                stroka += key.KeyChar;
                Console.Write(key.KeyChar);
            }
            else
            {
                Console.WriteLine("\nНеверный ввод. Введите букву или цифру.");
                return; // Прерываем программу при ошибке
            }
        }
        Console.WriteLine();
        char[] mas1 = stroka.ToCharArray();
        bool palindrome = true;
        for (int i = 0; i < mas1.Length / 2; i++)
        {
            if (char.ToUpperInvariant(mas1[i]) != char.ToUpperInvariant(mas1[mas1.Length - 1 - i]))
            {
                palindrome = false;
                break;
            }
        }

        Console.WriteLine(palindrome ? "Палиндром" : "Не палиндром");
    }
}

