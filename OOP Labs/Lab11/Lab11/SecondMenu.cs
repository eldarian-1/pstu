using System;
using Dialog;

namespace Lab11
{
    class SecondMenu : IWaiter
    {
        private const string c_Menu =
            "Второстепенное меню\n" +
            "1. Enter1\n" +
            "2. Enter2\n" +
            "0. Назад\n" +
            "Выберете действие: ";
        private static readonly Exception UnknownError
            = new Exception("Неизвестная ошибка");

        private static SecondMenu s_Instance = null;

        public static SecondMenu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new SecondMenu();
                return s_Instance;
            }
        }

        public string Menu { get; }
        public MyList<Task> Tasks { get; }
        public MyList<Exception> Reactions { get; }

        private SecondMenu()
        {
            Menu = c_Menu;
            Tasks = new MyList<Task>(Enter1, Enter2);
            Reactions = new MyList<Exception>(UnknownError);
        }

        private void Enter1()
        {
            TaskRunner.Write("Hello World!");
        }

        private void Enter2()
        {
            throw UnknownError;
        }
    }
}
