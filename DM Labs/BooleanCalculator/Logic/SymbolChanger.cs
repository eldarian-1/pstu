using Entity;
using System.Collections.ObjectModel;

namespace Logic
{
    class SymbolChanger
    {
        private Facade m_Facade;
        private bool m_IsLeft;
        private string m_Name;

        public SymbolChanger(Facade facade, bool isLeft, string name)
        {
            m_Facade = facade;
            m_IsLeft = isLeft;
            m_Name = name;
        }

        private void Change(IExpression target)
        {
            if (m_IsLeft)
                m_Facade.ActiveExpression.Left = target;
            else
                m_Facade.ActiveExpression.Right = target;
        }

        private bool Find<TCollection, TValue>(TCollection collection, ref bool isFound)
            where TCollection : ObservableCollection<TValue>
            where TValue : IExpression
        {
            foreach (TValue item in collection)
            {
                if (item.Name == m_Name)
                    isFound = true;
                else if (isFound == true)
                {
                    Change(item);
                    return true;
                }
            }
            return false;
        }

        public void Run()
        {
            bool isFound = false;
            if (Find<ObservableCollection<SymbolAdapter>, SymbolAdapter>(m_Facade.Symbols, ref isFound))
                return;
            if (Find<ObservableCollection<StateExpression>, StateExpression>(m_Facade.Expressions, ref isFound))
                return;
            if (isFound)
                Change(m_Facade.Symbols[0]);
        }
    }
}
