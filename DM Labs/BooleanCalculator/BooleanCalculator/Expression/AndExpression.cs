namespace BooleanCalculator.Expression
{
    class AndExpression : AbstractExpression
    {
        public AndExpression() : base() { }
        public AndExpression(IExpression left, IExpression right) : base(left, right) { }

        public override char SymbolOperation => '&';

        public override bool Run() => Left.Run() && Right.Run();
    }
}
