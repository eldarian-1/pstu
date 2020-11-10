namespace BooleanCalculator.Expression
{
    internal class StateExpression : IExpression
    {
        private static int s_Count = 0;

        private int m_Index;
        private AbstractExpression m_State;
        private IExpression m_Left;
        private IExpression m_Right;

        public IExpression Left
        {
            get => m_Left;
            set
            {
                m_Left = value;
                m_State.Left = value;
            }
        }

        public IExpression Right
        {
            get => m_Right;
            set
            {
                m_Right = value;
                m_State.Right = value;
            }
        }

        public string SymbolOperation
        {
            get => m_State.SymbolOperation.ToString();
        }

        public StateExpression()
        {
            m_Index = s_Count++;
        }

        public void SetType<TypeExpression>()
            where TypeExpression : AbstractExpression, new()
        {
            m_State = new TypeExpression();
            m_State.Name = "F" + m_Index;
            m_State.Left = m_Left;
            m_State.Right = m_Right;
        }

        public string Name
        {
            get => m_State.Name;
            set => m_State.Name = value;
        }
        
        public string ShortString => m_State.ShortString;

        public string FullString => m_State.FullString;

        public override string ToString() => FullString;

        public bool Run() => m_State.Run();
    }
}
