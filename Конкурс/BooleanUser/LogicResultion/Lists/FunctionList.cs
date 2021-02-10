using Resolution.Visuals;
using System.Collections.ObjectModel;

namespace Resolution.Lists
{
    public partial class FunctionList : ObservableCollection<FunctionVisual>
    {
        public FunctionList() : base() { }

        public override string ToString()
        {
            string result = "";
            for (int i = 0, n = Count; i < n; ++i)
                if(this[i].IsVisible)
                    result += (result != "" ? ", " : "")  + this[i];
            return result;
        }
    }
}
