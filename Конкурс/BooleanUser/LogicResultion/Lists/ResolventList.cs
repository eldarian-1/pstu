using Entity;
using System.Collections.Generic;

namespace Resolution.Lists
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
            where TSymbol : ISymbol, IVisible
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
            string part1 = "", part2 = "";
            int i0 = 1, i1 = 1;
            foreach (Resolvent item in this)
            {
                if(item.Solve)
                {
                    part1 += "\n" + "(+) " + i0++ + ") " + item;
                    part2 += "\n" + i1++ + ") " + item;
                }
                else
                {
                    part1 += "\n" + i0++ + ") " + item;
                }
            }
            if (part1 != "")
                part1 = "Список предложений и их комбинаций:" + part1;
            else
                part1 = "Список предложений и их комбинаций пуст.";
            if (part2 != "")
                part2 = "Список противоречивых комбинаций:" + part2;
            else
                part2 = "Список противоречивых комбинаций пуст.";
            return part1 + "\n\n" + part2;
        }
    }
}
