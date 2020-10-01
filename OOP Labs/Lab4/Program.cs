using System;

// Вариант 15

namespace Lab4
{
    delegate void GetNumber(out int number, char simbol, int i = -1);
    delegate bool IsValidate(int x, int top);

    class Program
    {
        private const char c_cN = 'N';
        private const char c_cK = 'K';
        private const char c_cA = 'A';

        private const int c_iMinK = 1;
        private const int c_iMaxK = 5;
        private const int c_iMinArray = 10;
        private const int c_iMaxArray = 20;
        private const int c_iMinNumber = 100;
        private const int c_iMaxNumber = 999;
        private const int c_iMaxInt = 2147483647;

        private const string c_sElem = "{0} ";
        private const string c_sReadNumber = "Введите {0}: ";
        private const string c_sReadNumberA = "Введите {0}{1}: ";
        private const string c_sFoundElem = "Порядковый номер искомого элемента: {0}";
        private const string c_sNotFound = "Элемент не найден";

        private static Random s_rand = new Random();
        private static IsValidate IsValid = (x, top) => (x >= 0 && x < top);

        public static void Main(string[] args)
        {
            Run(RandNum);
            Console.ReadKey();
        }

        private static void Run(GetNumber GetNum)
        {
            Formation(out int[] array, GetNum);
            Output(array);

            DeleteElems(ref array);
            Output(array);

            Addition(ref array, GetNum);
            Output(array);

            Reverse(array);
            Output(array);

            FindElem(array, GetNum);

            InsertSort(array);
            Output(array);
        }

        // Запись числа со стандартного потока ввода в выходной параметр
        private static void ReadNum(out int number, char simbol, int i)
        {
            number = 0;
            for (bool flag = false; !flag;)
            {
                if (simbol == c_cN || simbol == c_cK)
                    Console.Write(c_sReadNumber, simbol);
                else
                    Console.Write(c_sReadNumberA, simbol, i);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
            }
        }

        // Запись случайного числа в выходной параметр
        private static void RandNum(out int number, char simbol, int i)
        {
            if (simbol == c_cN)
                number = s_rand.Next(c_iMinArray, c_iMaxArray);
            else if (simbol == c_cK)
                number = s_rand.Next(c_iMinK, c_iMaxK);
            else
                number = s_rand.Next(c_iMinNumber, c_iMaxNumber);
        }

        // Получение валидного числа
        private static void GetValid(out int number, GetNumber GetNum, char simbol, int top)
        {
            do GetNum(out number, simbol);
            while (!IsValid(number, top));
        }

        // Вывод массива
        private static void Output(int[] array)
        {
            for (int i = 0, k = array.Length; i < k; ++i)
                Console.Write(c_sElem, array[i]);
            Console.WriteLine("\n");
        }

        // Создание массива
        private static void Formation(out int[] array, GetNumber GetNum)
        {
            GetValid(out int n, GetNum, c_cN, c_iMaxInt);
            array = new int[n];
            for (int i = 0; i < n; ++i)
                GetNum(out array[i], c_cA, i);
        }

        // Удаление всех элементов с четными индексами
        private static void DeleteElems(ref int[] array)
        {
            int[] temp = array;
            int n = temp.Length / 2;
            array = new int[n];
            for (int i = 0; i < n; ++i)
                array[i] = temp[i * 2 + 1];
        }

        // Добавление n элементов, начиная с k
        private static void Addition(ref int[] array, GetNumber GetNum)
        {
            int oldSize = array.Length;
            GetValid(out int n, GetNum, c_cN, c_iMaxInt - oldSize);
            GetValid(out int k, GetNum, c_cK, oldSize);
            int newSize = oldSize + n;
            int[] temp = array;
            array = new int[newSize];
            for (int i = 0; i < k; ++i)
                array[i] = temp[i];
            for (int i = k, j = k + n; i < j; ++i)
                GetNum(out array[i], c_cA, i);
            for (int i = k + n; i < newSize; ++i)
                array[i] = temp[i - n];
        }

        // Переворот массива
        private static void Reverse(int[] array)
        {
            int N = array.Length - 1;
            int n = N / 2;
            for (int i = 0; i < n; ++i)
            {
                int temp = array[i];
                array[i] = array[N - i];
                array[N - i] = temp;
            }
        }

        // Поиск элемента по значению
        private static void FindElem(int[] array, GetNumber GetNum)
        {
            GetNum(out int k, c_cK);
            int n = 0;
            try
            {
                while (array[n++] != k) ;
                Console.WriteLine(c_sFoundElem, n);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(c_sNotFound);
            }
            finally
            {
                Console.WriteLine();
            }
        }

        // Сортировка вставками
        private static void InsertSort(int[] array)
        {
            int i, j, temp, n = array.Length;
            for (i = 0; i < n; i++)
            {
                temp = array[i];
                for (j = i - 1; j >= 0 && array[j] > temp; j--)
                    array[j + 1] = array[j];
                array[j + 1] = temp;
            }
        }
    }
}
