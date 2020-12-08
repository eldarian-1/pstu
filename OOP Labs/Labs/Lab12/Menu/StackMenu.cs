using Dialog;
using System;
using Lab12.Agregator;
using System.Collections.Generic;

namespace Lab12.Menu
{
    class StackMenu : IMenu
    {
        private static IMenu s_Instance;

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private IDictionary<string, StackAgregator<int>> m_Stacks;
        private StackAgregator<int> m_ActiveStack;

        public static IMenu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new StackMenu();
                return s_Instance;
            }
        }

        private StackMenu()
        {
            m_Tasks = new MyList<Action>(
                CreateLink,
                ChoiceLink,
                ConstructStack,
                PrintStack,
                StackOperation,
                RemoveLink);
            m_Reactions = new MyList<Exception>();
        }

        public string Menu =>
            "Меню стека, основанного на односвязном списке\n" +
            "1. Создать новую ссылку на стек\n" +
            "2. Выбрать ссылку на стек\n" +
            "3. Сформировать стек конструктором\n" +
            "4. Распечатать стек\n" +
            "5. Операции над стеком\n" +
            "6. Удалить стек\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        public void CreateLink()
        {

        }

        public void ChoiceLink()
        {

        }

        public void ConstructStack()
        {
            Waiter.Instance.Run(new StackConstructMenu(m_ActiveStack));
        }

        public void PrintStack()
        {

        }

        public void StackOperation()
        {
            Waiter.Instance.Run(new StackOperationMenu(m_ActiveStack));
        }

        public void RemoveLink()
        {

        }
    }
}
