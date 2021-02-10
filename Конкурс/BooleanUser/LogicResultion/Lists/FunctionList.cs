using Resultion;

namespace Resolution.Lists
{
    public partial class FunctionList : Logic.Lists.FunctionList
    {
        public FunctionList() : base() { }

        public override string ToString()
        {
            string result = "";
            for (int i = 0, n = Count; i < n; ++i)
                if(this.Index(i).IsVisible)
                    result += (result != "" ? ", " : "")  + this[i];
            return result;
        }
    }
}
