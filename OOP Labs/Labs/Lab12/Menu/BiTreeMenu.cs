using Dialog;
using System;

namespace Lab12.Menu
{
    class BiTreeMenu : IMenu
    {
        private static IMenu s_Instance;

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;

        public static IMenu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new BiTreeMenu();
                return s_Instance;
            }
        }

        private BiTreeMenu()
        {
            m_Tasks = new MyList<Action>(
                ConstructTree,
                PrintTree,
                CountStartedOnSymbol,
                TransformToSearchTree,
                RemoveTree);
            m_Reactions = new MyList<Exception>();
        }

        public string Menu =>
            "Меню бинарного дерева\n" +
            "1. Сформировать идеально сбалансированное дерево\n" +
            "2. Распечатать бинарное дерево\n" +
            "3. Сосчитать начинающиеся на заданный символ\n" +
            "4. Преобразовать в берево поиска\n" +
            "5. Удалить бинарное дерево\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        public void ConstructTree()
        {

        }

        public void PrintTree()
        {

        }

        public void CountStartedOnSymbol()
        {

        }

        public void TransformToSearchTree()
        {

        }

        public void RemoveTree()
        {

        }

    }
}
