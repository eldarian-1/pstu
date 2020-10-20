using System;

namespace Lab7
{
    static class Kernel
    {
        public static int[] Array1D
            = new int[] { 13, 14, 15 };

        public static int[,] Array2D = new int[3, 4] {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 }
        };

        public static int[][] ArrayJagged = new int[][] {
            new int[] { 1, 2, 3, 4 },
            new int[] { 1, 2, 3 },
            new int[] { 1, 2, 3, 4, 5 }
        };

        // Добавление N элементов после K элемента в одномерный массив
        public static void Addition(ref int[] array, int n, int k)
        {
            int oldSize = array.Length;
            int newSize = oldSize + n;
            if(k > oldSize || oldSize >= newSize)
                throw new Exception();
            int[] temp = array;
            array = new int[newSize];
            for (int i = 0; i < k; ++i)
                array[i] = temp[i];
            for (int i = k, j = k + n; i < j; ++i)
                array[i] = 0;
            for (int i = k + n; i < newSize; ++i)
                array[i] = temp[i - n];
        }

        // Удаление четных строк в двумерном массиве
        public static void DropEven(ref int[,] array)
        {
            int[,] temp = array;
            int n = array.GetUpperBound(0) + 1;
            if (n == 0)
                return;
            int k = array.Length / n;
            int m = n / 2;
            array = new int[m, k];
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < k; ++j)
                    array[i, j] = temp[i * 2 + 1, j];
        }

        // Добавление строки в конец рваного массива
        public static void AdditionLine(ref int[][] array)
        {
            int[][] temp = array;
            int n = temp.Length;
            array = new int[n + 1][];
            for (int i = 0; i < n; ++i)
                array[i] = temp[i];
            array[n] = new int[] { 0 };
        }
    }
}
