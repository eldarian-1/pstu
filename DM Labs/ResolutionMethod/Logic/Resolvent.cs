using Entity;
using System.Collections;
using System.Collections.Generic;

namespace Logic
{
    public class Resolvent : ISymbol, IEnumerable
    {
        private List<ISymbol> m_Symbols;

        public Resolvent(ISymbol symbol)
        {
            m_Symbols = new List<ISymbol>();
            m_Symbols.Add(symbol);
        }

        public Resolvent(Resolvent resolvent)
        {
            m_Symbols = new List<ISymbol>();
            foreach(ISymbol item in resolvent.m_Symbols)
                m_Symbols.Add(item);
        }

        public bool Add(ISymbol symbol)
        {
            bool result = false;
            if(this != symbol)
                if (symbol is Resolvent)
                {
                    int count = 0;
                    foreach (ISymbol item in (symbol as Resolvent))
                        if (!m_Symbols.Contains(item))
                        {
                            m_Symbols.Add(item);
                            ++count;
                        }
                    result = count > 0;
                }
                else if (!m_Symbols.Contains(symbol))
                {
                    m_Symbols.Add(symbol);
                    result = true;
                }
            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return m_Symbols.GetEnumerator();
        }

        public bool Value
        {
            get
            {
                bool result = true;
                foreach (ISymbol item in m_Symbols)
                    result = result && item.Value;
                return result;
            }
        }

        public bool Solve
        {
            get
            {
                bool result = false;
                VariableList.Variables.Reset();
                for (int i = 0, n = VariableList.Variables.Size; i < n && !result; ++i)
                {
                    result = Value;
                    VariableList.Variables.Next();
                }
                return !result;
            }
        }

        public int Count => m_Symbols.Count;

        public string Name => throw new System.NotImplementedException();

        public string Briefly => throw new System.NotImplementedException();

        public string Wholly => throw new System.NotImplementedException();

        public override string ToString()
        {
            string result = "";
            for (int i = 0, n = m_Symbols.Count; i < n; ++i)
                result += (i > 0 ? ", " : "") + m_Symbols[i];
            return result;
        }

        public override bool Equals(object obj)
        {
            Resolvent temp = obj as Resolvent;
            bool result = temp.Count == Count;
            if(result)
                foreach (ISymbol item in m_Symbols)
                    if (!temp.m_Symbols.Contains(item))
                    {
                        result = false;
                        break;
                    }
            return result;
        }
    }
}
