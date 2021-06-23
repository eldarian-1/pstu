using Model.Entities;

namespace UseCase.Resolution.Visuals
{
    public partial class FunctionVisual : Function, IVisible
    {
        public FunctionVisual()
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
