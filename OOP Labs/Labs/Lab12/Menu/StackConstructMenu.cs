using Dialog;
using System;
using Lab12.Additionally;
using System.Collections.Generic;

namespace Lab12.Menu
{
    class StackConstructMenu : IMenu
    {
        private static Exception s_NullStack = new Exception("Стек не создан");
        private static Exception s_ThisStack = new Exception("Выбран этот же стек");

        private const int c_MaxCount = 10000;
        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private IDictionary<string, StackAgregator<int>> m_Stacks;
        private string m_ActiveKey;

        private const int c_Limit = 100000;
        private const string c_EnterCount = "Введите количество элементов: ";

        public StackConstructMenu(IDictionary<string, StackAgregator<int>> stacks, string activeKey)
        {
            m_Stacks = stacks;
            m_ActiveKey = activeKey;
            m_Tasks = new MyList<Action>(
                EmptyConstruct,
                ConstructByCount,
                CopyConstruct,
                OutputStack);
            m_Reactions = new MyList<Exception>(
                s_NullStack,
                s_ThisStack);
        }

        public string Menu =>
            "Меню формирования стека " + m_ActiveKey + "\n" +
            "1. Сформировать пустой стек\n" +
            "2. Сформировать стек с заданным количеством элементов\n" +
            "3. Скопировать стек с уже имеющегося\n" +
            "4. Распечатать стек\n" +
            "0. Выход\n" +
            "Введите номер задачи: ";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private void CheckStack(string name)
        {
            if (!m_Stacks.ContainsKey(name) || m_Stacks[name].Empty)
                throw s_NullStack;
        }

        public void EmptyConstruct()
        {
            m_Stacks[m_ActiveKey].EmptyConstruct();
            OutputStack();
        }

        public void ConstructByCount()
        {
            int count;
            do Input.ReadNum(out count, c_EnterCount, i => i >= 0 && i <= c_MaxCount);
            while (count < 0 || count >= c_Limit);
            m_Stacks[m_ActiveKey].ConstructByCount(count);
            OutputStack();
        }

        public void CopyConstruct()
        {
            string stack = StackMenu.ChoiseLink(m_Stacks);
            if (stack == m_ActiveKey)
                throw s_ThisStack;
            CheckStack(stack);
            m_Stacks[m_ActiveKey].CopyConstruct(m_Stacks[stack]);
            OutputStack();
        }

        private void OutputStack()
        {
            CheckStack(m_ActiveKey);
            MenuManager.Write(m_Stacks[m_ActiveKey].ToString());
        }
    }
}
