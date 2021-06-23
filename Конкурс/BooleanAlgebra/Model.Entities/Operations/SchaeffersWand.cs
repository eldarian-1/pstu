namespace Model.Entities.Operations
{
    public class SchaeffersWand : AOperation
    {
        public override char OperationSymbol => '|';

        public override int Priority => 2;

        public override bool Value => !Left.Value || !Right.Value;

        public override AOperation Next => new PiercesArrow();
    }
}
