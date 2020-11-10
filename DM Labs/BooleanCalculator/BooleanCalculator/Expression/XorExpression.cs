namespace BooleanCalculator.Expression
{
    class XorExpression : AbstractExpression
    {
        public XorExpression() : base() { }
        public XorExpression(IExpression left, IExpression right) : base(left, right) { }

        public override char SymbolOperation => '+';

        public override bool Run()
        {
            bool a = Left.Run();
            bool b = Right.Run();
            return a && !b || !a && b;
        }
    }
}
