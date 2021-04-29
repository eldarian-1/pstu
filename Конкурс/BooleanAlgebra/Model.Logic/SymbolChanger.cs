using System.Linq;
using Model.Entities;
using System.Collections.Generic;

namespace Model.Logic
{
    internal class SymbolChanger<TVariable, TFunction, TVariableList, TFunctionList>
        where TVariable : Variable, ISymbol, new()
        where TFunction : Function, ISymbol, new()
        where TVariableList : ICollection<TVariable>, new()
        where TFunctionList : ICollection<TFunction>, new()
    {
        private TFunction m_ActiveFunction;
        private TVariableList m_Variables;
        private TFunctionList m_Functions;
        private bool m_IsLeft;
        private bool m_IsInversion;
        private string m_Name;

        public SymbolChanger(
            LogicFacade<TVariable, TFunction, TVariableList, TFunctionList> facade,
            bool isLeft, string name)
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
            where TCollection : ICollection<TValue>
            where TValue : ISymbol
        {
            var coll = collection.ToList();
            for (int i = 0, n = collection.Count; i < n; ++i)
            {
                if (IsIt(coll[i]))
                    isFound = true;
                else if (isFound)
                {
                    if (coll[i] is Function && IsExternal(coll[i] as Function))
                        continue;
                    Change(coll[i]);
                    return true;
                }
            }
            return false;
        }

        public void Execute()
        {
            bool isFound = false;
            if (Find<TVariableList, TVariable>(m_Variables, ref isFound))
                return;
            if (Find<TFunctionList, TFunction>(m_Functions, ref isFound))
                return;
            if (isFound)
                Change(m_Variables.ToList()[0]);
        }
    }
}
