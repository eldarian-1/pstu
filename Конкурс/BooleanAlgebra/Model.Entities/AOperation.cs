namespace Model.Entities
{
    public abstract class AOperation : ISymbol
    {
        public ISymbol Left { get; set; }

        public ISymbol Right { get; set; }

        public abstract char OperationSymbol { get; }

        public abstract int Priority { get; }

        public string Name { get; set; }

        public string Briefly
            => Left.Name + " " + OperationSymbol + " " + Right.Name;

        public string Wholly
            => Left.Wholly + " " + OperationSymbol + " " + Right.Wholly;

        public override string ToString() => Wholly;

        public abstract AOperation Next { get; }

        public abstract bool Value { get; }
    }
}
