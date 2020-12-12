using System;
using System.Collections.Generic;

namespace Collection.BiTree
{
    public class BiTree<T>
        where T : IComparable
    {
        protected Node<T> Root { get; set; }

        public void Add(T item)
        {
            Node<T> node = new Node<T> { Data = item };
            if (Root == null)
                Root = node;
            else
                Root.Add(node);
        }

        private void ListAdder(IList<T> list, Node<T> node)
        {
            if(node != null)
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

        public void Clear()
        {
            Root = null;
        }
    }
}
