namespace Entity
{
    public class Inversion : ISymbol
    {
        public ISymbol Original { get; }

        public Inversion(ISymbol expression)
            => Original = expression;

        public const char Operator = '¬';

        public string Name => Operator + Original.Name;

        public string Briefly => Operator +
            (Original is Variable
            ? Original.Name
            : "(" + Original.Briefly + ")");

        public string Wholly => Operator + Original.Wholly;

        public override string ToString() => Wholly;

        public bool Value => !Original.Value;
    }
}
