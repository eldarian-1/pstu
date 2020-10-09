using System;

namespace Lab5
{
    delegate void Task();

    class CLI
    {
        public const char c_cN = 'N';
        public const char c_cM = 'M';
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
        private const string c_sReadNumberA2 = "Введите {0}({1},{2}): ";
        private const string c_sIncorrectValue = "Некорректное значение!";
        private const string c_sNullArray = "Ошибка! Массив не создан.\n";
        private const string c_sCleanArray = "Массив пуст, поэтому удален.\n";
        private const string c_sNullFunction = "Спасибо за работу!";
        private const string c_sGetMode =
            "Введите способ получения чисел (1 - ввод, - 2 случайное): ";
        private const string c_sGetTask =
            "МЕНЮ\n" +
            "Одномерный массив\n" +
            "\t1. вывести массив\n" +
            "\t2. cоздать массив\n" +
            "\t3. добавить N элементов, начиная с K элемента\n" +
            "Двемерный массив\n" +
            "\t4. вывести массив\n" +
            "\t5. создать массив\n" +
            "\t6. удалить чентные строки в массиве\n" +
            "Рваный массив\n" +
            "\t7. вывести массив\n" +
            "\t8. создать массив\n" +
            "\t9. добавть строку в конец массива\n" +
            "0. Выход\n" +
            "Выберете действие: ";

        private static Random s_rand = new Random();

        public static void Run()
        {
            while (true)
            {
                try
                {
                    GetTask()();
                }
                catch (NullArrayException)
                {
                    Console.WriteLine(c_sNullArray);
                }
                catch (CleanArrayException)
                {
                    Console.WriteLine(c_sCleanArray);
                }
                catch (NullFunctionException)
                {
                    Console.Write(c_sNullFunction);
                    break;
                }
            }
        }

        public static void ReadNum(out int number, char simbol, int i, int j)
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
                if (!flag)
                    IncorrectValue();
            }
        }

        public static void RandNum(out int number, char simbol, int i, int j)
        {
            if (simbol == c_cN || simbol == c_cM)
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

        public static void IncorrectValue()
        {
            Console.WriteLine(c_sIncorrectValue);
        }

        public static void Output(int[] array)
        {
            Kernel.CheckArray(Kernel.array1D);
            for (int i = 0, n = array.Length; i < n; ++i)
                Console.Write(c_sElem, array[i]);
            Console.WriteLine("\n");
        }

        public static void Output(int[,] array)
        {
            Kernel.CheckArray(Kernel.array2D);
            int n = array.GetUpperBound(0) + 1;
            int k = array.Length / n;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < k; ++j)
                    Console.Write(c_sElem, array[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Output(int[][] array)
        {
            Kernel.CheckArray(Kernel.arrayRagged);
            for (int i = 0, n = array.Length; i < n; ++i)
            {
                for (int j = 0, k = array[i].Length; j < k; ++j)
                    Console.Write(c_sElem, array[i][j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Output1()
        {
            Output(Kernel.array1D);
        }

        public static void Output2()
        {
            Output(Kernel.array2D);
        }

        public static void Output3()
        {
            Output(Kernel.arrayRagged);
        }

        public static void Formation1()
        {
            Kernel.Formation1D(GetMode());
            Output1();
        }

        public static void Formation2()
        {
            Kernel.Formation2D(GetMode());
            Output2();
        }

        public static void Formation3()
        {
            Kernel.FormationRagged(GetMode());
            Output3();
        }

        public static void Operation1()
        {
            Kernel.Addition(GetMode);
            Output1();
        }

        public static void Operation2()
        {
            Kernel.DeleteEven();
            Output2();
        }

        public static void Operation3()
        {
            Kernel.AdditionLine(GetMode);
            Output3();
        }

        private static Task GetTask()
        {
            bool flag = true;
            while (flag)
            {
                Console.Write(c_sGetTask);
                switch (Console.ReadLine())
                {
                    case "1":
                        return Output1;
                    case "2":
                        return Formation1;
                    case "3":
                        return Operation1;
                    case "4":
                        return Output2;
                    case "5":
                        return Formation2;
                    case "6":
                        return Operation2;
                    case "7":
                        return Output3;
                    case "8":
                        return Formation3;
                    case "9":
                        return Operation3;
                    case "0":
                        flag = false;
                        break;
                    default:
                        continue;
                }
            }
            throw new NullFunctionException();
        }
    }
}
