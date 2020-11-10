namespace BooleanCalculator
{
    internal class SymbolExpression : IExpression
    {
        public static int Count { get; protected set; } = 0;

        protected bool m_Value;

        public SymbolExpression(bool value)
        {
            Name = ((char)('A' + Count++)).ToString();
            m_Value = value;
        }

        public SymbolExpression(SymbolExpression expression) : this(expression.m_Value) {}

        public virtual bool Run() => m_Value;

        public string Value
        {
            get
            {
                if (m_Value)
                    return "1";
                else
                    return "0";
            }
        }

        public void Set(int num)
        {
            if (num == 0)
                m_Value = false;
            else
                m_Value = true;
        }

        public void InvertValue()
        {
            m_Value = !m_Value;
        }

        public string Name { get; protected set; }

        public string ShortString { get => Name; }

        public override string ToString() => Name;
    }
}
