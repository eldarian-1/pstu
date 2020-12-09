using Dialog;
using System;
using Lab12.Additionally;

namespace Lab12.Menu
{
    class StackConstructMenu : IMenu
    {
        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private StackAgregator<int> m_Stack;

        private const int c_Limit = 30;
        private const string c_EnterCount = "Введите количество элементов: ";

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
            int count;
            do Input.ReadNum(out count, c_EnterCount);
            while (count < 0 || count >= c_Limit);
            m_Stack.ConstructByCount(count);
        }

        public void CopyConstruct()
        {
            m_Stack.CopyConstruct(new StackAgregator<int>());
        }
    }
}
