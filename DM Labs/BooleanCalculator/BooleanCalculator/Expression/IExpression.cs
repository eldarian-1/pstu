namespace BooleanCalculator
{
    internal interface IExpression
    {
        string Name { get; }
        string ShortString { get; }
        bool Run();
    }
}