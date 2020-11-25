using Entity;

namespace Logic
{
    public class VariableVisual : Variable
    {
        public VariableVisual(bool isVisible = false) : base()
        {
            IsVisible = isVisible;
        }

        public bool IsVisible { get; private set; }

        public char Visual => IsVisible ? '✓' : '✖';

        public char Data => Value ? '1' : '0';

        public void ChangeVisible()
        {
            IsVisible = !IsVisible;
        }
    }
}
