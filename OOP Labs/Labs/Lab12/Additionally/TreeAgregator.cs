using System;
using System.Collections.Generic;

namespace Lab12.Additionally
{
    internal class TreeAgregator
    {
        private BiTree m_Tree;

        public bool Empty => m_Tree == null;

        public void Formation(string[] nodes)
        {
            m_Tree = new BiTree();
            foreach (string item in nodes)
                m_Tree.Add(item);
        }

        private void SetItem(string[] arr, IList<string> list, int low, int high)
        {
            int mid = (low + high) / 2;
            list.Add(arr[mid]);
            if (low < mid)
                SetItem(arr, list, low, mid);
            if (mid + 1 < high)
                SetItem(arr, list, mid + 1, high);
        }

        public void ToBalance()
        {
            string[] arr = (m_Tree.ToList() as List<string>).ToArray();
            Array.Sort(arr);
            IList<string> list = new List<string>();
            int low = 0, high = arr.Length;
            SetItem(arr, list, low, high);
            m_Tree.Clear();
            foreach (string item in list)
                m_Tree.Add(item);
        }

        public void ToSearch()
        {

        }

        public int CountOnChar(char symbol)
            => m_Tree.CountOnChar(symbol);

        public void Remove()
            => m_Tree = null;

        public override string ToString()
            => m_Tree.ToString();
    }
}
