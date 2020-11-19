namespace Entity
{
    class ShefferExpression : AbstractExpression
    {
        public override char Operator => '|';

        public override int Priority => 2;

        public override bool Value => !Left.Value || !Right.Value;

        public override AbstractExpression Next => new PearsExpression();
    }
}
