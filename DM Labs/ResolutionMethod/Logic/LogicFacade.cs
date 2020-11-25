using Entity;
using System.Collections.ObjectModel;

namespace Logic
{
    public class LogicFacade
    {
        public ObservableCollection<VariableAdapter> Variables { get; protected set; }
        public ObservableCollection<FunctionAdapter> Functions { get; protected set; }
        public FunctionAdapter ResultFunction { get; protected set; }
        public FunctionAdapter ActiveFunction { get; protected set; }

        public LogicFacade()
        {
            Variables = new ObservableCollection<VariableAdapter>();
            Functions = new ObservableCollection<FunctionAdapter>();
            Initialize();
        }

        private void Initialize()
        {
            VariableAdapter A = new VariableAdapter();
            VariableAdapter B = new VariableAdapter();
            ResultFunction = new FunctionAdapter() { Left = A, Right = B, Name = "G" };
            Variables.Add(A);
            Variables.Add(B);
            NewFunction(A, B);
        }

        public void InvertVariable(string name)
        {
            foreach(VariableAdapter item in Variables)
                if(item.Name == name)
                {
                    item.Invert();
                    break;
                }
        }

        public void AddVariable() => Variables.Add(new VariableAdapter());

        public void ChangeSymbol(string name, bool isLeft) => new SymbolChanger(this, isLeft, name).Execute();

        private void NewFunction(Variable A, Variable B)
        {
            FunctionAdapter F = new FunctionAdapter();
            F.Left = A;
            F.Right = B;
            Functions.Add(F);
            ActiveFunction = F;
        }

        public void InvertSymbol(bool isLeft) => ActiveFunction.Invert(isLeft);

        public void SetActiveFunction(string name)
        {
            if(name == ResultFunction.Name)
            {
                ActiveFunction = ResultFunction;
                return;
            }
            foreach (FunctionAdapter item in Functions)
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
