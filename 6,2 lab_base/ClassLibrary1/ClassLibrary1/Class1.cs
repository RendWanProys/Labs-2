using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class MatrixOperations
    {
        public static void SwapDiagonals(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) throw new ArgumentException("Матрица должна быть квадратной.");

            int[,] newMatrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) newMatrix[i, j] = matrix[i, n - 1 - i];
                    else if (i == n - 1 - j) newMatrix[i, j] = matrix[i, i];
                    else newMatrix[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = newMatrix[i, j]; // Копирование элемента за элементом
                }
            }
        }
        public static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}