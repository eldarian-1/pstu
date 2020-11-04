using System;
using Dialog;

namespace Lab11
{
    class Task3Menu : IWaiter
    {
        private const string c_Menu =
            "Меню Stack и Dictionary\n" +
            "1. Enter1\n" +
            "2. Enter2\n" +
            "0. Назад\n" +
            "Выберете действие: ";
        private static readonly Exception UnknownError
            = new Exception("Неизвестная ошибка");

        private static Task3Menu s_Instance = null;

        public static Task3Menu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new Task3Menu();
                return s_Instance;
            }
        }

        public string Menu { get; }
        public MyList<Task> Tasks { get; }
        public MyList<Exception> Reactions { get; }

        private Task3Menu()
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
