using Collection.UniList;
using System.Collections;
using System.Collections.Generic;

namespace Collection.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const string c_EmptyStack = "Стек пуст.";
        
        private IList<T> m_List;

        public Stack()
        {
            m_List = new UniList<T>();
        }

        public Stack(int count) : this()
        {
            for (int i = 0; i < count; ++i)
                m_List.Add(default(T));
        }

        public Stack(Stack<T> stack) : this()
        {
            foreach (T item in stack.m_List)
                Push(item);
        }

        public int Count => m_List.Count;

        public virtual T this[int index]
        {
            get => m_List[index];
            set => m_List[index] = value;
        }

        public virtual void Push(T item)
        {
            m_List.Add(item);
        }

        public virtual T Peek()
        {
            return m_List[m_List.Count - 1];
        }

        public virtual void Pop()
        {
            m_List.Remove(m_List[m_List.Count - 1]);
        }

        public virtual void Remove(T item)
        {
            m_List.Remove(item);
        }

        public virtual void Clear()
        {
            m_List.Clear();
        }

        public override string ToString()
        {
            string result = "";
            if (m_List.Count != 0)
                foreach (T item in m_List)
                    result += item + " ";
            else
                result = c_EmptyStack;
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return m_List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_List.GetEnumerator();
        }
    }
}
