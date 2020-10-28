using System;

namespace Task1
{
    class Program
    {
        private static IExecutable[] engines;

        static void Main(string[] args)
        {
            Generate.Run(out engines);
            Part1();
            Part2();
            Part4();
            Part3();
            Console.ReadKey();
        }

        private static void Part1()
        {
            Console.WriteLine("Вывод свойств Name и Fuel");
            foreach (IExecutable engine in engines)
                Console.WriteLine("{0}: {1}", engine.Name, engine.Fuel);
            Console.WriteLine();
        }

        private static void Part2()
        {
            Console.WriteLine("Сортировка двигетелей по индексу");
            Array.Sort(engines);
            foreach (IExecutable engine in engines)
                Console.WriteLine("{0}: {1} hp", engine.Name, engine.Power);
            Console.WriteLine();
        }

        private static void Part3()
        {
            Console.WriteLine("Сортировка двигетелей по мощности");
            Array.Sort(engines, new CompareByPower());
            foreach (IExecutable engine in engines)
                Console.WriteLine("{0}: {1} hp", engine.Name, engine.Power);
            Console.WriteLine();
        }

        private static void Part4()
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
                if (key > array[mid].Index)
                    left = mid + 1;
                else if (key < array[mid].Index)
                    right = mid - 1;
                else
                    return mid;
            }
        }
    }
}
