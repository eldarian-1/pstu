namespace Entity
{
    public class Function : ISymbol
    {
        private static int s_Count = 0;

        private ISymbol m_Left;
        private ISymbol m_Right;
        public AbstractExpression State { get; protected set; }

        public Function()
        {
            State = new AndExpression();
            Name = "F" + s_Count++;
        }

        public ISymbol Left
        {
            get => m_Left;
            set
            {
                m_Left = value;
                State.Left = value;
            }
        }

        public ISymbol Right
        {
            get => m_Right;
            set
            {
                m_Right = value;
                State.Right = value;
            }
        }

        public string Symbol  => State.Operator.ToString();

        public string Name { get; set; }
        
        public string Briefly => State.Briefly;

        public string Wholly => State.Wholly;

        public override string ToString() => Wholly;

        public bool Value => State.Value;

        public void Change()
        {
            State = State.Next;
            State.Left = m_Left;
            State.Right = m_Right;
        }

        public void Invert(bool isLeft)
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
