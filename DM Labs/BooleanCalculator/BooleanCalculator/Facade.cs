using BooleanCalculator.Expression;
using System;
using System.Collections.ObjectModel;

namespace BooleanCalculator
{
    internal class Facade
    {
        public ObservableCollection<SymbolExpression> Symbols { get; protected set; }
        public ObservableCollection<StateExpression> Expressions { get; protected set; }
        public StateExpression ActiveExpression { get; protected set; }

        public Facade()
        {
            Symbols = new ObservableCollection<SymbolExpression>();
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
            Symbols.Add(A);
            Symbols.Add(B);
            Expressions.Add(F);
            ActiveExpression = F;
        }

        public void InvertBySymbol(string name)
        {
            foreach(SymbolExpression item in Symbols)
                if(item.Name == name)
                {
                    item.InvertValue();
                    break;
                }
        }

        public void AddSymbol()
        {
            Symbols.Add(new SymbolExpression(true));
        }

        public void ChangeSymbol(IExpression expression, bool isLeft)
        {
            if (isLeft)
                ActiveExpression.Left = expression;
            else
                ActiveExpression.Right = expression;
        }

        public void ChangeSymbol(string name, bool isLeft)
        {
            bool find = false;

            foreach (SymbolExpression item in Symbols)
            {
                if (item.Name == name)
                    find = true;
                else if (find == true)
                {
                    ChangeSymbol(item, isLeft);
                    return;
                }
            }

            foreach (StateExpression item in Expressions)
            {
                if (item.Name == name)
                    find = true;
                else if (find == true)
                {
                    if (item.Name == ActiveExpression.Name)
                        continue;
                    ChangeSymbol(item, isLeft);
                    return;
                }
            }

            if (find)
                ChangeSymbol(Symbols[0], isLeft);
        }

        public void InvertSymbol(bool isLeft)
        {
            if (isLeft)
                if (ActiveExpression.Left is InversionExpression)
                    ActiveExpression.Left = (ActiveExpression.Left as InversionExpression).OriginalExpression;
                else
                    ActiveExpression.Left = new InversionExpression(ActiveExpression.Left);
            else
                if (ActiveExpression.Right is InversionExpression)
                ActiveExpression.Right = (ActiveExpression.Right as InversionExpression).OriginalExpression;
            else
                ActiveExpression.Right = new InversionExpression(ActiveExpression.Right);
        }

        public void AddExpression()
        {
            SymbolExpression A = Symbols[0];
            SymbolExpression B = Symbols[1];
            StateExpression F = new StateExpression();
            F.SetType<OrExpression>();
            F.Left = A;
            F.Right = B;
            Expressions.Add(F);
            ActiveExpression = F;
        }

        public void ChangeExpression(string symbol)
        {
            switch (symbol)
            {
                case "v":
                    ActiveExpression.SetType<AndExpression>();
                    break;
                case "&":
                    ActiveExpression.SetType<XorExpression>();
                    break;
                case "+":
                    ActiveExpression.SetType<EquivalenceExpression>();
                    break;
                case "~":
                    ActiveExpression.SetType<ImplicationExpression>();
                    break;
                case "→":
                    ActiveExpression.SetType<ShefferExpression>();
                    break;
                case "|":
                    ActiveExpression.SetType<PearsExpression>();
                    break;
                case "↓":
                    ActiveExpression.SetType<OrExpression>();
                    break;
            }
        }

        public string RunExpression()
        {
            string result
                = "Результат на заданном наборе: "
                + GetNum(ActiveExpression.Run())
                + "\n\nТаблица истинности:\n";

            int size = Symbols.Count;
            for (int i = 0; i < size; ++i)
                result += ((char)('A' + i)).ToString();
            result += " Res\n";

            int[] devide = new int[size];
            for (int i = 0; i < size; ++i)
                devide[i] = (int)Math.Pow(2, i);

            for (int i = 0, n = (int)Math.Pow(2, size); i < n; ++i)
            {
                for(int j = 0; j < size; ++j)
                {
                    int num = (i & devide[size - 1 - j]) / devide[size - 1 - j];
                    Symbols[j].Set(num);
                    result += num;
                }
                result += " " + GetNum(ActiveExpression.Run()) + "\n";
            }

            return result;
        }

        public string GetNum(bool val)
        {
            if (val)
                return "1";
            else
                return "0";
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
