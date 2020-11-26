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

        public new void Add(Resolvent resolvent)
        {
            if (!Contains(resolvent))
                base.Add(resolvent);
        }

        public void Fill()
        {
            for (int i = 0; i < Count; ++i)
            {
                int j = i + 1;
                while (j != i && j < Count)
                {
                    Resolvent resolvent = new Resolvent(this[i]);
                    if (resolvent.Add(this[j]))
                        Add(resolvent);
                    if (j == Count - 1)
                        j = 0;
                    else
                        ++j;
                }
            }
        }

        public string Solve()
        {
            string part1 = "Список резольвент:\n";
            string part2 = "Список противоречий:\n";
            int i0 = 1, i1 = 1;
            foreach (Resolvent item in this)
            {
                if(item.Solve)
                {
                    part1 += "(+) " + i0++ + ") " + item + "\n";
                    part2 += i1++ + ") " + item + "\n";
                }
                else
                {
                    part1 += i0++ + ") " + item + "\n";
                }
            }
            return part1 + "\n" + part2;
        }
    }
}
