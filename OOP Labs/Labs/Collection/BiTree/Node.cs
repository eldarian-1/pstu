using System;

namespace Collection.BiTree
{
    public class Node<T>
        where T : IComparable
    {
        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public T Data { get; set; }

        public void Add(Node<T> node)
        {
            int compareResult = node.Data.CompareTo(Data);
            if (compareResult < 0)
            {
                if (Left == null)
                    Left = node;
                else
                    Left.Add(node);
            }
            else if (compareResult > 0)
            {
                if (Right == null)
                    Right = node;
                else
                    Right.Add(node);
            }
        }
    }
}
