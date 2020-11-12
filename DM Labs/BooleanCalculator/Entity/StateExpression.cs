namespace Entity
{
    public class StateExpression : IExpression
    {
        private static int s_Count = 0;

        private IExpression m_Left;
        private IExpression m_Right;
        public AbstractExpression State { get; protected set; }

        public StateExpression()
        {
            State = new AndExpression();
            Name = "F" + s_Count++;
        }

        public IExpression Left
        {
            get => m_Left;
            set
            {
                m_Left = value;
                State.Left = value;
            }
        }

        public IExpression Right
        {
            get => m_Right;
            set
            {
                m_Right = value;
                State.Right = value;
            }
        }

        public string Symbol  => State.Symbol.ToString();

        public string Name { get; set; }
        
        public string Briefly => State.Briefly;

        public string Wholly => State.Wholly;

        public override string ToString() => Wholly;

        public bool Value => State.Value;

        public void ChangeExpression()
        {
            State = State.Next;
            State.Left = m_Left;
            State.Right = m_Right;
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
