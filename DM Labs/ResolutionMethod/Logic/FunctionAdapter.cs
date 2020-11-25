using Entity;

namespace Logic
{
    public class FunctionAdapter : Function
    {
        public FunctionAdapter() : base()
        {
            IsVisible = true;
        }

        public bool IsVisible { get; private set; }

        public char Visual => IsVisible ? 'f' : 'a';

        public void InvertVisible()
        {

        }
    }
}
