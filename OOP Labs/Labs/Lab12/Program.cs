using Dialog;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuManager.Instance.Run(new Menu.MainMenu());
        }
    }
}
