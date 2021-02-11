namespace Model.Entities.Operations
{
    public class LogicalOR : AOperation
    {
        public override char OperationSymbol => 'v';

        public override int Priority => 6;

        public override bool Value => Left.Value || Right.Value;

        public override AOperation Next => new Implication();
    }
}
