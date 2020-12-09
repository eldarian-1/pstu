using Dialog;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Waiter.Instance.Run(MainMenu.Instance);
        }
    }
}
