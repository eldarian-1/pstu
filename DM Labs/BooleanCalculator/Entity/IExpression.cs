namespace Entity
{
    public interface IExpression
    {
        string Name { get; }
        string Briefly { get; }
        string Wholly { get; }
        bool Value { get; }
    }
}