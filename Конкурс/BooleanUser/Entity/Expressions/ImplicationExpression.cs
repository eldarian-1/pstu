namespace Entity
{
    class ImplicationExpression : AbstractExpression
    {
        public override char Operator => '→';

        public override int Priority => 5;

        public override bool Value => !Left.Value || Right.Value;

        public override AbstractExpression Next => new EquivalenceExpression();
    }
}
