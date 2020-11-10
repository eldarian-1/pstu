namespace BooleanCalculator.Expression
{
    internal class StateExpression : IExpression
    {
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

        public StateExpression() {}

        public void SetType<TypeExpression>()
            where TypeExpression : AbstractExpression, new()
        {
            m_State = new TypeExpression();
        }

        public string Name => m_State.Name;

        public string ShortString => m_State.ShortString;

        public string FullString => m_State.FullString;

        public bool Run() => m_State.Run();
    }
}
