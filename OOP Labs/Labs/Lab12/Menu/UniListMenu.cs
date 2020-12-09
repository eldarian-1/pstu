using Dialog;
using System;
using Collection.UniList;
using System.Collections.Generic;

namespace Lab12.Menu
{
    class UniListMenu : IMenu
    {
        private static IMenu s_Instance;

        private static Exception s_NullList = new Exception("Список не создан");

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
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
            m_Tasks = new MyList<Action>(
                ConstructList,
                PrintList,
                AddZeroAfterNegative,
                RemoveList);
            m_Reactions = new MyList<Exception>(s_NullList);
        }

        public string Menu =>
            "Меню односвзного списка\n" +
            "1. Сформировать список\n" +
            "2. Распечатать список\n" +
            "3. Добавить ноль после каждого отрицательного\n" +
            "4. Удалить список\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private void CheckList()
        {
            if (m_List == null)
                throw s_NullList;
        }

        private void ConstructList()
        {
            m_List = new UniList<double>();
        }

        private void PrintList()
        {
            CheckList();
            Waiter.Write(m_List.ToString());
        }

        private void AddZeroAfterNegative()
        {
            CheckList();
            for (int i = 0; i < m_List.Count; ++i)
                if (m_List[i] < 0)
                    m_List.Insert(++i, 0);
        }

        private void RemoveList()
        {
            CheckList();
            m_List = null;
        }
    }
}
