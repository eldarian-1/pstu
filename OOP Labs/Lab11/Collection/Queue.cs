using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    public class Queue<T> : ICollection<T>, ICloneable
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

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public Queue()
        {
            Count = 0;
        }

        public T this[int index]
        {
            get
            {
                int i = 0;
                Node temp = First;
                while (i++ < index)
                    temp = temp.Next;
                return temp.Data;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node temp = First;
            while(temp != Last.Next)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public object Clone()
        {
            Queue<T> queue = new Queue<T>();
            foreach (T item in this)
                queue.Add(item);
            return queue;
        }

        public void Add(T item)
        {
            Node temp = new Node { Data = item };
            if (First == null)
            {
                First = temp;
                Last = temp;
            }
            else
            {
                Last.Next = temp;
                temp.Prev = Last;
                Last = temp;
            }
            ++Count;
        }

        public void PopFront()
        {
            if (First != null)
            {
                First = First.Next;
                First.Prev = null;
                --Count;
            }
        }

        public void Clear()
        {
            while (Count != 0)
                PopFront();
        }

        public bool Contains(T item)
        {
            bool flag = false;
            Node temp = First;
            while(!flag && temp != Last.Next)
            {
                flag = temp.Data.Equals(item);
                temp = temp.Next;
            }
            return flag;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int i = 0;
            int n = array.Length - arrayIndex;
            if (n < 0)
                throw new Exception();
            while (i++ < n)
                Add(array[i]);
        }

        public T[] ToArray()
        {
            int i = 0, n = Count;
            T[] array = new T[n];
            foreach (T elem in this)
                array[i++] = elem;
            return array;
        }

        public bool Remove(T item)
        {
            bool flag = false;
            Node temp = First;
            while (!flag && temp != Last.Next)
            {
                flag = temp.Data.Equals(item);
                if (flag)
                    Binding(temp.Prev, temp.Next);
                else
                    temp = temp.Next;
            }
            return flag;
        }

        private void Binding(Node prev, Node next)
        {
            if (prev != null && next != null)
            {
                prev.Next = next;
                next.Prev = prev;
            }
            else if (prev != null && next == null)
            {
                prev.Next = null;
                Last = prev;
            }
            else if (prev == null && next != null)
            {
                next.Prev = null;
                First = next;
            }
            else
            {
                First = null;
                Last = null;
            }
        }
    }
}
