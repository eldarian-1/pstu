using Entity;
using System.Collections.ObjectModel;

namespace Logic
{
    internal class SymbolChanger
    {
        private Function m_ActiveFunction;
        private ObservableCollection<VariableVisual> m_Variables;
        private ObservableCollection<FunctionVisual> m_Functions;
        private bool m_IsLeft;
        private bool m_IsInversion;
        private string m_Name;

        public SymbolChanger(LogicFacade facade, bool isLeft, string name)
        {
            m_ActiveFunction = facade.ActiveFunction;
            m_Variables = facade.Variables;
            m_Functions = facade.Functions;
            m_IsLeft = isLeft;
            m_IsInversion = name[0] == Inversion.Operator;
            m_Name = name;
        }

        private void Change(ISymbol target)
        {
            if (m_IsInversion)
                target = new Inversion(target);
            if (m_IsLeft)
                m_ActiveFunction.Left = target;
            else
                m_ActiveFunction.Right = target;
        }

        private bool IsIt(ISymbol target)
        {
            string name = target.Name;
            if (m_IsInversion)
                name = Inversion.Operator + name;
            bool result = name == m_Name;
            return result;
        }

        private bool CheckSymbol(ISymbol symbol)
        {
            bool result = false;
            if (symbol is Function)
                result = IsExternal(symbol as Function);
            else if (symbol is Inversion
                && (symbol as Inversion).Original is Function)
                result = IsExternal((symbol as Inversion).Original as Function);
            return result;
        }

        private bool IsExternal(Function target)
        {
            bool result = false;
            if (target == m_ActiveFunction)
                result = true;
            if (!result)
                result = CheckSymbol(target.Left);
            if (!result)
                result = CheckSymbol(target.Right);
            return result;
        }

        private bool Find<TCollection, TValue>
            (TCollection collection, ref bool isFound)
            where TCollection : ObservableCollection<TValue>
            where TValue : ISymbol
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
            if (Find<ObservableCollection<VariableVisual>, VariableVisual>(m_Variables, ref isFound))
                return;
            if (Find<ObservableCollection<FunctionVisual>, FunctionVisual>(m_Functions, ref isFound))
                return;
            if (isFound)
                Change(m_Variables[0]);
        }
    }
}
