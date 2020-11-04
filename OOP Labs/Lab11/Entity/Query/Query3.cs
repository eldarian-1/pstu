using System.Collections.Generic;

namespace Entity
{
    internal class Query3 : IQuery
    {
        public string Run(IEngine[] arr)
        {
            return
                Start<InternalCombustionEngine>(arr) + "\n\n" +
                Start<DieselEngine>(arr) + "\n\n" +
                Start<TurboReactiveEngine>(arr);
        }

        private string Start<T>(IEngine[] arr)
        {
            string result = "";
            List<List<IEngine>> lists = new List<List<IEngine>>();
            Query<T>(arr, ref lists);
            result += string.Format("Lists {0}:\n", typeof(T).Name);
            int n = lists.Count;
            if(n == 0)
            {
                result += string.Format("Empty list");
                return result;
            }
            for (int i = 0; i < n; ++i)
            {
                result += string.Format("Power {0}: \n", lists[i][0].Power);
                for (int j = 0, m = lists[i].Count; j < m; ++j)
                    result += string.Format("{0} ", lists[i][j].Index);
            }
            return result;
        }

        private void Query<T>(IEngine[] arr, ref List<List<IEngine>> lists)
        {
            for(int i = 0, n = arr.Length, k = 0; i < n; ++i)
            {
                if (arr[i] is T)
                {
                    bool flag = false;
                    for (int j = i - 1; j >= 0 && !flag; --j)
                        flag = arr[i].Power == arr[j].Power;
                    if (!flag)
                    {
                        lists.Add(new List<IEngine>());
                        lists[k].Add(arr[i]);
                        for (int j = i + 1; j < n; ++j)
                            if (arr[i].Power == arr[j].Power)
                                lists[k].Add(arr[j]);
                        ++k;
                    }
                }
            }
            for(int i = 0; i < lists.Count; ++i)
                if(lists[i].Count == 1)
                    lists.RemoveAt(i--);
        }
    }
}
