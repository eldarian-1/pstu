namespace Entity
{
    class AndExpression : AbstractExpression
    {
        public override char Symbol => '&';

        public override bool Value => Left.Value && Right.Value;

        public override AbstractExpression Next => new OrExpression();
    }
}
