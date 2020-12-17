using Dialog;
using System;
using Lab12.Additionally;
using System.Collections.Generic;

namespace Lab12.Menu
{
    class StackOperationMenu : IMenu
    {
        private const int c_MaxCount = 10000;
        private const string c_EnterNumber = "Введите число: ";
        private const string c_EnterNumberA = "Введите число {0}: ";
        private const string c_EnterCount = "Введите количество новых элементов: ";
        private const string c_CountStack = "Количество элементов: ";
        private const string c_AddedItem = "Число {0} добавлено в стек.";
        private const string c_AddedItems = "Числа добавлены в стек.";
        private const string c_RemovedItem = "Элемент по индексу {0} удален.";
        private const string c_RemovedItems = "Элементы по заданным индексам удалены.";
        private const string c_ClearStack = "Стек очищен.";

        private IList<Action> m_Tasks;
        private IList<Exception> m_Reactions;
        private StackAgregator<int> m_Stack;
        private string m_StackName;

        public StackOperationMenu(StackAgregator<int> stack, string stackName)
        {
            m_Stack = stack;
            m_StackName = stackName;
            m_Tasks = new List<Action>().Append(
                OutputStack,
                OutputCount,
                AddItem,
                AddMultipleItems,
                RemoveItem,
                RemoveMultipleItems,
                ClearStack);
            m_Reactions = new List<Exception>();
        }

        public string Menu =>
            "Меню стека " + m_StackName + "\n" +
            "1. Распечатать стек\n" +
            "2. Вывести свойство Count\n" +
            "3. Добавить элемент\n" +
            "4. Добавить несколько элементов\n" +
            "5. Удалить элемент\n" +
            "6. Удалить несколько элементов\n" +
            "7. Очистить коллекцию\n" +
            "0. Выход\n" +
            "Введите номер задачи: ";

        public IList<Action> Tasks => m_Tasks;

        public IList<Exception> Reactions => m_Reactions;

        private void OutputStack()
        {
            MenuManager.Write(m_Stack.ToString());
        }

        private void OutputCount()
        {
            MenuManager.Write(string.Format(c_CountStack, m_Stack.Count));
        }

        private void AddItem()
        {
            Input.ReadNum(out int num, c_EnterNumber);
            m_Stack.AddItem(num);
            MenuManager.Write(string.Format(c_AddedItem, num));
        }

        private void AddMultipleItems()
        {
            Input.ReadNum(out int count, c_EnterCount, i => i >= 0 && i <= c_MaxCount - m_Stack.Count);
            for(int i = 0; i < count; ++i)
            {
                Input.ReadNum(out int num, string.Format(c_EnterNumberA, i + 1));
                m_Stack.AddItem(num);
            }
            MenuManager.Write(c_AddedItems);
        }

        private void RemoveItem()
        {
            Input.ReadNum(out int index, c_EnterNumber, i => i >= 0 && i < m_Stack.Count);
            m_Stack.RemoveItem(index);
            MenuManager.Write(string.Format(c_RemovedItem, index));
        }

        private void RemoveMultipleItems()
        {
            Input.ReadNum(out int count, c_EnterCount, i => i >= 0 && i <= c_MaxCount);
            int[] indexes = new int[count];
            for (int i = 0; i < count; ++i)
                Input.ReadNum(out indexes[i], string.Format(c_EnterNumberA, i + 1));
            m_Stack.RemoveMultipleItems(indexes);
            MenuManager.Write(c_RemovedItems);
        }

        private void ClearStack()
        {
            m_Stack.Clear();
            MenuManager.Write(c_ClearStack);
        }
    }
}
