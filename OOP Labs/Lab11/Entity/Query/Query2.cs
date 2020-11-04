namespace Entity
{
    internal class Query2 : IQuery
    {
        public string Run(IEngine[] arr)
        {
            return
                Start<InternalCombustionEngine>(arr) + "\n" +
                Start<DieselEngine>(arr) + "\n" +
                Start<TurboReactiveEngine>(arr);
        }

        private string Start<T>(IEngine[] arr)
        {
            Query<T>(arr, out int power);
            return string.Format("Power {0}: {1}", typeof(T).Name, power);
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
