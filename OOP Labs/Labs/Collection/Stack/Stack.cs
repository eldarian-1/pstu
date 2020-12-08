using Collection.UniList;

namespace Collection.Stack
{
    public class Stack<T>
    {
        private UniList<T> m_List;

        public Stack() { }

        public Stack(int count) { }

        public Stack(Stack<T> stack) { }

        public virtual T this[int index]
        {
            get
            {
                return default(T);
            }
            set
            {

            }
        }

        public virtual void Push(T item)
        {

        }

        public T Peek()
        {
            return default(T);
        }

        public void Pop()
        {

        }

        public void Clear()
        {

        }
    }
}
