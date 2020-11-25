using Entity;

namespace Logic
{
    public class FunctionVisual : Function
    {
        public FunctionVisual() : base()
        {
            IsVisible = true;
        }

        public bool IsVisible { get; private set; }

        public char Visual => IsVisible ? '✓' : '✖';

        public void ChangeVisible()
        {
            IsVisible = !IsVisible;
        }
    }
}
