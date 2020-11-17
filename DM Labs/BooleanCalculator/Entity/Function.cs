namespace Entity
{
    public class Function : IExpression
    {
        private static int s_Count = 0;

        private IExpression m_Left;
        private IExpression m_Right;
        public AbstractExpression State { get; protected set; }

        public Function()
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
                if (Left is Inversion)
                    Left = (Left as Inversion).Original;
                else
                    Left = new Inversion(Left);
            else if (Right is Inversion)
                Right = (Right as Inversion).Original;
            else
                Right = new Inversion(Right);
        }
    }
}
