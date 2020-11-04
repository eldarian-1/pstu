using Dialog;
using System;
using Entity;

namespace Lab11
{
    public class QueryMenu<TCollection> : IWaiter
    {
        private static string c_Menu =
            "Меню запросов " + typeof(TCollection).Name + "\n" +
            "1. Запрос 1\n" +
            "2. Запрос 2\n" +
            "3. Запрос 3\n" +
            "0. Назад\n" +
            "Выберете действие: ";
        private static readonly Exception UnknownError
            = new Exception("Неизвестная ошибка");

        private IEngine[] m_Engines;

        public string Menu { get; }
        public MyList<Task> Tasks { get; }
        public MyList<Exception> Reactions { get; }

        public QueryMenu(IEngine[] engines)
        {
            m_Engines = engines;
            Menu = c_Menu;
            Tasks = new MyList<Task>(Query1, Query2, Query3);
            Reactions = new MyList<Exception>(UnknownError);
        }

        private void Query1()
        {
            TaskRunner.Write(EngineFacade.Instance.RunQuery1(m_Engines));
        }

        private void Query2()
        {
            TaskRunner.Write(EngineFacade.Instance.RunQuery2(m_Engines));
        }

        private void Query3()
        {
            TaskRunner.Write(EngineFacade.Instance.RunQuery3(m_Engines));
        }
    }
}
