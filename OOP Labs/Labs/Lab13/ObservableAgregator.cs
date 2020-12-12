using Entity;

namespace Lab13
{
    internal delegate void StackHandler(object source, StackHandlerEventArgs args);

    internal class ObservableAgregator : StackAgregator<IEngine>
    {
        private const string c_PopItem = "Pop item";
        private const string c_PushItem = "Push item";
        private const string c_RemoveItem = "Remove item";
        private const string c_Clear = "Clear collection";
        private const string c_EditByIndex = "Edit by index";

        public event StackHandler CountChanged;
        public event StackHandler ReferenceChanged;

        public ObservableAgregator(string name) : base(name) { }

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

        private StackHandlerEventArgs CreateEvent(string editType)
        {
            return new StackHandlerEventArgs(this, Name, editType);
        }

        public override IEngine this[int index]
        {
            get => base[index];
            set
            {
                base[index] = value;
                OnReferenceChanged(this, CreateEvent(c_EditByIndex));
            }
        }

        public override void Push(IEngine engine)
        {
            base.Push(engine);
            OnCountChanged(this, CreateEvent(c_PushItem));
        }

        public override void Pop()
        {
            base.Pop();
            OnCountChanged(this, CreateEvent(c_PopItem));
        }

        public override void Remove(int index)
        {
            base.Remove(index);
            OnCountChanged(this, CreateEvent(c_RemoveItem));
        }

        public override void Clear()
        {
            base.Clear();
            OnCountChanged(this, CreateEvent(c_Clear));
        }
    }
}
