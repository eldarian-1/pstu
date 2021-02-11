namespace Model.Entities.Operations
{
    public class LogicalAND : AOperation
    {
        public override char OperationSymbol => '&';

        public override int Priority => 7;

        public override bool Value => Left.Value && Right.Value;

        public override AOperation Next => new LogicalOR();
    }
}
