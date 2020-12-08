using Entity;

namespace Lab13
{
    public delegate void StackHandler(object source, StackHandlerEventArgs args);

    class ObservableStack : Stack<IEngine>
    {
        public event StackHandler CountChanged;
        public event StackHandler ReferenceChanged;

        private void OnCountChanged(object source, StackHandlerEventArgs args)
        {
            if (CountChanged != null)
                CountChanged(source, args);
        }

        private void OnReferenceChanged(object source, StackHandlerEventArgs args)
        {
            if (ReferenceChanged != null)
                ReferenceChanged(source, args);
        }

        public override IEngine this[int index]
        {
            get => base[index];
            set
            {
                base[index] = value;
                OnReferenceChanged(this, null);
            }
        }

        public override void Add()
        {
            base.Add();
            OnCountChanged(this, null);
        }

        public override void Remove()
        {
            base.Remove();
            OnCountChanged(this, null);
        }

        public override void Sort()
        {
            base.Sort();
            OnReferenceChanged(this, null);
        }

        public override void Clear()
        {
            base.Clear();
            OnCountChanged(this, null);
        }
    }
}
