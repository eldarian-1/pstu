using System;
using Entity;

namespace Task2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Generate.Run(out IExecutable[] arr, true);
            Console.WriteLine("Query1 - Количество двигателей заданного типа");
            Query1.Run(arr);
            Console.WriteLine("\nQuery2 - Средняя мощность двигателей заданного типа");
            Query2.Run(arr);
            Console.WriteLine("\nQuery3 - Поиск двигателей эквивалентных по типу и мощности\n");
            Query3.Run(arr);
            Console.ReadKey();
        }
    }
}
