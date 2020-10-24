using System;
using Task1;

namespace Task2
{
    class Query1
    {
        public static void Run(IExecutable[] arr)
        {
            Start<InternalCombustionEngine>(arr);
            Start<DieselEngine>(arr);
            Start<TurboReactiveEngine>(arr);
        }

        private static void Start<T>(IExecutable[] arr)
        {
            Query<T>(arr, out int count);
            Console.WriteLine("Count {0}: {1}", typeof(T).Name, count);
        }

        private static void Query<T>(IExecutable[] arr, out int count)
        {
            count = 0;
            for (int i = 0, n = arr.Length; i < n; ++i)
                if (arr[i] is T)
                    ++count;
        }
    }
}
