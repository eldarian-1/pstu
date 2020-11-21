using System;
using Dialog;

namespace Lab11
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            TaskRunner.Instance.Run(MainMenu.Instance);
            Console.ReadKey();
        }
    }
}
