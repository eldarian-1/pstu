using System;

namespace Task1
{
    class Program
    {
        private static IExecutable[] engines = {
            new TurboReactiveEngine(9),
            new DieselEngine(14),
            new InternalCombustionEngine(19),
            new TurboReactiveEngine(16),
            new DieselEngine(15),
            new InternalCombustionEngine(2),
            new TurboReactiveEngine(13),
            new DieselEngine(22),
            new InternalCombustionEngine(10),
            new TurboReactiveEngine(4),
            new DieselEngine(11),
            new InternalCombustionEngine(25)
        };

        static void Main(string[] args)
        {
            Part1();
            Part2();
            Part3();
            Console.ReadKey();
        }

        private static void Part1()
        {
            Console.WriteLine("Вывод результатов методов Name() и Fuel() для каждого элемента");
            for (int i = 0, n = engines.Length; i < n; ++i)
            {
                engines[i].Name();
                engines[i].Fuel();
            }
            Console.WriteLine();
        }

        private static void Part2()
        {
            Console.WriteLine("Сортировка массива и выполнение метода Name() для каждого элемента");
            Array.Sort(engines);
            for (int i = 0, n = engines.Length; i < n; ++i)
                engines[i].Name();
            Console.WriteLine();
        }

        private static void Part3()
        {
            Console.WriteLine("Поиск элемента массива по индексу двигателя");
            ReadNum(out int key);
            Console.WriteLine("Индекс искомого элемента: {0}", BinarySearch(engines, key));
        }

        private static void ReadNum(out int number)
        {
            while (true)
            {
                Console.Write("Введите искомое значение: ");
                string sNum = Console.ReadLine();
                if (int.TryParse(sNum, out number))
                    break;
            }
        }

        private static int BinarySearch(IExecutable[] array, int key)
        {
            int mid, left = 0, right = array.Length - 1;
            while (true)
            {
                if (left > right)
                    return -1;
                mid = left + (right - left) / 2;
                if (key > array[mid].Index())
                    left = mid + 1;
                else if (key < array[mid].Index())
                    right = mid - 1;
                else
                    return mid;
            }
        }
    }
}
