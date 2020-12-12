﻿using Dialog;
using System;
using Lab12.Additionally;

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

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private StackAgregator<int> m_Stack;
        private string m_StackName;

        public StackOperationMenu(StackAgregator<int> stack, string stackName)
        {
            m_Stack = stack;
            m_StackName = stackName;
            m_Tasks = new MyList<Action>(
                OutputStack,
                OutputCount,
                AddItem,
                AddMultipleItems,
                RemoveItem,
                RemoveMultipleItems,
                ClearStack);
            m_Reactions = new MyList<Exception>();
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

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private void OutputStack()
        {
            Waiter.Write(m_Stack.ToString());
        }

        private void OutputCount()
        {
            Waiter.Write(string.Format(c_CountStack, m_Stack.Count));
        }

        private void AddItem()
        {
            Input.ReadNum(out int num, c_EnterNumber);
            m_Stack.AddItem(num);
            Waiter.Write(string.Format(c_AddedItem, num));
        }

        private void AddMultipleItems()
        {
            Input.ReadNum(out int count, c_EnterCount, i => i >= 0 && i <= c_MaxCount - m_Stack.Count);
            for(int i = 0; i < count; ++i)
            {
                Input.ReadNum(out int num, string.Format(c_EnterNumberA, i + 1));
                m_Stack.AddItem(num);
            }
            Waiter.Write(c_AddedItems);
        }

        private void RemoveItem()
        {
            Input.ReadNum(out int index, c_EnterNumber, i => i >= 0 && i < m_Stack.Count);
            m_Stack.RemoveItem(index);
            Waiter.Write(string.Format(c_RemovedItem, index));
        }

        private void RemoveMultipleItems()
        {
            Input.ReadNum(out int count, c_EnterCount, i => i >= 0 && i <= c_MaxCount);
            int[] indexes = new int[count];
            for (int i = 0; i < count; ++i)
                Input.ReadNum(out indexes[i], string.Format(c_EnterNumberA, i + 1));
            m_Stack.RemoveMultipleItems(indexes);
            Waiter.Write(c_RemovedItems);
        }

        private void ClearStack()
        {
            m_Stack.Clear();
            Waiter.Write(c_ClearStack);
        }
    }
}
