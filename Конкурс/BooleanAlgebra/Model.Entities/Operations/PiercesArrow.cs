namespace Model.Entities.Operations
{
    public class PiercesArrow : AOperation
    {
        public override char OperationSymbol => '↓';

        public override int Priority => 1;

        public override bool Value => !Left.Value && !Right.Value;

        public override AOperation Next => new LogicalAND();
    }
}
