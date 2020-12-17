using Dialog;
using System;
using Entity;
using Collection.UniList;
using System.Collections.Generic;

namespace Lab12.Menu
{
    class UniListMenu : IMenu
    {
        private static IMenu s_Instance;
        private static Exception s_NullList = new Exception("Список не создан");

        private const int c_MaxCount = 10000;
        private const string c_EnterCount = "Введите количество элементов: ";
        private const string c_BuildList = "Список из {0} элементов построен.";
        private const string c_ZeroAdded = "Нули после отрицательных добавлены.";
        private const string c_RemovedList = "Список удален.";

        private IList<Action> m_Tasks;
        private IList<Exception> m_Reactions;
        private IList<double> m_List;

        public static IMenu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new UniListMenu();
                return s_Instance;
            }
        }

        private UniListMenu()
        {
            m_Tasks = new List<Action>().Append(
                ConstructList,
                PrintList,
                AddZeroAfterNegative,
                RemoveList);
            m_Reactions = new List<Exception>().Append(s_NullList);
        }

        public string Menu =>
            "Меню односвзного списка\n" +
            "1. Сформировать список\n" +
            "2. Распечатать список\n" +
            "3. Добавить ноль после каждого отрицательного\n" +
            "4. Удалить список\n" +
            "0. Выход\n" +
            "Введите номер задачи: ";

        public IList<Action> Tasks => m_Tasks;

        public IList<Exception> Reactions => m_Reactions;

        private void CheckList()
        {
            if (m_List == null)
                throw s_NullList;
        }

        private void ConstructList()
        {
            m_List = new UniList<double>();
            Input.ReadNum(out int count, c_EnterCount, i => i >= 0 && i <= c_MaxCount);
            double[] array = EngineFacade.Instance.GenerateDouble(count);
            foreach (double item in array)
                m_List.Add(item);
            MenuManager.Write(string.Format(c_BuildList, count));
        }

        private void PrintList()
        {
            CheckList();
            MenuManager.Write(m_List.ToString());
        }

        private void AddZeroAfterNegative()
        {
            CheckList();
            for (int i = 0; i < m_List.Count; ++i)
                if (m_List[i] < 0)
                    m_List.Insert(++i, 0);
            MenuManager.Write(c_ZeroAdded);
        }

        private void RemoveList()
        {
            CheckList();
            m_List = null;
            MenuManager.Write(c_RemovedList);
        }
    }
}
