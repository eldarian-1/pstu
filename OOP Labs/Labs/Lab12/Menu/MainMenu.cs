using Dialog;
using System;
using System.Collections.Generic;

namespace Lab12.Menu
{
    public class MainMenu : IMenu
    {
        private IList<Action> m_Tasks;
        private IList<Exception> m_Reactions;

        public MainMenu()
        {
            m_Tasks = new List<Action>().Add(UniList, BiList, BiTree, Stack);
            m_Reactions = new List<Exception>();
        }

        public string Menu =>
            "Главное меню\n" +
            "1. Односвязный список\n" +
            "2. Двусвязный список\n" +
            "3. Бинарное дерево\n" +
            "4. Стек на основе односвязного списка\n" +
            "0. Выход\n" +
            "Введите номер задачи: ";

        public IList<Action> Tasks => m_Tasks;

        public IList<Exception> Reactions => m_Reactions;

        private void UniList()
        {
            MenuManager.Instance.Run(UniListMenu.Instance);
        }

        private void BiList()
        {
            MenuManager.Instance.Run(BiListMenu.Instance);
        }

        private void BiTree()
        {
            MenuManager.Instance.Run(BiTreeMenu.Instance);
        }

        private void Stack()
        {
            MenuManager.Instance.Run(StackMenu.Instance);
        }

    }
}
