namespace Entity
{
    internal class Query1 : IQuery
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
            Query<T>(arr, out int count);
            return string.Format("Count {0}: {1}", typeof(T).Name, count);
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
