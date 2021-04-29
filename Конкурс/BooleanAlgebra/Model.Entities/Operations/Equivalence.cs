namespace Model.Entities.Operations
{
    public class Equivalence : AOperation
    {
        public override char OperationSymbol => '~';

        public override int Priority => 4;

        public override bool Value
        {
            get
            {
                bool a = Left.Value;
                bool b = Right.Value;
                return a && b || !a && !b;
            }
        }

        public override AOperation Next => new LogicalXOR();
    }
}
