using System;
using Dialog;

namespace Lab11
{
    internal class MainMenu : IWaiter
    {
        private const string c_Menu =
            "Главное меню\n" +
            "1. Enter1\n" +
            "2. Enter2\n" +
            "0. Выход\n" +
            "Выберете действие: ";
        private static readonly Exception UnknownError
            = new Exception("Неизвестная ошибка");

        private static MainMenu s_Instance = null;

        public static MainMenu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new MainMenu();
                return s_Instance;
            }
        }

        public string Menu { get; }
        public MyList<Task> Tasks { get; }
        public MyList<Exception> Reactions { get; }

        private MainMenu()
        {
            Menu = c_Menu;
            Tasks = new MyList<Task>(Enter1, Enter2);
            Reactions = new MyList<Exception>(UnknownError);
        }

        private void Enter1()
        {
            Console.WriteLine("Hello World!");
        }

        private void Enter2()
        {
            throw UnknownError;
        }
    }
}
