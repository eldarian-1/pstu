namespace Resolution.Visuals
{
    public interface IVisible
    {
        bool IsVisible { get; }

        char Visual { get; }

        void ChangeVisible();
    }
}
