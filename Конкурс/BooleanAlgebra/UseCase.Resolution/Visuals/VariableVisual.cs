using Model.Entities;

namespace UseCase.Resolution.Visuals
{
    public partial class VariableVisual : Variable, IVisible
    {
        public VariableVisual() : base()
        {
            IsVisible = false;
        }

        public VariableVisual(bool isVisible) : base()
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
