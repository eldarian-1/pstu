namespace Entity
{
    public class StateExpression : IExpression
    {
        private static int s_Count = 0;

        private IExpression m_Left;
        private IExpression m_Right;
        private AbstractExpression m_State;

        public StateExpression()
        {
            m_State = new OrExpression();
            Name = "F" + s_Count++;
        }

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

        public string Symbol  => m_State.Symbol.ToString();

        public string Name { get; set; }
        
        public string Briefly => m_State.Briefly;

        public string Wholly => m_State.Wholly;

        public override string ToString() => Wholly;

        public bool Value => m_State.Value;

        public void ChangeExpression()
        {
            m_State = m_State.Next;
            m_State.Left = m_Left;
            m_State.Right = m_Right;
        }

        public void InvertExpression(bool isLeft)
        {
            if (isLeft)
                if (Left is InversionExpression)
                    Left = (Left as InversionExpression).Original;
                else
                    Left = new InversionExpression(Left);
            else if (Right is InversionExpression)
                Right = (Right as InversionExpression).Original;
            else
                Right = new InversionExpression(Right);
        }
    }
}
