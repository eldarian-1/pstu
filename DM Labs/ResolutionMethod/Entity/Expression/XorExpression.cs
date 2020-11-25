﻿namespace Entity
{
    class XorExpression : AbstractExpression
    {
        public override char Operator => '+';

        public override int Priority => 3;

        public override bool Value
        {
            get
            {
                bool a = Left.Value;
                bool b = Right.Value;
                return a && !b || !a && b;
            }
        }

        public override AbstractExpression Next => new SchaefferExpression();
    }
}
