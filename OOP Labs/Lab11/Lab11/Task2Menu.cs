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
            ByPower
        }

        private delegate void Sort(System.Collections.Generic.KeyValuePair<string, IEngine>[] engines);

        private static Task2Menu s_Instance = null;

        private const string c_Menu =
            "Меню Dictionary\n" +
            "1. Сгенерировать словарь\n" +
            "2. Поменять местами основной словарь с резервным\n" +
            "3. Клонировать словарь в резерв\n" +
            "4. Добавление с автогенерацией псевдонима\n" +
            "5. Добавление с заданием псевдонима\n" +
            "6. Удаление по псевдониму\n" +
            "7. Выполнение запросов\n" +
            "8. Вывод через Foreach\n" +
            "9. Сортировка по индексам двигателей\n" +
            "10. Сортировка по мощности двигателей\n" +
            "11. Сортировка по псевдонимам двигателей\n" +
            "12. Бинарный поиск по индексу\n" +
            "13. Бинарный поиск первого двигателя с указанной мощностью\n" +
            "14. Поиск по псевдониму\n" +
            "0. Назад\n" +
            "Выберете действие: ";
        private const string c_EnterIndex = "Введите индекс: ";
        private const string c_EnterPower = "Введите мощность: ";
        private const string c_EnterPseudonym = "Введите псевдоним: ";
        private const string c_FoundEngine = "Искомый двигатель[{0}]: {1}";
        private const string c_NotFoundEngine = "Двигатель не найден";

        private static readonly Exception UngeneratedCollection = new Exception("Коллекция не сгенерирована");
        private static readonly Exception EmptyCollection = new Exception("Коллекция пуста");
        private static readonly Exception UnsortedByIndexCollection = new Exception("Коллекция не отсортирована по индексам двигателей");
        private static readonly Exception UnsortedByPowerCollection = new Exception("Коллекция не отсортирована по мощностям двигателей");
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
                PushGenerated,
                PushEntered,
                Remove,
                ExecuteQuery,
                OutputForeach,
                SortingByIndex,
                SortingByPower,
                SortingByPseudonym,
                BinarySearchByIndex,
                BinarySearchByPower,
                SearchByPseudonym);
            Reactions = new MyList<Exception>(
                UngeneratedCollection,
                EmptyCollection,
                UnsortedByIndexCollection,
                UnsortedByPowerCollection,
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

        private void PushGenerated()
        {
            m_Main.Add(EngineFacade.Instance.GeneratePseudonym(), EngineFacade.Instance.Generate());
            m_MainIsSorted = IsSorted.None;
        }

        private void PushEntered()
        {
            Input.ReadWord(out string pseudonym, c_EnterPseudonym);
            Console.WriteLine();
            m_Main.Add(pseudonym, EngineFacade.Instance.Generate());
            m_MainIsSorted = IsSorted.None;
        }

        private void Remove()
        {
            CheckCollection();
            Input.ReadWord(out string pseudonym, c_EnterPseudonym);
            if(!m_Main.Keys.Contains(pseudonym))
                throw NotFoundPseudonym;
            m_Main.Remove(pseudonym);
        }

        private void ExecuteQuery()
        {
            CheckCollection();
            TaskRunner.Instance.Run(new QueryMenu<Dictionary<string, IEngine>>(m_Main.Values.ToArray()));
        }

        private void OutputForeach()
        {
            CheckCollection();
            string text = "";
            int i = 0, n = m_Main.Count;
            foreach (var engine in m_Main)
                text += $"{engine.Value.Name}-{engine.Key} [{engine.Value.Power} HP]" + (i++ != n - 1 ? "\n" : "");
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

        private void SortingByPower()
        {
            Sorting(EngineFacade.Instance.SortingByPower);
            m_MainIsSorted = IsSorted.ByPower;
        }

        private void SortingByPseudonym()
        {
            Sorting(EngineFacade.Instance.SortingByPseudonym);
            m_MainIsSorted = IsSorted.None;
        }

        private void BinarySearchResult(string pseudonum)
        {
            string result;
            if (pseudonum != "")
                result = string.Format(c_FoundEngine, pseudonum, $"{m_Main[pseudonum].Name}-{pseudonum} [{m_Main[pseudonum].Power} HP]");
            else
                result = c_NotFoundEngine;
            TaskRunner.Write(result);
        }

        private void BinarySearchByIndex()
        {
            CheckCollection();
            if (m_MainIsSorted != IsSorted.ByIndex)
                throw UnsortedByIndexCollection;
            Input.ReadNum(out int index, c_EnterIndex);
            int i = EngineFacade.Instance.FindByIndex(m_Main.Values.ToArray(), index);
            string pseudonum = m_Main.Keys.ToArray()[i];
            BinarySearchResult(pseudonum);
        }

        private void BinarySearchByPower()
        {
            CheckCollection();
            if (m_MainIsSorted != IsSorted.ByPower)
                throw UnsortedByPowerCollection;
            Input.ReadNum(out int power, c_EnterPower);
            int i = EngineFacade.Instance.FindByPower(m_Main.Values.ToArray(), power);
            string pseudonum = m_Main.Keys.ToArray()[i];
            BinarySearchResult(pseudonum);
        }

        private void SearchByPseudonym()
        {
            CheckCollection();
            Input.ReadWord(out string pseudonym, c_EnterPseudonym);
            string pseudonum = EngineFacade.Instance.FindByPseudonym(m_Main.Keys.ToArray(), pseudonym);
            BinarySearchResult(pseudonum);
        }
    }
}
