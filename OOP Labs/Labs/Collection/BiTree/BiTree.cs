using System;

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
    }
}
