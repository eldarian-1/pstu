using System;
using System.Collections.Generic;

namespace Entity
{
    internal class Query3 : IQuery
    {
        public void Run(IEngine[] arr)
        {
            Start<InternalCombustionEngine>(arr);
            Console.WriteLine();
            Start<DieselEngine>(arr);
            Console.WriteLine();
            Start<TurboReactiveEngine>(arr);
        }

        private void Start<T>(IEngine[] arr)
        {
            List<List<IEngine>> lists = new List<List<IEngine>>();
            Query<T>(arr, ref lists);
            Console.WriteLine("Lists {0}:", typeof(T).Name);
            int n = lists.Count;
            if(n == 0)
            {
                Console.WriteLine("Empty list");
                return;
            }
            for (int i = 0; i < n; ++i)
            {
                Console.Write("Power {0}: ", lists[i][0].Power);
                for (int j = 0, m = lists[i].Count; j < m; ++j)
                    Console.Write("{0} ", lists[i][j].Index);
                Console.WriteLine();
            }
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
