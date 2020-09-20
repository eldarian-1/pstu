using System;

namespace Lab5
{
    class Program
    {
        private const int c_iMinArray = 10;
        private const int c_iMaxArray = 20;
        private const int c_iMinNumber = 100;
        private const int c_iMaxNumber = 999;
        private const string c_sElem = "{0} ";

        public static void Main(string[] args)
        {
            Formation(out int[] array1);
            Output(array1);
            Console.WriteLine();
            Addition(ref array1, 13, 5);
            Output(array1);
            Console.WriteLine();

            Formation(out int[,] array2);
            Output(array2);
            Console.WriteLine();
            DeleteElems(ref array2);
            Output(array2);
            Console.WriteLine();

            Formation(out int[][] array3);
            Output(array3);
            Console.WriteLine();
            Addition(ref array3);
            Output(array3);
            Console.WriteLine();

            Console.ReadKey();
        }

        private static void Formation(out int[] array)
        {
            Random rand = new Random();
            int n = rand.Next(c_iMinArray, c_iMaxArray);
            array = new int[n];
            for (int i = 0; i < n; ++i)
                array[i] = rand.Next(c_iMinNumber, c_iMaxNumber);
        }

        private static void Formation(out int[,] array)
        {
            Random rand = new Random();
            int n = rand.Next(c_iMinArray, c_iMaxArray);
            int m = rand.Next(c_iMinArray, c_iMaxArray);
            array = new int[n, m];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    array[i, j] = rand.Next(c_iMinNumber, c_iMaxNumber);
        }

        private static void Formation(out int[][] array)
        {
            Random rand = new Random();
            int n = rand.Next(c_iMinArray, c_iMaxArray);
            array = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                int m = rand.Next(c_iMinArray, c_iMaxArray);
                array[i] = new int[m];
                for (int j = 0; j < m; ++j)
                    array[i][j] = rand.Next(c_iMinNumber, c_iMaxNumber);
            }
        }

        private static void Output(int[] array)
        {
            for (int i = 0, n = array.Length; i < n; ++i)
                Console.Write(c_sElem, array[i]);
            Console.WriteLine();
        }

        private static void Output(int[,] array)
        {
            int n = array.GetUpperBound(0) + 1;
            int k = array.Length / n;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < k; ++j)
                {
                    Console.Write(c_sElem, array[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Output(int[][] array)
        {
            for (int i = 0, n = array.Length; i < n; ++i)
            {
                for (int j = 0, k = array[i].Length; j < k; ++j)
                {
                    Console.Write(c_sElem, array[i][j]);
                }
                Console.WriteLine();
            }
        }

        private static void Addition(ref int[] array, int n, int k)
        {
            Random rand = new Random();
            int[] temp = array;
            int sizeT = temp.Length;
            int sizeN = sizeT + n;
            array = new int[sizeN];
            for (int i = 0; i < k; ++i)
                array[i] = temp[i];
            for (int i = k, j = k + n; i < j; ++i)
                array[i] = rand.Next(c_iMinNumber, c_iMaxNumber);
            for (int i = k + n; i < sizeN; ++i)
                array[i] = temp[i - n];
        }

        private static void DeleteElems(ref int[,] array)
        {
            int[,] temp = array;
            int n = array.GetUpperBound(0) + 1;
            int k = array.Length / n;
            int m = n / 2;
            array = new int[m, k];
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < k; ++j)
                    array[i, j] = temp[i * 2, j];
        }

        private static void Addition(ref int[][] array)
        {
            Random rand = new Random();
            int[][] temp = array;
            int n = temp.Length;
            array = new int[n + 1][];
            for (int i = 0; i < n; ++i)
            {
                int k = temp[i].Length;
                array[i] = new int[k];
                for (int j = 0; j < k; ++j)
                    array[i][j] = temp[i][j];
            }
            int m = rand.Next(c_iMinArray, c_iMaxArray);
            array[n] = new int[m];
            for (int i = 0; i < m; ++i)
                array[n][i] = rand.Next(c_iMinNumber, c_iMaxNumber);
        }
    }
}
