using Entity;

namespace Lab13
{
    internal delegate void StackHandler(object source, StackHandlerEventArgs args);

    internal class ObservableStack : StackAgregator<IEngine>
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

        public override void Add(IEngine engine)
        {
            base.Add(engine);
            OnCountChanged(this, null);
        }

        public override void Insert(int index, IEngine engine)
        {
            base.Insert(index, engine);
            OnCountChanged(this, null);
        }

        public override void Remove()
        {
            base.Remove();
            OnCountChanged(this, null);
        }

        public override void Erase(int index)
        {
            base.Erase(index);
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
