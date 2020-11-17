namespace Entity
{
    public class Inversion : IExpression
    {
        public IExpression Original { get; }

        public Inversion(IExpression expression)
            => Original = expression;

        public const char Symbol = '¬';

        public string Name => Symbol + Original.Name;

        public string Briefly => Symbol +
            (Original is Variable
            ? Original.Name
            : "(" + Original.Briefly + ")");

        public string Wholly => Symbol + Original.Wholly;

        public override string ToString() => Wholly;

        public bool Value => !Original.Value;
    }
}
