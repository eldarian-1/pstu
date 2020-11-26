using Entity;

namespace Logic
{
    public class LogicFacade
    {
        public VariableList Variables { get; protected set; }
        public FunctionList Functions { get; protected set; }
        public string Expressions
        {
            get
            {
                string variables = Variables.ToString();
                string functions = Functions.ToString();
                string middle = (variables != "" && functions != "" ? ", " : "");
                return variables + middle + functions;
            }
        }
        public FunctionVisual ResultFunction { get; protected set; }
        public FunctionVisual ActiveFunction { get; protected set; }

        public LogicFacade()
        {
            Variables = new VariableList();
            Functions = new FunctionList();
            Initialize();
        }

        private void Initialize()
        {
            VariableVisual A = new VariableVisual(true);
            VariableVisual B = new VariableVisual();
            ResultFunction = new FunctionVisual() { Left = B, Right = B, Name = "G" };
            Variables.Add(A);
            Variables.Add(B);
            NewFunction(A, B);
            ActiveFunction.Change();
            ActiveFunction.Change();
        }

        public void ChangeVisibleVariable(string name)
        {
            foreach (VariableVisual item in Variables)
                if (item.Name == name)
                {
                    item.ChangeVisible();
                    break;
                }
        }

        public void ChangeVisibleFunction(string name)
        {
            foreach (FunctionVisual item in Functions)
                if (item.Name == name)
                {
                    item.ChangeVisible();
                    break;
                }
        }

        public void AddVariable() => Variables.Add(new VariableVisual());

        public void ChangeSymbol(string name, bool isLeft) => new SymbolChanger(this, isLeft, name).Execute();

        private void NewFunction(Variable A, Variable B)
        {
            FunctionVisual F = new FunctionVisual();
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
            foreach (FunctionVisual item in Functions)
                if (item.Name == name)
                {
                    ActiveFunction = item;
                    break;
                }
        }

        public void AddFunction() => NewFunction(Variables[0], Variables[1]);

        public void ChangeOperator() => ActiveFunction.Change();

        public string RunFunction() => new ResultFormater(this).Execute();

        public string RunResulution()
        {
            ResolventList list = new ResolventList();
            list.Add(Variables);
            list.Add(Functions);
            list.Set(ResultFunction);
            list.Fill();
            return list.Solve();
        }
    }
}
