using System;

namespace Entity
{
    internal class Query1 : IQuery
    {
        public void Run(IEngine[] arr)
        {
            Start<InternalCombustionEngine>(arr);
            Start<DieselEngine>(arr);
            Start<TurboReactiveEngine>(arr);
        }

        private void Start<T>(IEngine[] arr)
        {
            Query<T>(arr, out int count);
            Console.WriteLine("Count {0}: {1}", typeof(T).Name, count);
        }

        private void Query<T>(IEngine[] arr, out int count)
        {
            count = 0;
            for (int i = 0, n = arr.Length; i < n; ++i)
                if (arr[i] is T)
                    ++count;
        }
    }
}
