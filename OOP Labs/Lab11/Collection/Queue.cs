using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public class Queue<T> : IEnumerable<T>, ICloneable
    {
        private class Enumerator : IEnumerator
        {
            private Queue<T> m_Queue;
            private Node m_Current;

            object IEnumerator.Current => m_Current.Data;

            public Enumerator(Queue<T> queue)
            {
                m_Queue = queue;
                m_Current = queue.First;
            }

            public bool MoveNext()
            {
                bool flag = m_Current != null;
                if (flag)
                    m_Current = m_Current.Next;
                return flag;
            }

            public void Reset()
            {
                m_Current = m_Queue.First;
            }
        }

        private class Node
        {
            public Node Prev { get; set; }
            public Node Next { get; set; }
            public T Data { get; set; }
        }

        private Node First { get; set; }
        private Node Last { get; set; }

        public void Push(T obj)
        {
            Node temp = new Node { Data = obj };
            if (First == null)
            {
                First = temp;
                Last = temp;
            }
            else
            {
                Last.Next = temp;
                temp.Prev = Last;
                Last = temp.Prev;
            }
        }

        public void Pop()
        {
            if(Last != null)
            {
                Last = Last.Prev;
                Last.Next = null;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => new Enumerator(this);

        public IEnumerator<T> GetEnumerator()
            => GetEnumerator();

        public object Clone()
        {
            Queue<T> queue = new Queue<T>();
            foreach (T obj in this)
                queue.Push(obj);
            return queue;
        }
    }
}
