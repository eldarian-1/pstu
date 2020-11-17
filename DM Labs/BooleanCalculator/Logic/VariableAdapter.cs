using Entity;

namespace Logic
{
    public class VariableAdapter : Variable
    {
        public VariableAdapter() : base() { }

        public string Data => Value ? "1" : "0";
    }
}
