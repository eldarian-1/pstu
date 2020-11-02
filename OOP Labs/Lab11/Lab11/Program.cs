using System;
using Dialog;

namespace Lab11
{
    internal static class Program
    {
        private static TaskRunner Runner;

        public static void Main(string[] args)
        {
            Runner = TaskRunner.Instance;
            Runner.Run(MainMenu.Instance);
            Console.ReadKey();
        }
    }
}
