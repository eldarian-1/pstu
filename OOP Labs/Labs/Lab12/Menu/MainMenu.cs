using Dialog;
using System;

namespace Lab12.Menu
{
    public class MainMenu : IMenu
    {
        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;

        public MainMenu()
        {
            m_Tasks = new MyList<Action>(UniList, BiList, BiTree, Stack);
            m_Reactions = new MyList<Exception>();
        }

        public string Menu =>
            "Главное меню\n" +
            "1. Односвязный список\n" +
            "2. Двусвязный список\n" +
            "3. Бинарное дерево\n" +
            "4. Стек на основе односвязного списка\n" +
            "0. Выход\n" +
            "Введите номер задачи: ";

        public MyList<Action> Tasks => m_Tasks;
        public MyList<Exception> Reactions => m_Reactions;

        private void UniList()
        {
            Waiter.Instance.Run(UniListMenu.Instance);
        }

        private void BiList()
        {
            Waiter.Instance.Run(BiListMenu.Instance);
        }

        private void BiTree()
        {
            Waiter.Instance.Run(BiTreeMenu.Instance);
        }

        private void Stack()
        {
            Waiter.Instance.Run(StackMenu.Instance);
        }

    }
}
