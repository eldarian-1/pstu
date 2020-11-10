namespace BooleanCalculator.Expression
{
    internal class InversionExpression : IExpression
    {
        public IExpression OriginalExpression { get; }

        public InversionExpression(IExpression expression)
        {
            Name = "¬" + expression.Name;
            OriginalExpression = expression;
        }

        public bool Run() => !OriginalExpression.Run();

        public string Name { get; set; }

        public string ShortString => OriginalExpression.ShortString;

        public string FullString => ToString();

        public override string ToString()
        {
            return "¬" + OriginalExpression.ToString();
        }
    }
}
