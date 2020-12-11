﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection.UniList
{
    public class UniList<T> : IList<T>
    {
        internal Node<T> Head { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly => true;

        T IList<T>.this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                    throw new Exception();
                Node<T> temp = Head;
                for (int i = 0; i < index; ++i)
                    temp = temp.Next;
                return temp.Data;
            }
            set
            {
                if (index >= Count || index < 0)
                    throw new Exception();
                Node<T> temp = Head;
                for (int i = 0; i < index; ++i)
                    temp = temp.Next;
                temp.Data = value;
            }
        }

        public UniList() {}

        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                    throw new Exception();
                Node<T> temp = Head;
                for (int i = 0; i < index; ++i)
                    temp = temp.Next;
                return temp.Data;
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
                if (index == 0)
                {
                    Node<T> newItem = new Node<T>() { Data = item, Next = Head };
                    Head = newItem;
                }
                else
                {
                    Node<T> temp = Head;
                    for (int i = 0; i < index - 1; ++i)
                        temp = temp.Next;
                    Node<T> newItem = new Node<T>() { Data = item, Next = temp.Next };
                    temp.Next = newItem;
                }
                ++Count;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
                throw new Exception();
            if(index == 0)
                Head = Head.Next;
            else
            {
                Node<T> temp = Head;
                for (int i = 0; i < index - 1; ++i)
                    temp = temp.Next;
                temp.Next = temp.Next.Next;
            }
            --Count;
        }

        public void Add(T item)
        {
            Node<T> newItem = new Node<T>() { Data = item };
            if (Head == null)
                Head = newItem;
            else
            {
                Node<T> temp = Head;
                for (int i = 0; i < Count - 1; ++i)
                    temp = temp.Next;
                temp.Next = newItem;
            }
            ++Count;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
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
            while(!flag && curr != null)
            {
                flag = item.Equals(curr.Data);
                if (flag)
                    if (prev == null)
                        Head = curr.Next;
                    else
                        prev.Next = curr.Next;
                else
                    prev = curr;
                curr = curr.Next;
            }
            if (flag)
                --Count;
            return flag;   
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        public override string ToString()
        {
            string result = "";
            foreach (T item in this)
                result += item + " ";
            return result;
        }
    }
}
