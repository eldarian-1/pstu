namespace Entity
{
    class OrExpression : AbstractExpression
    {
        public override char Operator => 'v';

        public override bool Value => Left.Value || Right.Value;

        public override AbstractExpression Next => new ImplicationExpression();
    }
}
