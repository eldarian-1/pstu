using System.Collections.Generic;

namespace Dialog
{
    public class MyList<T> : List<T>
    {
        public MyList(params T[] arr) : base()
        {
            for (int i = 0, n = arr.Length; i < n; i++)
                Add(arr[i]);
        }
    }
}
