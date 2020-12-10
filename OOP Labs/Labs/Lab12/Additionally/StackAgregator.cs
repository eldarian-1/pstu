using Collection.Stack;
using System;

namespace Lab12.Additionally
{
    public class StackAgregator<T>
    {
        private Stack<T> m_Stack;

        public bool Empty => m_Stack == null;

        public void EmptyConstruct()
        {
            m_Stack = new Stack<T>();
        }

        public void ConstructByCount(int count)
        {
            m_Stack = new Stack<T>(count);
        }

        public void CopyConstruct(StackAgregator<T> agregator)
        {
            m_Stack = new Stack<T>(agregator.m_Stack);
        }

        public int Count => m_Stack.Count;

        public void AddItem(T item)
        {
            m_Stack.Push(item);
        }

        public void AddMultipleItems(T[] items)
        {
            foreach (T item in items)
                AddItem(item);
        }

        public void RemoveItem(int index)
        {
            m_Stack.Remove(m_Stack[index]);
        }

        public void RemoveMultipleItems(int[] indexes)
        {
            Array.Sort(indexes);
            int i = 0;
            foreach (int index in indexes)
            {
                RemoveItem(index - i++);
            }
        }

        public void Clear()
        {
            m_Stack.Clear();
        }

        public override string ToString()
            => m_Stack.ToString();
    }
}
