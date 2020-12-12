using Dialog;

namespace Lab14
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            MenuManager.Instance.Run(new MainMenu());
        }
    }
}
