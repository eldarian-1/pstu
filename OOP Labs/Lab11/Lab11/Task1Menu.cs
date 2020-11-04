using System;
using Dialog;

namespace Lab11
{
    class Task1Menu : IWaiter
    {
        private const string c_Menu =
            "Меню Queue\n" +
            "1. Сгенерировать коллекцию\n" +
            "2. Считать коллекцию с резерва\n" +
            "3. Клонировать коллекцию в резерв\n" +
            "4. Добавление в конец\n" +
            "5. Удаление с начала\n" +
            "6. Выполнение запросов\n" +
            "7. Вывод через Foreach\n" +
            "8. Сортировка коллекции\n" +
            "9. Бинарный поиск в коллекции\n" +
            "0. Назад\n" +
            "Выберете действие: ";
        private static readonly Exception UnknownError
            = new Exception("Неизвестная ошибка");

        private static Task1Menu s_Instance = null;

        public static Task1Menu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new Task1Menu();
                return s_Instance;
            }
        }

        public string Menu { get; }
        public MyList<Task> Tasks { get; }
        public MyList<Exception> Reactions { get; }

        private Task1Menu()
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
