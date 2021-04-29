namespace Model.Entities
{
    public interface ISymbol
    {
        string Name { get; }

        string Briefly { get; }

        string Wholly { get; }

        bool Value { get; }
    }
}