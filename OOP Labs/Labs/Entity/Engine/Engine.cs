namespace Entity
{
    internal class Engine : IEngine
    {
        public int Power { get; set; }
        public int Index { get; protected set; }

        public Engine(int i)
            => Index = i;

        public string Name
            => string.Format("{0}-{1}", GetType().Name, Index);

        public virtual string Fuel => "Fuel";

        public virtual IEngine BaseEngine => null;

        public int CompareTo(object obj)
        {
            Engine right = (Engine)obj;
            if (Index > right.Index)
                return 1;
            else if (Index == right.Index)
                return 0;
            return -1;
        }

        public virtual object Clone()
            => new Engine(Index) { Power = Power};

        public override bool Equals(object obj)
        {
            bool flag = obj.GetType() == GetType();
            if (flag)
            {
                Engine engine = obj as Engine;
                flag = engine.Index == Index && engine.Power == Power;
            }
            return flag;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Copy()
            => MemberwiseClone();

        public override string ToString()
        {
            return string.Format("{0}-{1}: {2}HP", GetType().Name, Index, Power);
        }
    }
}
