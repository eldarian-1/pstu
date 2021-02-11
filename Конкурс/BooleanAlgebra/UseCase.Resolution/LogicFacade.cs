using Model.Logic;
using UseCase.Resolution.Lists;
using UseCase.Resolution.Visuals;

namespace UseCase.Resolution
{
    public class LogicFacade : LogicFacade<VariableVisual, FunctionVisual, VariableList, FunctionList>
    {
        public FunctionVisual ResultFunction { get; protected set; }

        public LogicFacade() { }

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

        protected override void Initialize()
        {
            Variables = new VariableList();
            Functions = new FunctionList();
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

        public string RunFunction() => RunFunction<ResultFormater>();

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
