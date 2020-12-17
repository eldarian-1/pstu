using System.Collections.Generic;

namespace Dialog
{
    public static class ExtensionList
    {
        public static IList<T> Add<T>(this IList<T> list, params T[] arr)
        {
            foreach (T item in arr)
                list.Add(item);
            return list;
        }
    }
}
