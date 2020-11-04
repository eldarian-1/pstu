using System;
using Dialog;
using Entity;
using Collection;
using System.Linq;

namespace Lab11
{
    class Task1Menu : IWaiter
    {
        private static Task1Menu s_Instance = null;

        private const string c_Menu =
            "Меню Queue\n" +
            "1. Сгенерировать коллекцию\n" +
            "2. Поменять местами основную коллекцию с резервной\n" +
            "3. Клонировать коллекцию в резерв\n" +
            "4. Добавление в конец\n" +
            "5. Удаление с начала\n" +
            "6. Выполнение запросов\n" +
            "7. Вывод через Foreach\n" +
            "8. Сортировка коллекции\n" +
            "9. Бинарный поиск в коллекции\n" +
            "0. Назад\n" +
            "Выберете действие: ";

        private static readonly Exception UngeneratedCollection = new Exception("Коллекция не сгенерирована");
        private static readonly Exception EmptyCollection = new Exception("Коллекция пуста");
        private static readonly Exception UnsortedCollection = new Exception("Коллекция не отсортирована");

        private Queue<IEngine> m_Main;
        private Queue<IEngine> m_Reserv;

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
            Tasks = new MyList<Task>(
                Generate,
                SwapReserv,
                CloneToReserv,
                PushBack,
                PopFront,
                ExecuteQuery,
                OutputForeach,
                Sorting,
                BinarySearch);
            Reactions = new MyList<Exception>(
                UngeneratedCollection,
                EmptyCollection,
                UnsortedCollection);
        }

        private void CheckCollection()
        {
            if (m_Main == null || m_Main.Count() == 0)
                throw EmptyCollection;
        }

        private void Generate()
        {
            m_Main = new Queue<IEngine>();
            IEngine[] engines = EngineFacade.Instance.GenerateArray();
            foreach (IEngine engine in engines)
                m_Main.Add(engine);
        }

        private void SwapReserv()
        {
            Queue<IEngine> temp = m_Main;
            m_Main = m_Reserv;
            m_Reserv = temp;
        }

        private void CloneToReserv()
        {
            m_Reserv = m_Main.Clone() as Queue<IEngine>;
        }

        private void PushBack()
        {
            m_Main.Add(EngineFacade.Instance.Generate());
        }

        private void PopFront()
        {
            CheckCollection();
            m_Main.PopFront();
        }

        private void ExecuteQuery()
        {
            CheckCollection();
            TaskRunner.Instance.Run(new QueryMenu<Queue<IEngine>>(m_Main));
        }

        private void OutputForeach()
        {
            CheckCollection();
            string text = "";
            int i = 0, n = m_Main.Count;
            foreach (IEngine engine in m_Main)
                text += engine.Name + (i++ != n - 1 ? "\n" : "");
            TaskRunner.Write(text);
        }

        private void Sorting()
        {
            CheckCollection();
            IEngine[] engines = m_Main.ToArray();
            Array.Sort(engines);
            m_Main = new Queue<IEngine>();
            foreach (IEngine engine in engines)
                m_Main.Add(engine);
        }

        private void BinarySearch()
        {
            CheckCollection();
        }
    }
}
