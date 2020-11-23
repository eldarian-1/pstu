using Entity;

namespace Logic
{
    public class VariableAdapter : Variable
    {
        public VariableAdapter() : base() { }

        public char Data => Value ? '1' : '0';
    }
}
