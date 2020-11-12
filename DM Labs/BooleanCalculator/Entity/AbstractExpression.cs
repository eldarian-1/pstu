namespace Entity
{
    public abstract class AbstractExpression : IExpression
    {
        public IExpression Left { get; set; }

        public IExpression Right { get; set; }

        public abstract char Symbol { get; }

        public string Name { get; set; }

        public string Briefly
            => Left.Name + " " + Symbol + " " + Right.Name;

        public string Wholly
            => "(" + Left.Wholly + " " + Symbol + " " + Right.Wholly + ")";

        public override string ToString() => Wholly;

        public abstract AbstractExpression Next { get; }

        public abstract bool Value { get; }
    }
}
