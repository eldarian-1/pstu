using Dialog;

namespace Lab13
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            MenuManager.Instance.Run(new MainMenu());
        }
    }
}
