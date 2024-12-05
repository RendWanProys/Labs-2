class Program
{
    static void Main()
    {
        int n = 5;
        int m = 5;
        Random random = new Random();
        int[,] mas = new int[n, m];
        for (int i = 0; i < mas.GetLength(0); i++)
        {
            for (int j = 0; j < mas.GetLength(1); j++)
            {
                mas[i, j] = random.Next(1,5);
                Console.Write(mas[i, j] + " ");
            }
        Console.WriteLine();
        }
        int[] lastColumn = new int[n];
        for (int i = 0; i < n; i++)
        {
            lastColumn[i] = mas[i, m - 1];
        }
        Array.Sort(lastColumn);
        int CollumnsSchcet = 0;
        for (int j = 0; j < m - 1; j++)
        {
            int[] ColumnSet = new int[n];
            for (int i = 0; i < n; i++)
            {
                ColumnSet[i] = mas[i, j];
            }
            Array.Sort(ColumnSet);
            bool CollumnSravnenie = true;
            for (int k = 0; k < n; k++)
            {
                if (ColumnSet[k] != lastColumn[k])
                {
                    CollumnSravnenie = false;
                    break;
                }
            }
            if (CollumnSravnenie)
            {
                CollumnsSchcet++;
            }
        }
        Console.WriteLine("Количество столбцов, похожих на последний: " + CollumnsSchcet);
    }
}