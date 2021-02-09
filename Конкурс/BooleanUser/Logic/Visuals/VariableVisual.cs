using Entity;

namespace Logic.Visuals
{
    public partial class VariableVisual : Variable
    {
        public VariableVisual() : base() { }

        public char Data => Value ? '1' : '0';
    }
}
