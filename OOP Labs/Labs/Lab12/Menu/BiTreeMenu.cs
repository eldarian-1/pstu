using Dialog;
using System;
using Entity;
using Lab12.Additionally;
using System.Collections.Generic;

namespace Lab12.Menu
{
    class BiTreeMenu : IMenu
    {
        private static IMenu s_Instance;
        private static Exception s_NullTree = new Exception("Дерево не создано");

        private const int c_MaxCount = 10000;
        private const string c_EnterCount = "Введите количество узлов: ";
        private const string c_EnterSymbol = "Введите символ: ";
        private const string c_CountOnSymbol = "Число начинающихся на \"{0}\": {1}";
        private const string c_BuildTree = "Дерево из {0} элементов построено.";
        private const string c_RemovedTree = "Дерево удалено.";

        private IList<Action> m_Tasks;
        private IList<Exception> m_Reactions;
        private TreeAgregator m_Tree;

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
            m_Tree = new TreeAgregator();
            m_Tasks = new List<Action>().Append(
                ConstructTree,
                PrintTree,
                PrintTreeLine,
                TransformToBalanceTree,
                TransformToSearchTree,
                CountStartedOnSymbol,
                RemoveTree);
            m_Reactions = new List<Exception>().Append(s_NullTree);
        }

        public string Menu =>
            "Меню бинарного дерева\n" +
            "1. Сформировать бинарное дерево\n" +
            "2. Распечатать бинарное дерево\n" +
            "3. Распечатать элементы в строку\n" +
            "4. Преобразовать в сбалансированное дерево\n" +
            "5. Преобразовать в берево поиска\n" +
            "6. Сосчитать начинающиеся на заданный символ\n" +
            "7. Удалить бинарное дерево\n" +
            "0. Выход\n" +
            "Введите номер задачи: ";

        public IList<Action> Tasks => m_Tasks;

        public IList<Exception> Reactions => m_Reactions;

        private void CheckTree()
        {
            if (m_Tree.Empty)
                throw s_NullTree;
        }

        private void ConstructTree()
        {
            Input.ReadNum(out int count, c_EnterCount, i => i >= 0 && i <= c_MaxCount);
            string[] array = EngineFacade.Instance.GeneratePseudonymArray(count);
            m_Tree.Formation(array);
            MenuManager.Write(string.Format(c_BuildTree, count));
        }

        private void PrintTree()
        {
            CheckTree();
            MenuManager.Write(m_Tree.ToString());
        }

        private void PrintTreeLine()
        {
            CheckTree();
            string tree = "";
            foreach (var item in m_Tree)
                tree += item + " ";
            MenuManager.Write(tree);
        }

        private void TransformToBalanceTree()
        {
            CheckTree();
            m_Tree.ToBalance();
            PrintTree();
        }

        private void TransformToSearchTree()
        {
            CheckTree();
            m_Tree.ToSearch();
            MenuManager.Write("Действие не разработано.");
        }

        private void CountStartedOnSymbol()
        {
            CheckTree();
            Input.ReadSymbol(out char symbol, c_EnterSymbol);
            int count = m_Tree.CountOnChar(symbol);
            string result = string.Format(c_CountOnSymbol, symbol, count);
            MenuManager.Write(result);
        }

        private void RemoveTree()
        {
            CheckTree();
            m_Tree.Remove();
            MenuManager.Write(c_RemovedTree);
        }
    }
}
