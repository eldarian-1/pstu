using Entity;

namespace Lab13
{
    internal delegate void StackHandler(object source, StackHandlerEventArgs args);

    internal class ObservableAgregator : StackAgregator<IEngine>
    {
        private const string c_EditByIndex = "Edit by index";
        private const string c_AddItem = "Add item";
        private const string c_InsertItem = "Insert item";
        private const string c_RemoveItem = "Remove item";
        private const string c_EraseItem = "Erase item";
        private const string c_Sorting = "Sorting collection";
        private const string c_Clear = "Clear collection";

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

        public override void Add(IEngine engine)
        {
            base.Add(engine);
            OnCountChanged(this, CreateEvent(c_AddItem));
        }

        public override void Insert(int index, IEngine engine)
        {
            base.Insert(index, engine);
            OnCountChanged(this, CreateEvent(c_InsertItem));
        }

        public override void Remove()
        {
            base.Remove();
            OnCountChanged(this, CreateEvent(c_RemoveItem));
        }

        public override void Erase(int index)
        {
            base.Erase(index);
            OnCountChanged(this, CreateEvent(c_EraseItem));
        }

        public override void Sort()
        {
            base.Sort();
            OnReferenceChanged(this, CreateEvent(c_Sorting));
        }

        public override void Clear()
        {
            base.Clear();
            OnCountChanged(this, CreateEvent(c_Clear));
        }
    }
}
