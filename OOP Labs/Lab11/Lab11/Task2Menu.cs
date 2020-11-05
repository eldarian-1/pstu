using System;
using Dialog;
using Entity;
using Collection;
using System.Linq;

namespace Lab11
{
    class Task2Menu : IWaiter
    {
        private enum IsSorted : byte
        {
            None,
            ByIndex,
            ByPseudonym
        }

        private delegate void Sort(System.Collections.Generic.KeyValuePair<string, IEngine>[] engines);

        private static Task2Menu s_Instance = null;

        private const string c_Menu =
            "Меню Dictionary\n" +
            "1. Сгенерировать коллекцию\n" +
            "2. Поменять местами основную коллекцию с резервной\n" +
            "3. Клонировать коллекцию в резерв\n" +
            "4. Добавление в конец\n" +
            "5. Удаление по псевдониму\n" +
            "6. Выполнение запросов\n" +
            "7. Вывод через Foreach\n" +
            "8. Сортировка коллекции по индексам двигателей\n" +
            "9. Сортировка коллекции по мощности двигателей\n" +
            "10. Бинарный поиск в коллекции по индексу\n" +
            "11. Бинарный поиск в коллекции по мощности\n" +
            "0. Назад\n" +
            "Выберете действие: ";
        private const string c_FindByIndex = "Введите индекс: ";
        private const string c_FindByPseudonym = "Введите псевдоним: ";
        private const string c_FoundEngine = "Искомый двигатель[{0}]: {1}";
        private const string c_NotFoundEngine = "Двигатель не найден";

        private static readonly Exception UngeneratedCollection = new Exception("Коллекция не сгенерирована");
        private static readonly Exception EmptyCollection = new Exception("Коллекция пуста");
        private static readonly Exception UnsortedByIndexCollection = new Exception("Коллекция не отсортирована по индексам двигателей");
        private static readonly Exception UnsortedByPseudonymCollection = new Exception("Коллекция не отсортирована по псевдомимам двигателей");
        private static readonly Exception NotFoundPseudonym = new Exception("Псевдоним не найден");

        private Dictionary<string, IEngine> m_Main;
        private Dictionary<string, IEngine> m_Reserv;
        private IsSorted m_MainIsSorted;
        private IsSorted m_ReservIsSorted;

        public static Task2Menu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new Task2Menu();
                return s_Instance;
            }
        }

        public string Menu { get; }
        public MyList<Task> Tasks { get; }
        public MyList<Exception> Reactions { get; }

        private Task2Menu()
        {
            Menu = c_Menu;
            Tasks = new MyList<Task>(
                Generate,
                SwapReserv,
                CloneToReserv,
                PushBack,
                Remove,
                ExecuteQuery,
                OutputForeach,
                SortingByIndex,
                SortingByPseudonym,
                BinarySearchByIndex,
                BinarySearchByPseudonym);
            Reactions = new MyList<Exception>(
                UngeneratedCollection,
                EmptyCollection,
                UnsortedByIndexCollection,
                UnsortedByPseudonymCollection,
                NotFoundPseudonym);
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
            m_Main = new Dictionary<string, IEngine>();
            IEngine[] engines = EngineFacade.Instance.GenerateArray();
            int n = engines.Length;
            string[] pseudonyms = EngineFacade.Instance.GeneratePseudonymArray(n);
            for(int i = 0; i < n; ++i)
                m_Main.Add(pseudonyms[i], engines[i]);
            m_MainIsSorted = IsSorted.None;
        }

        private void SwapReserv()
        {
            Dictionary<string, IEngine> tQueue = m_Main;
            m_Main = m_Reserv;
            m_Reserv = tQueue;
            IsSorted tIsSorted = m_MainIsSorted;
            m_MainIsSorted = m_ReservIsSorted;
            m_ReservIsSorted = tIsSorted;
        }

        private void CloneToReserv()
        {
            m_Reserv = m_Main.Clone() as Dictionary<string, IEngine>;
        }

        private void PushBack()
        {
            m_Main.Add(EngineFacade.Instance.GeneratePseudonym(), EngineFacade.Instance.Generate());
            m_MainIsSorted = IsSorted.None;
        }

        private void Remove()
        {
            CheckCollection();
            Input.ReadWord(out string pseudonym, c_FindByPseudonym);
            if(!m_Main.Keys.Contains(pseudonym))
                throw NotFoundPseudonym;
            m_Main.Remove(pseudonym);
        }

        private void ExecuteQuery()
        {
            CheckCollection();
            TaskRunner.Instance.Run(new QueryMenu<Queue<IEngine>>(m_Main.Values.ToArray()));
        }

        private void OutputForeach()
        {
            CheckCollection();
            string text = "";
            int i = 0, n = m_Main.Count;
            foreach (var engine in m_Main)
                text += engine.Value.Name + "-" + engine.Key + (i++ != n - 1 ? "\n" : "");
            TaskRunner.Write(text);
        }

        private void Sorting(Sort sorting)
        {
            CheckCollection();
            var engines = m_Main.ToArray();
            sorting(engines);
            m_Main = new Dictionary<string, IEngine>();
            foreach (var engine in engines)
                m_Main.Add(engine);
        }

        private void SortingByIndex()
        {
            Sorting(EngineFacade.Instance.SortingByIndex);
            m_MainIsSorted = IsSorted.ByIndex;
        }

        private void SortingByPseudonym()
        {
            Sorting(EngineFacade.Instance.SortingByPseudonym);
            m_MainIsSorted = IsSorted.ByPseudonym;
        }

        private void BinarySearchResult(string pseudonum)
        {
            string result;
            if (pseudonum != "")
                result = string.Format(c_FoundEngine, pseudonum, m_Main[pseudonum].Name + "-" + pseudonum);
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
            int i = EngineFacade.Instance.FindByIndex(m_Main.Values.ToArray(), index);
            string pseudonum = m_Main.Keys.ToArray()[i];
            BinarySearchResult(pseudonum);
        }

        private void BinarySearchByPseudonym()
        {
            CheckCollection();
            if (m_MainIsSorted != IsSorted.ByPseudonym)
                throw UnsortedByPseudonymCollection;
            Input.ReadWord(out string pseudonym, c_FindByPseudonym);
            string pseudonum = EngineFacade.Instance.FindByPseudonym(m_Main.Keys.ToArray(), pseudonym);
            BinarySearchResult(pseudonum);
        }
    }
}
