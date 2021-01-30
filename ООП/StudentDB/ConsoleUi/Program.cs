using Dialog;
using ConsoleUi.Menus;

namespace ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuManager.Instance.Run(new MainMenu(new Mediator()));
        }
    }
}
