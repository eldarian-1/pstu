using Entity;

namespace Logic
{
    public class VariableVisual : Variable
    {
        public VariableVisual() : base() { }

        public char Data => Value ? '1' : '0';
    }
}
