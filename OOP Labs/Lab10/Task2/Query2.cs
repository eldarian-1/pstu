using System;
using Task1;

namespace Task2
{
    class Query2
    {
        public static void Run(IExecutable[] arr)
        {
            Start<InternalCombustionEngine>(arr);
            Start<DieselEngine>(arr);
            Start<TurboReactiveEngine>(arr);
        }

        private static void Start<T>(IExecutable[] arr)
        {
            Query<T>(arr, out int power);
            Console.WriteLine("Power {0}: {1}", typeof(T).Name, power);
        }

        private static void Query<T>(IExecutable[] arr, out int power)
        {
            power = 0;
            int count = 0;
            for (int i = 0, n = arr.Length; i < n; ++i)
                if (arr[i] is T)
                {
                    power += arr[i].Power;
                    ++count;
                }
            if (count != 0)
                power /= count;
        }
    }
}
