namespace BooleanCalculator
{
    internal class InversionExpression : SymbolExpression
    {
        public InversionExpression(bool value) : base(value)
            => Name = "-" + Name;

        public override bool Run() => !m_Value;

        public override string ToString() => Name;
    }
}
