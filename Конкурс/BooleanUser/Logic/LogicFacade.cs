using Entity;
using Logic.Lists;
using Logic.Visuals;

namespace Logic
{
    public partial class LogicFacade
    {
        public VariableList Variables { get; protected set; }

        public FunctionList Functions { get; protected set; }

        public FunctionVisual ActiveFunction { get; protected set; }

        public LogicFacade()
        {
            Variables = new VariableList();
            Functions = new FunctionList();
            Initialize();
        }

        private void Initialize()
        {
            VariableVisual A = new VariableVisual();
            VariableVisual B = new VariableVisual();
            Variables.Add(A);
            Variables.Add(B);
            NewFunction(A, B);
        }

        public void InvertVariable(string name)
        {
            foreach(VariableVisual item in Variables)
                if(item.Name == name)
                {
                    item.Invert();
                    break;
                }
        }

        public virtual void AddVariable() => Variables.Add(new VariableVisual());

        public void ChangeSymbol(string name, bool isLeft) => new SymbolChanger(this, isLeft, name).Execute();

        protected virtual void NewFunction(Variable A, Variable B)
        {
            FunctionVisual F = new FunctionVisual();
            F.Left = A;
            F.Right = B;
            Functions.Add(F);
            ActiveFunction = F;
        }

        public void InvertSymbol(bool isLeft) => ActiveFunction.Invert(isLeft);

        public virtual void SetActiveFunction(string name)
        {
            foreach (var item in Functions)
                if (item.Name == name)
                {
                    ActiveFunction = item;
                    break;
                }
        }

        public void AddFunction() => NewFunction(Variables[0], Variables[1]);

        public void ChangeOperator() => ActiveFunction.Change();

        public string RunFunction() => new ResultFormater(this).Execute();
    }
}
