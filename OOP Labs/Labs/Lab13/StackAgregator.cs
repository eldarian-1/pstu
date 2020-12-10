﻿using Collection.Stack;

namespace Lab13
{
    internal class StackAgregator<T>
    {
        protected Stack<T> m_Stack;

        public StackAgregator()
        {
            m_Stack = new Stack<T>();
        }

        public virtual T this[int index]
        {
            get => m_Stack[index];
            set => m_Stack[index] = value;
        }

        public virtual void Add(T item)
        {

        }

        public virtual void Add(T[] items)
        {
            foreach (T item in items)
                Add(item);
        }

        public virtual void Insert(int index, T item)
        {

        }

        public virtual void Remove()
        {
            m_Stack.Pop();
        }

        public virtual void Erase(int index)
        {
            m_Stack.Pop();
        }

        public virtual void Sort()
        {

        }

        public virtual void Clear()
        {
            m_Stack.Clear();
        }

    }
}
