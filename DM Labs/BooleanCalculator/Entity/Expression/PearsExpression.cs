namespace Entity
{
    class PearsExpression : AbstractExpression
    {
        public override char Operator => '↓';

        public override bool Value => !Left.Value && !Right.Value;

        public override AbstractExpression Next => new AndExpression();
    }
}
