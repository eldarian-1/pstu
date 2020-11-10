namespace BooleanCalculator.Expression
{
    internal abstract class AbstractExpression : IExpression
    {
        private static int s_Count = 0;

        private IExpression m_Left;
        private IExpression m_Right;

        public AbstractExpression()
        {
            Name = "F" + s_Count++;
        }

        public AbstractExpression(IExpression left, IExpression right) : this()
        {
            Left = left;
            Right = right;
        }

        private void SetShortString()
        {
            if(Left != null && Right != null)
                ShortString = Left.Name + SymbolOperation + Right.Name;
        }

        public IExpression Left
        {
            get => m_Left;
            set
            {
                m_Left = value;
                SetShortString();
            }
        }

        public IExpression Right
        {
            get => m_Right;
            set
            {
                m_Right = value;
                SetShortString();
            }
        }

        public abstract bool Run();

        protected abstract char SymbolOperation { get; }

        public string Name { get; protected set; }

        public string ShortString { get; protected set; }

        public string FullString => ToString();

        public override string ToString()
        {
            return "(" + Left.ToString() + SymbolOperation + Right.ToString() + ")";
        }
    }
}
