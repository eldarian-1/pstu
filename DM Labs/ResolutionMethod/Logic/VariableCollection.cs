using System.Collections.ObjectModel;

namespace Logic
{
    public class VariableCollection : ObservableCollection<VariableVisual>
    {
        public VariableCollection() : base() { }

        public override string ToString()
        {
            string result = "";
            for (int i = 0, n = Count; i < n; ++i)
                if (this[i].IsVisible)
                    result += (i > 0 ? ", " : "") + this[i];
            return result;
        }
    }
}
