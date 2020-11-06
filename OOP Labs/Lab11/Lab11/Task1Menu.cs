using System;
using Dialog;
using Entity;
using Collection;
using System.Linq;

namespace Lab11
{
    class Task1Menu : IWaiter
    {
        private enum IsSorted : byte
        {
            None,
            ByIndex,
            ByPower
        }

        private delegate void Sort(IEngine[] engines);

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
            "8. Сортировка коллекции по индексам двигателей\n" +
            "9. Сортировка коллекции по мощности двигателей\n" +
            "10. Бинарный поиск в коллекции по индексу\n" +
            "11. Бинарный поиск в коллекции по мощности\n" +
            "0. Назад\n" +
            "Выберете действие: ";
        private const string c_FindByIndex = "Введите индекс: ";
        private const string c_FindByPower = "Введите мощность: ";
        private const string c_FoundEngine = "Искомый двигатель[{0}]: {1}";
        private const string c_NotFoundEngine = "Двигатель не найден";

        private static readonly Exception UngeneratedCollection = new Exception("Коллекция не сгенерирована");
        private static readonly Exception EmptyCollection = new Exception("Коллекция пуста");
        private static readonly Exception UnsortedByIndexCollection = new Exception("Коллекция не отсортирована по индексам двигателей");
        private static readonly Exception UnsortedByPowerCollection = new Exception("Коллекция не отсортирована по мощностям двигателей");

        private Queue<IEngine> m_Main;
        private Queue<IEngine> m_Reserv;
        private IsSorted m_MainIsSorted;
        private IsSorted m_ReservIsSorted;

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
                SortingByIndex,
                SortingByPower,
                BinarySearchByIndex,
                BinarySearchByPower);
            Reactions = new MyList<Exception>(
                UngeneratedCollection,
                EmptyCollection,
                UnsortedByIndexCollection,
                UnsortedByPowerCollection);
            m_MainIsSorted = IsSorted.None;
            m_ReservIsSorted = IsSorted.None;
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
            m_MainIsSorted = IsSorted.None;
        }

        private void SwapReserv()
        {
            Queue<IEngine> tQueue = m_Main;
            m_Main = m_Reserv;
            m_Reserv = tQueue;
            IsSorted tIsSorted = m_MainIsSorted;
            m_MainIsSorted = m_ReservIsSorted;
            m_ReservIsSorted = tIsSorted;
        }

        private void CloneToReserv()
        {
            m_Reserv = m_Main.Clone() as Queue<IEngine>;
        }

        private void PushBack()
        {
            m_Main.Add(EngineFacade.Instance.Generate());
            m_MainIsSorted = IsSorted.None;
        }

        private void PopFront()
        {
            CheckCollection();
            m_Main.PopFront();
        }

        private void ExecuteQuery()
        {
            CheckCollection();
            TaskRunner.Instance.Run(new QueryMenu<Queue<IEngine>>(m_Main.ToArray()));
        }

        private void OutputForeach()
        {
            CheckCollection();
            string text = "";
            int i = 0, n = m_Main.Count;
            foreach (IEngine engine in m_Main)
                text += $"{engine.Name} [{engine.Power} HP]" + (i++ != n - 1 ? "\n" : "");
            TaskRunner.Write(text);
        }

        private void Sorting(Sort sorting)
        {
            CheckCollection();
            IEngine[] engines = m_Main.ToArray();
            sorting(engines);
            m_Main = new Queue<IEngine>();
            foreach (IEngine engine in engines)
                m_Main.Add(engine);
        }

        private void SortingByIndex()
        {
            Sorting(EngineFacade.Instance.SortingByIndex);
            m_MainIsSorted = IsSorted.ByIndex;
        }

        private void SortingByPower()
        {
            Sorting(EngineFacade.Instance.SortingByPower);
            m_MainIsSorted = IsSorted.ByPower;
        }

        private void BinarySearchResult(int index)
        {
            string result;
            if (index != -1)
                result = string.Format(c_FoundEngine, index, $"{m_Main[index].Name} [{m_Main[index].Power} HP]");
            else
                result = c_NotFoundEngine;
            TaskRunner.Write(result);
        }

        private void BinarySearchByIndex()
        {
            CheckCollection();
            if (m_MainIsSorted != IsSorted.ByIndex)
                throw UnsortedByIndexCollection;
            Input.ReadNum(out int index, c_FindByIndex);
            int i = EngineFacade.Instance.FindByIndex(m_Main.ToArray(), index);
            BinarySearchResult(i);
        }

        private void BinarySearchByPower()
        {
            CheckCollection();
            if (m_MainIsSorted != IsSorted.ByPower)
                throw UnsortedByPowerCollection;
            Input.ReadNum(out int power, c_FindByPower);
            int i = EngineFacade.Instance.FindByPower(m_Main.ToArray(), power);
            BinarySearchResult(i);
        }
    }
}
