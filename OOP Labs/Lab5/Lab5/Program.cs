using System;

// Вариант 15

namespace Lab5
{
    delegate void GetNumber(out int number, char simbol, int i = -1, int j = -1);

    class Program
    {
        private const char c_cN = 'N';
        private const char c_cM = 'M';
        private const char c_cK = 'K';
        private const char c_cA = 'A';

        private const int c_iMinK = 1;
        private const int c_iMaxK = 5;
        private const int c_iMinArray = 10;
        private const int c_iMaxArray = 20;
        private const int c_iMinNumber = 100;
        private const int c_iMaxNumber = 999;

        private const string c_sElem = "{0} ";
        private const string c_sReadNumber = "Введите {0}: ";
        private const string c_sReadNumberA = "Введите {0}{1}: ";
        private const string c_sReadNumberA2 = "Введите {0}({1},{2}): ";

        private static Random s_rand = new Random();

        public static void Main(string[] args)
        {
            Formation(out int[] array1, RandNum);
            Output(array1);
            Console.WriteLine();
            Addition(ref array1, RandNum);
            Output(array1);
            Console.WriteLine();

            Formation(out int[,] array2, RandNum);
            Output(array2);
            Console.WriteLine();
            DeleteElems(ref array2);
            Output(array2);
            Console.WriteLine();

            Formation(out int[][] array3, RandNum);
            Output(array3);
            Console.WriteLine();
            Addition(ref array3, RandNum);
            Output(array3);
            Console.WriteLine();

            Console.ReadKey();
        }

        private static void ReadNum(out int number, char simbol, int i, int j)
        {
            number = 0;
            for (bool flag = false; !flag;)
            {
                if (i == -1)
                    Console.Write(c_sReadNumber, simbol);
                else if (j == -1)
                    Console.Write(c_sReadNumberA, simbol, i);
                else
                    Console.Write(c_sReadNumberA2, simbol, i, j);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
            }
        }

        private static void RandNum(out int number, char simbol, int i, int j)
        {
            if (simbol == c_cN || simbol == c_cM)
                number = s_rand.Next(c_iMinArray, c_iMaxArray);
            else if (simbol == c_cK)
                number = s_rand.Next(c_iMinK, c_iMaxK);
            else
                number = s_rand.Next(c_iMinNumber, c_iMaxNumber);
        }

        private static void Formation(out int[] array, GetNumber GetNum)
        {
            GetNum(out int n, c_cN);
            array = new int[n];
            for (int i = 0; i < n; ++i)
                GetNum(out array[i], c_cA);
        }

        private static void Formation(out int[,] array, GetNumber GetNum)
        {
            GetNum(out int n, c_cN);
            GetNum(out int m, c_cM);
            array = new int[n, m];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    GetNum(out array[i, j], c_cA, i, j);
        }

        private static void Formation(out int[][] array, GetNumber GetNum)
        {
            GetNum(out int n, c_cN);
            array = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                GetNum(out int m, c_cM);
                array[i] = new int[m];
                for (int j = 0; j < m; ++j)
                    GetNum(out array[i][j], c_cA, i, j);
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
                    Console.Write(c_sElem, array[i, j]);
                Console.WriteLine();
            }
        }

        private static void Output(int[][] array)
        {
            for (int i = 0, n = array.Length; i < n; ++i)
            {
                for (int j = 0, k = array[i].Length; j < k; ++j)
                    Console.Write(c_sElem, array[i][j]);
                Console.WriteLine();
            }
        }

        private static void Addition(ref int[] array, GetNumber GetNum)
        {
            GetNum(out int n, c_cN);
            GetNum(out int k, c_cK);
            int[] temp = array;
            int sizeT = temp.Length;
            int sizeN = sizeT + n;
            array = new int[sizeN];
            for (int i = 0; i < k; ++i)
                array[i] = temp[i];
            for (int i = k, j = k + n; i < j; ++i)
                GetNum(out array[i], c_cA, i);
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

        private static void Addition(ref int[][] array, GetNumber GetNum)
        {
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
            GetNum(out int m, c_cM);
            array[n] = new int[m];
            for (int i = 0; i < m; ++i)
                GetNum(out array[n][i], c_cA, n, i);
        }
    }
}
