using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection.BiTree
{
    public class BiTree<T> : IEnumerable<T>
        where T : IComparable
    {
        public Node<T> Root { get; set; }

        public void Add(T item)
        {
            Node<T> node = new Node<T> { Data = item };
            if (Root == null)
                Root = node;
            else
                Root.Add(node);
        }

        public void Clear()
        {
            Root = null;
        }

        private void ListAdder(IList<T> list, Node<T> node)
        {
            if (node != null)
            {
                list.Add(node.Data);
                ListAdder(list, node.Left);
                ListAdder(list, node.Right);
            }
        }

        public IList<T> ToList()
        {
            IList<T> list = new List<T>();
            ListAdder(list, Root);
            return list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
