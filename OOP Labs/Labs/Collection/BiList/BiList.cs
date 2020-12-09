using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection.BiList
{
    public class BiList<T> : IList<T>
    {
        internal Node<T> Head { get; private set; }

        internal Node<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly => true;

        private void CheckIndex(int index)
        {
            if (index >= Count || index < 0)
                throw new Exception();
        }

        private void Find(int leftIndex, out Node<T> item)
        {
            CheckIndex(leftIndex);
            int rightIndex = Count - leftIndex;
            if (leftIndex <= rightIndex)
            {
                item = Head;
                for (int i = 0; i < leftIndex; ++i)
                    item = item.Next;
            }
            else
            {
                item = Tail;
                for (int i = 0; i < rightIndex; ++i)
                    item = item.Prev;
            }
        }

        T IList<T>.this[int index]
        {
            get
            {
                Find(index, out Node<T> item);
                return item.Data;
            }
            set
            {
                Find(index, out Node<T> item);
                item.Data = value;
            }
        }

        public BiList() { }

        public T this[int index]
        {
            get
            {
                Find(index, out Node<T> item);
                return item.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T item)
        {
            int index = 0;
            Node<T> temp = Head;
            while (!temp.Equals(item))
            {
                temp = temp.Next;
                ++index;
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            if (index == 0 && Count == 0)
                Add(item);
            else
            {
                if (index > Count || index < 0)
                    throw new Exception();
                Find(index, out Node<T> temp);
                Node<T> newItem = new Node<T>() { Data = item, Next = temp.Next };
                temp.Next = newItem;
                ++Count;
            }
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);
            if (index == 0)
                Head = Head.Next;
            else
            {
                Find(index - 1, out Node<T> temp);
                temp.Next = temp.Next.Next;
            }
            ++Count;
        }

        public void Add(T item)
        {
            Node<T> newItem = new Node<T>() { Data = item };
            if (Head == null)
            {
                Head = newItem;
                Tail = newItem;
            }
            else
            {
                Tail.Next = newItem;
                newItem.Prev = Tail;
                Tail = newItem;
            }
            ++Count;
        }

        public void Clear()
        {
            Head = null;
        }

        public bool Contains(T item)
        {
            bool flag = false;
            foreach (T elem in this)
                if (flag = item.Equals(elem))
                    break;
            return flag;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int i = 0;
            foreach (T item in this)
                array[arrayIndex + i++] = item;
        }

        public bool Remove(T item)
        {
            bool flag = false;
            Node<T> prev = null;
            Node<T> curr = Head;
            while (!flag && curr != null)
            {
                flag = item.Equals(curr);
                if (flag)
                    if (prev == null)
                        Head = curr.Next;
                    else
                        prev.Next = curr.Next;
                else
                    prev = curr;
                curr = curr.Next;
            }
            return flag;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }
    }
}
