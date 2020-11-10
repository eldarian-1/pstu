namespace BooleanCalculator.Expression
{
    class ShefferExpression : AbstractExpression
    {
        public ShefferExpression() : base() { }
        public ShefferExpression(IExpression left, IExpression right) : base(left, right) { }

        public override char SymbolOperation => '|';

        public override bool Run() => !Left.Run() || !Right.Run();
    }
}
