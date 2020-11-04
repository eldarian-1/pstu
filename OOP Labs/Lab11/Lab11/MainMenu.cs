using System;
using Dialog;

namespace Lab11
{
    internal class MainMenu : IWaiter
    {
        private const string c_Menu =
            "Главное меню\n" +
            "1. Задание 1 - Queue\n" +
            "2. Задание 2 - Dictionary\n" +
            "3. Задание 3 - Stack и Dictionary\n" +
            "0. Выход\n" +
            "Выберете действие: ";

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
            Tasks = new MyList<Task>(Task1, Task2, Task3);
            Reactions = new MyList<Exception>();
        }

        private void Task1()
        {
            TaskRunner.Instance.Run(Task1Menu.Instance);
        }

        private void Task2()
        {
            TaskRunner.Instance.Run(Task2Menu.Instance);
        }

        private void Task3()
        {
            TaskRunner.Instance.Run(Task3Menu.Instance);
        }
    }
}
