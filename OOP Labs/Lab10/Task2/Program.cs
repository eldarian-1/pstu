﻿using System;
using Task1;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Generate.Run(out IExecutable[] arr);
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
