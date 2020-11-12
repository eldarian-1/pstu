namespace Entity
{
    internal class InversionExpression : IExpression
    {
        public IExpression Original { get; }

        public InversionExpression(IExpression expression)
            => Original = expression;

        public string Name => "¬" + Original.Name;

        public string Briefly => "¬" + Original.Briefly;

        public string Wholly => "¬" + Original.Wholly;

        public override string ToString() => Wholly;

        public bool Value => !Original.Value;
    }
}
