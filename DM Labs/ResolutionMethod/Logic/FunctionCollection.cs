using System.Collections.ObjectModel;

namespace Logic
{
    public class FunctionCollection : ObservableCollection<FunctionVisual>
    {
        public FunctionCollection() : base() { }

        public override string ToString()
        {
            string result = "";
            for (int i = 0, n = Count; i < n; ++i)
                if(this[i].IsVisible)
                    result += (i > 0 ? ", " : "")  + this[i];
            return result;
        }
    }
}
