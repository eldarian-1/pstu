using System;
using Dialog;

namespace Lab11
{
    internal static class Program
    {
        private static TaskRunner Runner;

        public static void Main(string[] args)
        {
            Runner = new TaskRunner(MainMenu.Instance);
            Runner.Run();
            Console.ReadKey();
        }
    }
}
