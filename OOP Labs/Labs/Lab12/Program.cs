using Dialog;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Waiter.Instance.Run(Menu.MainMenu.Instance);
        }
    }
}
