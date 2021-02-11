namespace Model.Entities
{
    public class Inversion : ISymbol
    {
        public ISymbol Original { get; }

        public Inversion(ISymbol original)
            => Original = original;

        public const char Operator = '¬';

        public string Name => Operator + Original.Name;

        private string Description(string size) => Operator +
            (Original is Variable
            ? Original.Name
            : "(" + size + ")");

        public string Briefly => Description(Original.Briefly);

        public string Wholly => Description(Original.Wholly);

        public override string ToString() => Wholly;

        public bool Value => !Original.Value;

        public override bool Equals(object obj)
        {
            bool result = obj is Inversion;
            if(result)
                result = Original.Equals((obj as Inversion).Original);
            return result;
        }

    }
}
