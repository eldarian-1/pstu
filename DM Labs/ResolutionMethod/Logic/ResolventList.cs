using Entity;
using System.Collections.Generic;

namespace Logic
{
    public class ResolventList : List<Resolvent>
    {
        private bool m_IsSetted;

        public ResolventList() : base()
        {
            m_IsSetted = false;
        }

        public void Set(ISymbol symbol)
        {
            if(!m_IsSetted)
            {
                Add(new Resolvent(new Inversion(symbol)));
                m_IsSetted = true;
            }
        }

        public void Add<TSymbol>(IEnumerable<TSymbol> symbols)
            where TSymbol : ISymbol, IResolvent
        {
            foreach (TSymbol item in symbols)
                if(item.IsVisible)
                    Add(new Resolvent(item));
        }

        public void Fill()
        {
            for (int i = 0; i < Count; ++i)
            {
                int j = i;
                Resolvent newResolvent = new Resolvent(this[i++]);
                bool isAdded = false;
                while(!isAdded && i < Count)
                    isAdded = newResolvent.Add(this[i++]);
                if (isAdded && !Contains(newResolvent))
                    Add(newResolvent);
                i = j;
            }
        }

        public string Solve()
        {
            string result = "Список резольвент:\n";
            int index = 1;
            foreach (Resolvent item in this)
                result += (item.Solve ? "(+) " : "") + index++ + ") " + item + "\n";
            return result;
        }
    }
}
