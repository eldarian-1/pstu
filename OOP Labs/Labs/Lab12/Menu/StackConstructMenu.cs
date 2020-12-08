using Dialog;
using System;
using Lab12.Agregator;

namespace Lab12.Menu
{
    class StackConstructMenu : IMenu
    {
        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private StackAgregator<int> m_Stack;

        public StackConstructMenu(StackAgregator<int> stack)
        {
            m_Stack = stack;
            m_Tasks = new MyList<Action>(EmptyConstruct, ConstructByCount, CopyConstruct);
            m_Reactions = new MyList<Exception>();
        }

        public string Menu =>
            "Меню формирования стека\n" +
            "1. Сформировать пустой стек\n" +
            "2. Сформировать стек с заданным количеством элементов\n" +
            "3. Скопировать стек с уже имеющегося\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        public void EmptyConstruct()
        {
            m_Stack.EmptyConstruct();
        }

        public void ConstructByCount()
        {
            m_Stack.ConstructByCount(13);
        }

        public void CopyConstruct()
        {
            m_Stack.CopyConstruct(new StackAgregator<int>());
        }

    }
}
