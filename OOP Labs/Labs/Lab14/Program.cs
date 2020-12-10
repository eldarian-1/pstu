using Dialog;

namespace Lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Waiter.Instance.Run(MainMenu.Instance);
        }
    }
}
