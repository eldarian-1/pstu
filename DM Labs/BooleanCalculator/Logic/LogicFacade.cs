using Entity;
using System.Collections.ObjectModel;

namespace Logic
{
    public class LogicFacade
    {
        public ObservableCollection<SymbolAdapter> Symbols { get; protected set; }
        public ObservableCollection<StateExpression> Expressions { get; protected set; }
        public StateExpression ActiveExpression { get; protected set; }

        public LogicFacade()
        {
            Symbols = new ObservableCollection<SymbolAdapter>();
            Expressions = new ObservableCollection<StateExpression>();
            Initialize();
        }

        private void Initialize()
        {
            SymbolAdapter A = new SymbolAdapter();
            SymbolAdapter B = new SymbolAdapter();
            Symbols.Add(A);
            Symbols.Add(B);
            NewExpression(A, B);
        }

        public void InvertSymbol(string name)
        {
            foreach(SymbolExpression item in Symbols)
                if(item.Name == name)
                {
                    item.InvertValue();
                    break;
                }
        }

        public void AddSymbol() => Symbols.Add(new SymbolAdapter());

        public void ChangeSymbol(string name, bool isLeft) => new SymbolChanger(this, isLeft, name).Execute();

        private void NewExpression(SymbolExpression A, SymbolExpression B)
        {
            StateExpression F = new StateExpression();
            F.Left = A;
            F.Right = B;
            Expressions.Add(F);
            ActiveExpression = F;
        }

        public void InvertExpression(bool isLeft) => ActiveExpression.InvertExpression(isLeft);

        public void SetActiveExpression(string name)
        {
            foreach (StateExpression item in Expressions)
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
