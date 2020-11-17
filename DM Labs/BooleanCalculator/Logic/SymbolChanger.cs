using Entity;
using System.Collections.ObjectModel;

namespace Logic
{
    internal class SymbolChanger
    {
        private Function m_ActiveExpression;
        private ObservableCollection<VariableAdapter> m_Symbols;
        private ObservableCollection<Function> m_Expressions;
        private bool m_IsLeft;
        private bool m_IsInversion;
        private string m_Name;

        public SymbolChanger(LogicFacade facade, bool isLeft, string name)
        {
            m_ActiveExpression = facade.ActiveExpression;
            m_Symbols = facade.Symbols;
            m_Expressions = facade.Expressions;
            m_IsLeft = isLeft;
            m_IsInversion = name[0] == Inversion.Symbol;
            m_Name = name;
        }

        private void Change(IExpression target)
        {
            if (m_IsInversion)
                target = new Inversion(target);
            if (m_IsLeft)
                m_ActiveExpression.Left = target;
            else
                m_ActiveExpression.Right = target;
        }

        private bool IsIt(IExpression target)
        {
            string name = target.Name;
            if (m_IsInversion)
                name = Inversion.Symbol + name;
            bool result = name == m_Name;
            return result;
        }

        private bool IsExternal(Function target)
        {
            bool result = false;
            if (target == m_ActiveExpression)
                result = true;
            if (!result && target.Left is Function)
                result = IsExternal(target.Left as Function);
            if (!result && target.Right is Function)
                result = IsExternal(target.Right as Function);
            return result;
        }

        private bool Find<TCollection, TValue>
            (TCollection collection, ref bool isFound)
            where TCollection : ObservableCollection<TValue>
            where TValue : IExpression
        {
            for(int i = 0, n = collection.Count; i < n; ++i)
            {
                if (IsIt(collection[i]))
                    isFound = true;
                else if (isFound)
                {
                    if (collection[i] is Function && IsExternal(collection[i] as Function))
                        continue;
                    Change(collection[i]);
                    return true;
                }
            }
            return false;
        }

        public void Execute()
        {
            bool isFound = false;
            if (Find<ObservableCollection<VariableAdapter>, VariableAdapter>(m_Symbols, ref isFound))
                return;
            if (Find<ObservableCollection<Function>, Function>(m_Expressions, ref isFound))
                return;
            if (isFound)
                Change(m_Symbols[0]);
        }
    }
}
