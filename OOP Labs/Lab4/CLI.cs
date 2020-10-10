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
        private const string c_sIncorrectValue = "Некорректное значение!";
        private const string c_sNullArray = "Ошибка! Массив не создан.\n";
        private const string c_sCleanArray = "Массив пуст, поэтому удален.\n";
        private const string c_sNullFunction = "Спасибо за работу!";
        private const string c_sNotFound = "Элемент не найден\n";
        private const string c_sNotSorted = "Массив не отсортирован\n";
        private const string c_sFoundElem =
            "Порядковый номер искомого элемента: {0}\n";
        private const string c_sGetMode =
            "Введите способ получения чисел (1 - ввод, - 2 случайное): ";
        private const string c_sGetTask =
            "МЕНЮ\n" +
            "1. Вывести массив\n" +
            "2. Создать массив\n" +
            "3. Удалить четные элементы в массиве\n" +
            "4. Добавить n элементов с k элемента\n" +
            "5. Перевернуть массив\n" +
            "6. Поиск элемента\n" +
            "7. Сортировка массива\n" +
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
                catch(NullArrayException)
                {
                    Console.WriteLine(c_sNullArray);
                }
                catch (FoundElemException e)
                {
                    Console.WriteLine(CLI.c_sFoundElem, e.N);
                }
                catch (NotFoundException)
                {
                    Console.WriteLine(CLI.c_sNotFound);
                }
                catch (CleanArrayException)
                {
                    Console.WriteLine(CLI.c_sCleanArray);
                }
                catch (NotSortedException)
                {
                    Console.WriteLine(CLI.c_sNotSorted);
                }
                catch (NullFunctionException)
                {
                    Console.Write(c_sNullFunction);
                    break;
                }
            }
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
                if (!flag)
                    IncorrectValue();
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

        public static void IncorrectValue()
        {
            Console.WriteLine(c_sIncorrectValue);
        }

        // Вывод массива
        private static void Output(int[] array)
        {
            Kernel.CheckArray();
            for (int i = 0, k = array.Length; i < k; ++i)
                Console.Write(c_sElem, array[i]);
            Console.WriteLine("\n");
        }
        private static void Output()
        {
            Output(Kernel.array);
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
            Kernel.BinarySearch(GetMode);
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
                        return Output;
                    case "2":
                        return Formation;
                    case "3":
                        return DeleteElems;
                    case "4":
                        return Addition;
                    case "5":
                        return Reverse;
                    case "6":
                        return FindElem;
                    case "7":
                        return InsertSort;
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
