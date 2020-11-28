using Entity;
using System.Collections.ObjectModel;

namespace Logic
{
    public class LogicFacade
    {
        public ObservableCollection<VariableVisual> Variables { get; protected set; }
        public ObservableCollection<Function> Functions { get; protected set; }
        public Function ActiveFunction { get; protected set; }

        public LogicFacade()
        {
            Variables = new ObservableCollection<VariableVisual>();
            Functions = new ObservableCollection<Function>();
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

        public void AddVariable() => Variables.Add(new VariableVisual());

        public void ChangeSymbol(string name, bool isLeft) => new SymbolChanger(this, isLeft, name).Execute();

        private void NewFunction(Variable A, Variable B)
        {
            Function F = new Function();
            F.Left = A;
            F.Right = B;
            Functions.Add(F);
            ActiveFunction = F;
        }

        public void InvertSymbol(bool isLeft) => ActiveFunction.Invert(isLeft);

        public void SetActiveFunction(string name)
        {
            foreach (Function item in Functions)
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
