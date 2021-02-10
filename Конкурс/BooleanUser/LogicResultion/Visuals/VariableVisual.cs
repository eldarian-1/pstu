namespace Resolution.Visuals
{
    public partial class VariableVisual : Logic.Visuals.VariableVisual, IVisible
    {
        public VariableVisual(bool isVisible = false) : base()
        {
            IsVisible = isVisible;
        }

        public bool IsVisible { get; private set; }

        public char Visual => IsVisible ? '✓' : '✖';

        public void ChangeVisible()
        {
            IsVisible = !IsVisible;
        }
    }
}
