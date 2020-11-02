namespace Entity
{
    public abstract class Engine : IExecutable
    {
        public int Power { get; set; }
        public int Index { get; protected set; }

        public Engine(int i)
            => Index = i;

        public string Name
            => string.Format("{0}-{1}", GetType().Name, Index);

        public virtual string Fuel => "Fuel";

        public int CompareTo(object obj)
        {
            Engine right = (Engine)obj;
            if (Index > right.Index)
                return 1;
            else if (Index == right.Index)
                return 0;
            return -1;
        }

        public abstract object Clone();

        public object Copy()
            => MemberwiseClone();
    }
}
