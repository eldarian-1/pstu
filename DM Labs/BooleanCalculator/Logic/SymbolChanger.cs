using Entity;
using System.Collections.ObjectModel;

namespace Logic
{
    internal class SymbolChanger
    {
        private StateExpression m_ActiveExpression;
        private ObservableCollection<SymbolAdapter> m_Symbols;
        private ObservableCollection<StateExpression> m_Expressions;
        private bool m_IsLeft;
        private bool m_IsInversion;
        private string m_Name;

        public SymbolChanger(LogicFacade facade, bool isLeft, string name)
        {
            m_ActiveExpression = facade.ActiveExpression;
            m_Symbols = facade.Symbols;
            m_Expressions = facade.Expressions;
            m_IsLeft = isLeft;
            m_IsInversion = name[0] == InversionExpression.Symbol;
            m_Name = name;
        }

        private void Change(IExpression target)
        {
            if (m_IsInversion)
                target = new InversionExpression(target);
            if (m_IsLeft)
                m_ActiveExpression.Left = target;
            else
                m_ActiveExpression.Right = target;
        }

        private bool IsIt(IExpression target)
        {
            string name = target.Name;
            if (m_IsInversion)
                name = InversionExpression.Symbol + name;
            bool result = name == m_Name;
            return result;
        }

        private bool IsExternal(StateExpression target)
        {
            bool result = false;
            if (target == m_ActiveExpression)
                result = true;
            if (!result && target.Left is StateExpression)
                result = IsExternal(target.Left as StateExpression);
            if (!result && target.Right is StateExpression)
                result = IsExternal(target.Right as StateExpression);
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
                    if (collection[i] is StateExpression && IsExternal(collection[i] as StateExpression))
                        continue;
                    Change(collection[i]);
                    return true;
                }
            }
            return false;
        }

        public void Run()
        {
            bool isFound = false;
            if (Find<ObservableCollection<SymbolAdapter>, SymbolAdapter>(m_Symbols, ref isFound))
                return;
            if (Find<ObservableCollection<StateExpression>, StateExpression>(m_Expressions, ref isFound))
                return;
            if (isFound)
                Change(m_Symbols[0]);
        }
    }
}
