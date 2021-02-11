using Model.Entities.Operations;

namespace Model.Entities
{
    public class Function : ISymbol
    {
        private static int s_Count = 0;

        private ISymbol m_Left;
        private ISymbol m_Right;

        public Function()
        {
            Operation = new LogicalAND();
            Name = "S" + s_Count++;
        }

        public ISymbol Left
        {
            get => m_Left;
            set
            {
                m_Left = value;
                Operation.Left = value;
            }
        }

        public ISymbol Right
        {
            get => m_Right;
            set
            {
                m_Right = value;
                Operation.Right = value;
            }
        }

        public AOperation Operation { get; protected set; }

        public char OperationSymbol => Operation.OperationSymbol;

        public string Name { get; set; }
        
        public string Briefly
        {
            get
            {
                string result;
                if (Left.Equals(Right) && (Operation is LogicalAND || Operation is LogicalOR))
                    result = Left.Name;
                else
                    result = Operation.Briefly;
                return result;
            }
        }

        public string Wholly
        {
            get
            {
                string result = "";

                if (Left.Equals(Right) && (Operation is LogicalAND || Operation is LogicalOR))
                {
                    result = Left.Wholly;
                }
                else
                {
                    if (Left is Function && Operation.Priority > (Left as Function).Operation.Priority)
                        result += "(" + Left.Wholly + ") ";
                    else
                        result += Left.Wholly;

                    result += " " + Operation.OperationSymbol + " ";

                    if (Right is Function && Operation.Priority > (Right as Function).Operation.Priority)
                        result += "(" + Right.Wholly + ") ";
                    else if(Right is Function && Operation.Priority == (Right as Function).Operation.Priority
                        && !((Right as Function).Operation is LogicalAND)
                        && !((Right as Function).Operation is LogicalOR))
                        result += "(" + Right.Wholly + ") ";
                    else
                        result += Right.Wholly;
                }

                return result;
            }
        }

        public override string ToString() => Wholly;

        public bool Value => Operation.Value;

        public void Change()
        {
            Operation = Operation.Next;
            Operation.Left = m_Left;
            Operation.Right = m_Right;
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
