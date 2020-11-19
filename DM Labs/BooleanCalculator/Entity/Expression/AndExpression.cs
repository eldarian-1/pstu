namespace Entity
{
    class AndExpression : AbstractExpression
    {
        public override char Operator => '&';

        public override int Priority => 7;

        public override bool Value => Left.Value && Right.Value;

        public override AbstractExpression Next => new OrExpression();
    }
}
