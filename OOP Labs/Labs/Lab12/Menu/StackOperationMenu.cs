using Dialog;
using System;
using Lab12.Additionally;

namespace Lab12.Menu
{
    class StackOperationMenu : IMenu
    {
        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private StackAgregator<int> m_Stack;

        public StackOperationMenu(StackAgregator<int> stack)
        {
            m_Stack = stack;
            m_Tasks = new MyList<Action>(
                OutputCount,
                AddItem,
                AddMultipleItems,
                RemoveItem,
                RemoveMultipleItems,
                ClearStack);
            m_Reactions = new MyList<Exception>();
        }

        public string Menu =>
            "Меню стека, основанного на односвязном списке\n" +
            "1. Вывести свойство Count\n" +
            "2. Добавить элемент\n" +
            "3. Добавить несколько элементов\n" +
            "4. Удалить элемент\n" +
            "5. Удалить несколько элементов\n" +
            "6. Очистить коллекцию\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private void OutputCount()
        {

        }

        private void AddItem()
        {

        }

        private void AddMultipleItems()
        {

        }

        private void RemoveItem()
        {

        }

        private void RemoveMultipleItems()
        {

        }

        private void ClearStack()
        {

        }

    }
}
