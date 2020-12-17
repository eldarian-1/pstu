using Dialog;
using Entity;
using System;
using Collection.BiList;
using System.Collections.Generic;

namespace Lab12.Menu
{
    class BiListMenu : IMenu
    {
        private static IMenu s_Instance;
        private static Exception s_NullList = new Exception("Список не создан");

        private const int c_MaxCount = 10000;
        private const string c_EnterCount = "Введите количество элементов: ";
        private const string c_BuildList = "Список из {0} элементов построен.";
        private const string c_RemovedEven = "Четные элементы удалены.";
        private const string c_RemovedList = "Список удален.";

        private IList<Action> m_Tasks;
        private IList<Exception> m_Reactions;
        private IList<int> m_List;

        public static IMenu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new BiListMenu();
                return s_Instance;
            }
        }

        private BiListMenu()
        {
            m_Tasks = new List<Action>().Add(
                ConstructList,
                PrintList,
                RemoveEvenNumber,
                RemoveList);
            m_Reactions = new List<Exception>().Add(s_NullList, null);
        }

        public string Menu =>
            "Меню двусвзного списка\n" +
            "1. Сформировать список\n" +
            "2. Распечатать список\n" +
            "3. Удалить четные номера\n" +
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

        public void ConstructList()
        {
            m_List = new BiList<int>();
            Input.ReadNum(out int count, c_EnterCount, i => i >= 0 && i <= c_MaxCount);
            int[] array = EngineFacade.Instance.GenerateInt(count);
            foreach (int item in array)
                m_List.Add(item);
            MenuManager.Write(string.Format(c_BuildList, count));
        }

        public void PrintList()
        {
            CheckList();
            MenuManager.Write(m_List.ToString());
        }

        public void RemoveEvenNumber()
        {
            CheckList();
            for (int i = 0, j = 0; j < m_List.Count; ++i, ++j)
                if (i % 2 == 1)
                    m_List.RemoveAt(j--);
            MenuManager.Write(c_RemovedEven);
        }

        public void RemoveList()
        {
            CheckList();
            m_List = null;
            MenuManager.Write(c_RemovedList);
        }
    }
}
