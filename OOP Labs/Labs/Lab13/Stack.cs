namespace Lab13
{
    class Stack<T> : Collection.Stack.Stack<T>
    {
        public void Fill()
        {

        }

        public virtual void Add(T item)
        {

        }

        public virtual void Insert(int index, T item)
        {

        }

        public virtual void Remove()
        {
            Pop();
        }

        public virtual void Erase(int index)
        {
            Pop();
        }

        public virtual void Sort()
        {

        }

        public virtual new void Clear()
        {
            base.Clear();
        }

    }
}
