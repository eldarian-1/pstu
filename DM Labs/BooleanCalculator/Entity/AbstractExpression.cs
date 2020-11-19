namespace Entity
{
    public abstract class AbstractExpression : ISymbol
    {
        public ISymbol Left { get; set; }

        public ISymbol Right { get; set; }

        public abstract char Operator { get; }

        public abstract int Priority { get; }

        public string Name { get; set; }

        public string Briefly
            => Left.Name + " " + Operator + " " + Right.Name;

        public string Wholly
            => Left.Wholly + " " + Operator + " " + Right.Wholly;

        public override string ToString() => Wholly;

        public abstract AbstractExpression Next { get; }

        public abstract bool Value { get; }
    }
}
