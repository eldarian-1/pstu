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
            Name = "S" + s_Count++;
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

        public char Operator => State.Operator;

        public string Name { get; set; }
        
        public string Briefly => State.Briefly;

        public string Wholly
        {
            get
            {
                string result = "";

                if (Left == Right && (State is AndExpression || State is OrExpression))
                {
                    result = Left.Name;
                }
                else
                {
                    if (Left is Function && State.Priority > (Left as Function).State.Priority)
                        result += "(" + Left.Wholly + ") ";
                    else
                        result += Left.Wholly;

                    result += " " + State.Operator + " ";

                    if (Right is Function && State.Priority > (Right as Function).State.Priority)
                        result += "(" + Right.Wholly + ") ";
                    else
                        result += Right.Wholly;
                }

                return result;
            }
        }

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
