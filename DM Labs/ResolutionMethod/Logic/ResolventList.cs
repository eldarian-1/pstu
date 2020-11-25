using Entity;
using System.Collections.Generic;

namespace Logic
{
    public class ResolventList : List<Resolvent>
    {
        public ResolventList() : base() { }

        public void Add<TSymbol>(IEnumerable<TSymbol> symbols)
            where TSymbol : ISymbol
        {
            foreach (TSymbol item in symbols)
                Add(new Resolvent(item));
        }

        public void Fill()
        {
            bool flag = true;
            for(IEnumerator<Resolvent> iter = GetEnumerator(); flag; flag = iter.MoveNext())
            {
                Resolvent newResolvent = new Resolvent(iter.Current);
                bool isAdded = false, isEnded = false;
                while(!isAdded && !isEnded)
                {
                    isAdded = newResolvent.Add(iter.Current);
                    isEnded = !iter.MoveNext();
                }
                if (isAdded)
                    Add(newResolvent);
            }
        }

        public string Solve()
        {
            string result = "Список резольвент:\n";
            int index = 1;
            foreach (Resolvent item in this)
                if (item.Solve)
                    result += index + ") " + item + "\n";
            return result;
        }
    }
}
