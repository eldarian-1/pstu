using Dialog;
using System;

namespace Lab12.Menu
{
    class UniListMenu : IMenu
    {
        private static IMenu s_Instance;

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;

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
            m_Reactions = new MyList<Exception>();
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

        public void ConstructList()
        {

        }

        public void PrintList()
        {

        }

        public void AddZeroAfterNegative()
        {

        }

        public void RemoveList()
        {

        }

    }
}
