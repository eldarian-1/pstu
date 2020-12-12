using Collection.Stack;

namespace Lab13
{
    internal class StackAgregator<T>
    {
        protected Stack<T> m_Stack;

        protected string Name { get; }

        public bool IsNull => m_Stack == null;

        public int Count => m_Stack.Count;

        public StackAgregator(string name)
        {
            Name = name;
            m_Stack = new Stack<T>();
        }

        public virtual T this[int index]
        {
            get => m_Stack[index];
            set => m_Stack[index] = value;
        }

        public virtual void Push(T item)
        {
            m_Stack.Push(item);
        }

        public virtual void Pop()
        {
            m_Stack.Pop();
        }

        public virtual bool Remove(int index)
        {
            bool result = index >= 0 && index < Count;
            if(result)
                m_Stack.Remove(m_Stack[index]);
            return result;
        }

        public virtual void Clear()
        {
            m_Stack.Clear();
        }

        public override string ToString()
        {
            string result = "";
            foreach (T item in m_Stack)
                result += item + "\n";
            return result;
        }
    }
}
