using System;

// Вариант 15

namespace Task1
{
    delegate void GetNumber(out int number, char simbol, int i = -1, int j = -1);
    delegate bool IsValidate(int x, int top);

    public class Program
    {
        private const char c_cN = 'N';
        private const char c_cM = 'M';
        public const char c_cA = 'A';

        private const int c_iCountZero = 2;
        private const int c_iMinArray = 5;
        private const int c_iMaxArray = 15;
        private const int c_iMinNumber = 0;
        private const int c_iMaxNumber = 9;
        public const int c_iMaxInt = 2147483647;

        private const string c_sElem = "{0} ";
        private const string c_sReadNumber = "Введите {0}: ";
        private const string c_sReadNumberA = "Введите {0}({1},{2}): ";
        private const string c_sIncorrectValue = "Некорректное значение!";
        private const string c_sTask = "Удаление строк с 2 и более нулями";
        private const string c_sContinue = "Продолжить? (д - да, другое - выход)";
        private const string c_sExit = "Спасибо за работу!";
        private const string c_sGetMode =
            "Введите способ получения чисел (1 - ввод, - 2 случайное): ";

        private static Random s_rand = new Random();
        private static IsValidate IsValid = (x, top) => (x >= 0 && x <= top);

        static void Main(string[] args)
        {
            do
            {
                int[][] array = GetArray(GetMode());
                Output(array);

                Console.WriteLine(c_sTask);
                DeleteRows(ref array);
                Output(array);

                Console.WriteLine(c_sContinue);
            }
            while (Console.ReadLine() == "д");
            Console.WriteLine(c_sExit);
            Console.ReadKey();
        }

        static int[][] GetArray(GetNumber GetNum)
        {
            GetValid(out int n, GetNum, c_cN, c_iMaxInt);
            int[][] array = new int[n][];
            for(int i = 0; i < n; ++i)
            {
                GetValid(out int m, GetNum, c_cM, c_iMaxInt);
                array[i] = new int[m];
                for (int j = 0; j < m; ++j)
                {
                    GetNum(out int a, c_cA, i, j);
                    array[i][j] = a;
                }
            }
            return array;
        }

        public static void ReadNum(out int number, char simbol, int i, int j)
        {
            number = 0;
            for (bool flag = false; !flag;)
            {
                if (i == -1)
                    Console.Write(c_sReadNumber, simbol);
                else
                    Console.Write(c_sReadNumberA, simbol, i, j);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
                if (!flag)
                    IncorrectValue();
            }
        }

        public static void RandNum(out int number, char simbol, int i, int j)
        {
            if (simbol == c_cN || simbol == c_cM)
                number = s_rand.Next(c_iMinArray, c_iMaxArray);
            else
                number = s_rand.Next(c_iMinNumber, c_iMaxNumber);
        }

        private static GetNumber GetMode()
        {
            string key = "";
            do
            {
                Console.Write(c_sGetMode);
                key = Console.ReadLine();
            } while (key != "1" && key != "2");
            if (key == "1")
                return ReadNum;
            else
                return RandNum;
        }

        public static void IncorrectValue()
        {
            Console.WriteLine(c_sIncorrectValue);
        }

        private static void GetValid(out int number, GetNumber GetNum, char simbol, int top)
        {
            while (true)
            {
                GetNum(out number, simbol);
                if (IsValid(number, top))
                    break;
                else
                    IncorrectValue();
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
            Console.WriteLine();
        }

        public static void DeleteRows(ref int[][] array)
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
