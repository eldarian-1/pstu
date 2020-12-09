using Dialog;
using System;
using Lab12.Additionally;

namespace Lab12.Menu
{
    class BiTreeMenu : IMenu
    {
        private static IMenu s_Instance;
        private static Exception s_NullTree = new Exception("Дерево не создано");

        private const string c_EnterSymbol = "Введите символ: ";

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private BiTree m_Tree;

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

        private void CheckTree()
        {
            if (m_Tree == null)
                throw s_NullTree;
        }

        public void ConstructTree()
        {
            m_Tree = new BiTree();
        }

        public void PrintTree()
        {
            CheckTree();
            Waiter.Write(m_Tree.ToString());
        }

        public void CountStartedOnSymbol()
        {
            CheckTree();
            Input.ReadSymbol(out char symbol, c_EnterSymbol);
            Waiter.Write(m_Tree.CountOnChar(symbol).ToString());
        }

        public void TransformToSearchTree()
        {
            CheckTree();
        }

        public void RemoveTree()
        {
            CheckTree();
            m_Tree = null;
        }
    }
}
