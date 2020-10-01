using System;

// Вариант 15

namespace Lab6
{
    delegate void GetNumber(out int number, char simbol);

    class Program
    {
        private const char c_cN = 'N';
        private const char c_cM = 'M';
        private const char c_cK = 'K';

        private const int c_iCountZero = 2;
        private const int c_iMinArray = 5;
        private const int c_iMaxArray = 15;
        private const int c_iMinNumber = 0;
        private const int c_iMaxNumber = 9;

        private const string c_sElem = "{0} ";
        private const string c_sReadNumber = "Введите {0}: ";
        private const string c_sTask = "Удаление строк с 2 и более нулями";

        private static Random s_rand = new Random();

        static void Main(string[] args)
        {
            int[][] array = GetArray(RandNum);
            Output(array);

            Console.WriteLine(c_sTask);
            DeleteRows(ref array);
            Output(array);

            Console.ReadKey();
        }

        static int[][] GetArray(GetNumber GetNum)
        {
            GetNum(out int n, c_cN);
            int[][] array = new int[n][];
            for(int i = 0; i < n; ++i)
            {
                GetNum(out int m, c_cM);
                array[i] = new int[m];
                for (int j = 0; j < m; ++j)
                {
                    GetNum(out int k, c_cK);
                    array[i][j] = k;
                }
            }
            return array;
        }

        private static void ReadNum(out int number, char simbol)
        {
            number = 0;
            for (bool flag = false; !flag;)
            {
                Console.Write(c_sReadNumber, simbol);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
            }
        }

        private static void RandNum(out int number, char simbol)
        {
            if (simbol == c_cN || simbol == c_cM)
                number = s_rand.Next(c_iMinArray, c_iMaxArray);
            else
                number = s_rand.Next(c_iMinNumber, c_iMaxNumber);
        }

        private static void Output(int[][] array)
        {
            for (int i = 0, n = array.Length; i < n; ++i)
            {
                for (int j = 0, k = array[i].Length; j < k; ++j)
                    Console.Write(c_sElem, array[i][j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void DeleteRows(ref int[][] array)
        {
            for (int i = 0, n = array.Length; i < n; ++i)
            {
                int z = 0;
                for (int j = 0, k = array[i].Length; j < k && z != c_iCountZero; ++j)
                    if (array[i][j] == 0)
                        ++z;
                if (z == c_iCountZero)
                {
                    RemoveRow(ref array, i--);
                    --n;
                }
            }
        }

        private static void RemoveRow(ref int[][] array, int i)
        {
            int n = array.Length - 1;
            int[][] temp = array;
            array = new int[n][];
            for (int j = 0; j < i; ++j)
                array[j] = temp[j];
            for (int j = i; j < n; ++j)
                array[j] = temp[j + 1];
        }
    }
}
