using System;

namespace Lab4
{
    delegate void Task();

    class CLI
    {
        public const char c_cN = 'N';
        public const char c_cK = 'K';
        public const char c_cA = 'A';

        private const int c_iMinK = 1;
        private const int c_iMaxK = 5;
        private const int c_iMinArray = 10;
        private const int c_iMaxArray = 20;
        private const int c_iMinNumber = 100;
        private const int c_iMaxNumber = 999;
        public const int c_iMaxInt = 2147483647;

        private const string c_sElem = "{0} ";
        private const string c_sReadNumber = "Введите {0}: ";
        private const string c_sReadNumberA = "Введите {0}{1}: ";
        private const string c_sGetTask =
            "МЕНЮ\n" +
            "1. Создать массив\n" +
            "2. Удалить четные элементы в массиве\n" +
            "3. Добавить n элементов с k элемента\n" +
            "4. Перевернуть массив\n" +
            "5. Поиск элемента\n" +
            "6. Сортировка массива\n" +
            "0. Выход\n" +
            "Выберете действие: ";
        private const string c_sGetMode = "Введите способ получения чисел (1 - ввод, - 2 случайное): ";
        public const string c_sFoundElem = "Порядковый номер искомого элемента: {0}";
        public const string c_sNotFound = "Элемент не найден";
        public const string c_sNullArray = "Ошибка! Массив не создан.\n";

        private static Random s_rand = new Random();

        public static void Run()
        {
            Task task = null;
            do
            {
                task = GetTask();
                try
                {
                    task();
                }
                catch(NullArrayException)
                {
                    Console.WriteLine(c_sNullArray);
                }
            }
            while (task != null);
        }

        // Запись числа со стандартного потока ввода в выходной параметр
        public static void ReadNum(out int number, char simbol, int i)
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
        public static void RandNum(out int number, char simbol, int i)
        {
            if (simbol == c_cN)
                number = s_rand.Next(c_iMinArray, c_iMaxArray);
            else if (simbol == c_cK)
                number = s_rand.Next(c_iMinK, c_iMaxK);
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

        // Вывод массива
        private static void Output(int[] array)
        {
            for (int i = 0, k = array.Length; i < k; ++i)
                Console.Write(c_sElem, array[i]);
            Console.WriteLine("\n");
        }

        private static void Formation()
        {
            Kernel.Formation(GetMode());
            Output(Kernel.array);
        }

        private static void DeleteElems()
        {
            Kernel.DeleteElems();
            Output(Kernel.array);
        }

        private static void Addition()
        {
            Kernel.Addition(GetMode);
            Output(Kernel.array);
        }

        private static void Reverse()
        {
            Kernel.Reverse();
            Output(Kernel.array);
        }

        private static void FindElem()
        {
            Kernel.FindElem(GetMode);
        }

        private static void InsertSort()
        {
            Kernel.InsertSort();
            Output(Kernel.array);
        }

        private static Task GetTask()
        {
            bool flag = true;
            while(flag)
            {
                Console.Write(c_sGetTask);
                switch (Console.ReadLine())
                {
                    case "1":
                        return Formation;
                    case "2":
                        return DeleteElems;
                    case "3":
                        return Addition;
                    case "4":
                        return Reverse;
                    case "5":
                        return FindElem;
                    case "6":
                        return InsertSort;
                    case "0":
                        flag = false;
                        break;
                }
            }
            return null;
        }
    }
}
