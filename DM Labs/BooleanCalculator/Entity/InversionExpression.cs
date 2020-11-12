namespace Entity
{
    public class InversionExpression : IExpression
    {
        public IExpression Original { get; }

        public InversionExpression(IExpression expression)
            => Original = expression;

        public const char Symbol = '¬';

        public string Name => Symbol + Original.Name;

        public string Briefly => Symbol +
            (Original is SymbolExpression
            ? Original.Name
            : "(" + Original.Briefly + ")");

        public string Wholly => Symbol + Original.Wholly;

        public override string ToString() => Wholly;

        public bool Value => !Original.Value;
    }
}
