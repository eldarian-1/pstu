using System;
using Task1;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Generate.Run(out IExecutable[] arr);
            Console.WriteLine("Query1");
            Query1.Run(arr);
            Console.WriteLine("\nQuery2");
            Query2.Run(arr);
            Console.WriteLine("\nQuery3\n");
            Query3.Run(arr);
            Console.ReadKey();
        }
    }
}
