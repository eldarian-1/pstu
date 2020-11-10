using BooleanCalculator.Expression;
using System.Collections.ObjectModel;

namespace BooleanCalculator
{
    internal class Facade
    {
        public ObservableCollection<SymbolExpression> Simbols { get; protected set; }
        public ObservableCollection<StateExpression> Expressions { get; protected set; }
        public StateExpression ActiveExpression { get; protected set; }

        public Facade()
        {
            Simbols = new ObservableCollection<SymbolExpression>();
            Expressions = new ObservableCollection<StateExpression>();
            Initialize();
        }

        private void Initialize()
        {
            SymbolExpression A = new SymbolExpression(true);
            SymbolExpression B = new SymbolExpression(true);
            StateExpression F = new StateExpression();
            F.SetType<OrExpression>();
            F.Left = A;
            F.Right = B;
            Simbols.Add(A);
            Simbols.Add(B);
            Expressions.Add(F);
            ActiveExpression = F;

            A = new SymbolExpression(true);
            B = new SymbolExpression(true);
            F = new StateExpression();
            F.SetType<AndExpression>();
            F.Left = A;
            F.Right = B;
            Simbols.Add(A);
            Simbols.Add(B);
            Expressions.Add(F);
        }

        public void InvertBySymbol(string name)
        {
            foreach(SymbolExpression item in Simbols)
                if(item.Name == name)
                {
                    item.InvertValue();
                    break;
                }
        }

        public void AddSymbol()
        {
            Simbols.Add(new SymbolExpression(true));
        }

        public void ChangeSymbol()
        {
            Simbols.Add(new SymbolExpression(true));
        }

        public void AddExpression()
        {
            Simbols.Add(new SymbolExpression(true));
        }

        public void SetActiveExpression(string name)
        {
            foreach (StateExpression item in Expressions)
                if (item.Name == name)
                {
                    ActiveExpression = item;
                    break;
                }
        }
    }
}
