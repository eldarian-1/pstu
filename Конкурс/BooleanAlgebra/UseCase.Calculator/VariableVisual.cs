using Model.Entities;

namespace UseCase.Calculator
{
    public class VariableVisual : Variable
    {
        public char Data => Value ? '1' : '0';
    }
}
