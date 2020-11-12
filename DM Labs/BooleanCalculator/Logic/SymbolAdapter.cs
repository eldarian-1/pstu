using Entity;

namespace Logic
{
    public class SymbolAdapter : SymbolExpression
    {
        public SymbolAdapter() : base() { }

        public string Data => Value ? "1" : "0";
    }
}
