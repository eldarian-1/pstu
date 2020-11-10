﻿namespace BooleanCalculator.Expression
{
    class OrExpression : AbstractExpression
    {
        public OrExpression() : base() { }
        public OrExpression(IExpression left, IExpression right) : base(left, right) { }

        public override char SymbolOperation => 'v';

        public override bool Run() => Left.Run() || Right.Run();
    }
}
