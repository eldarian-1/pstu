using System;

namespace Entity
{
    internal class Query2 : IQuery
    {
        public void Run(IEngine[] arr)
        {
            Start<InternalCombustionEngine>(arr);
            Start<DieselEngine>(arr);
            Start<TurboReactiveEngine>(arr);
        }

        private void Start<T>(IEngine[] arr)
        {
            Query<T>(arr, out int power);
            Console.WriteLine("Power {0}: {1}", typeof(T).Name, power);
        }

        private void Query<T>(IEngine[] arr, out int power)
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
