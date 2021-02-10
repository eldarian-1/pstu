using Entity;
using Logic.Lists;
using Logic.Visuals;
using Logic.Commands;

namespace Logic
{
    public class LogicFacade
    {
        public VariableList Variables { get; protected set; }

        public FunctionList Functions { get; protected set; }

        public FunctionVisual ActiveFunction { get; protected set; }

        public LogicFacade()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            Variables = new VariableList();
            Functions = new FunctionList();
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

        public virtual string RunFunction() => new ResultFormater(this).Execute();
    }
}
