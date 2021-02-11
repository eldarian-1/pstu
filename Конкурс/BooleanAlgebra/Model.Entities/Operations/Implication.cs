namespace Model.Entities.Operations
{
    public class Implication : AOperation
    {
        public override char OperationSymbol => '→';

        public override int Priority => 5;

        public override bool Value => !Left.Value || Right.Value;

        public override AOperation Next => new Equivalence();
    }
}
