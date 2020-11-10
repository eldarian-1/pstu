namespace BooleanCalculator.Expression
{
    class PearsExpression : AbstractExpression
    {
        public PearsExpression() : base() { }
        public PearsExpression(IExpression left, IExpression right) : base(left, right) { }

        public override char SymbolOperation => '↓';

        public override bool Run() => !Left.Run() && !Right.Run();
    }
}
