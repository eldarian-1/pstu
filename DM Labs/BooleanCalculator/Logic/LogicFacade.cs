using Entity;
using System.Collections.ObjectModel;

namespace Logic
{
    public class LogicFacade
    {
        public ObservableCollection<VariableAdapter> Symbols { get; protected set; }
        public ObservableCollection<Function> Expressions { get; protected set; }
        public Function ActiveExpression { get; protected set; }

        public LogicFacade()
        {
            Symbols = new ObservableCollection<VariableAdapter>();
            Expressions = new ObservableCollection<Function>();
            Initialize();
        }

        private void Initialize()
        {
            VariableAdapter A = new VariableAdapter();
            VariableAdapter B = new VariableAdapter();
            Symbols.Add(A);
            Symbols.Add(B);
            NewExpression(A, B);
        }

        public void InvertSymbol(string name)
        {
            foreach(Variable item in Symbols)
                if(item.Name == name)
                {
                    item.InvertValue();
                    break;
                }
        }

        public void AddSymbol() => Symbols.Add(new VariableAdapter());

        public void ChangeSymbol(string name, bool isLeft) => new SymbolChanger(this, isLeft, name).Execute();

        private void NewExpression(Variable A, Variable B)
        {
            Function F = new Function();
            F.Left = A;
            F.Right = B;
            Expressions.Add(F);
            ActiveExpression = F;
        }

        public void InvertExpression(bool isLeft) => ActiveExpression.InvertExpression(isLeft);

        public void SetActiveExpression(string name)
        {
            foreach (Function item in Expressions)
                if (item.Name == name)
                {
                    ActiveExpression = item;
                    break;
                }
        }

        public void AddExpression() => NewExpression(Symbols[0], Symbols[1]);

        public void ChangeExpression() => ActiveExpression.ChangeExpression();

        public string RunExpression() => new ResultFormater(this).Execute();
    }
}
