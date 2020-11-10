namespace BooleanCalculator.Expression
{
    class ImplicationExpression : AbstractExpression
    {
        public ImplicationExpression() : base() { }
        public ImplicationExpression(IExpression left, IExpression right) : base(left, right) { }

        public override char SymbolOperation => '→';

        public override bool Run() => !Left.Run() || Right.Run();
    }
}
