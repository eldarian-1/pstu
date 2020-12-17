using Dialog;
using Entity;
using System;
using System.Collections.Generic;

namespace Lab13
{
    internal class MainMenu : IMenu
    {
        private static Exception s_EmptyCollection = new Exception("Коллекция пуста!");

        private const string c_LeftStack = "Левая";
        private const string c_RightStack = "Правая";
        private const string c_EnterIndex = "Введите индекс: ";
        private const string c_AddedItem = "Добавлен элемент: {0}";
        private const string c_PopItem = "Последний элемент в стеке удален.";
        private const string c_ChangeItem = "Элемент по индексу {0} {1}.";
        private const string c_IsEdited = "изменен";
        private const string c_IsRemoved = "удален";
        private const string c_IsntExist = "не существует";
        private const string c_ActiveStack = "Выбрана {0} коллекция";
        private const string c_EnterJournal = "1. Левый журнал\n2. Правый журнал\nВыберете журнал: ";

        private IList<Action> m_Tasks;
        private IList<Exception> m_Reactions;

        private bool m_IsLeftStack;
        private Journal m_LeftJournal;
        private Journal m_RightJournal;
        private ObservableAgregator m_LeftStack;
        private ObservableAgregator m_RightStack;

        public MainMenu()
        {
            m_IsLeftStack = true;
            m_LeftJournal = new Journal();
            m_RightJournal = new Journal();
            m_LeftStack = new ObservableAgregator(c_LeftStack);
            m_RightStack = new ObservableAgregator(c_RightStack);
            m_LeftStack.CountChanged += new StackHandler(m_LeftJournal.CountChange);
            m_LeftStack.ReferenceChanged += new StackHandler(m_LeftJournal.ReferenceChange);
            m_LeftStack.CountChanged += new StackHandler(m_RightJournal.CountChange);
            m_RightStack.CountChanged += new StackHandler(m_RightJournal.CountChange);
            m_Tasks = new List<Action>().Append(
                ChoiseCollection,
                Add,
                Pop,
                Remove,
                Edit,
                OutCollection,
                OutJournal);
            m_Reactions = new List<Exception>().Append(s_EmptyCollection);
        }

        public string Menu =>
            "Главное меню\n" +
            "1. Выбрать коллекцию (сейчас: " + (m_IsLeftStack ? c_LeftStack : c_RightStack) + ")\n" +
            "2. Добавить в конец\n" +
            "3. Удалить с конца\n" +
            "4. Удалить по индексу\n" +
            "5. Присвоить по индексу\n" +
            "6. Вывести коллекцию\n" +
            "7. Вывести журнал\n" +
            "0. Выход\n" +
            "Введите номер задачи: ";

        public IList<Action> Tasks => m_Tasks;

        public IList<Exception> Reactions => m_Reactions;

        private ObservableAgregator ActiveStack => m_IsLeftStack ? m_LeftStack : m_RightStack;

        private void CheckCollection()
        {
            if (ActiveStack.Count == 0)
                throw s_EmptyCollection;
        }

        private void ChoiseCollection()
        {
            m_IsLeftStack = !m_IsLeftStack;
            MenuManager.Write(string.Format(c_ActiveStack,
                m_IsLeftStack ? c_LeftStack : c_RightStack));
        }

        private void Add()
        {
            IEngine engine = EngineFacade.Instance.Generate();
            ActiveStack.Push(engine);
            MenuManager.Write(string.Format(c_AddedItem, engine));
        }

        private void Pop()
        {
            CheckCollection();
            ActiveStack.Pop();
            MenuManager.Write(c_PopItem);
        }

        private void Remove()
        {
            CheckCollection();
            Input.ReadNum(out int index, c_EnterIndex);
            bool result = ActiveStack.Remove(index);
            MenuManager.Write(string.Format(c_ChangeItem, index,
                result ? c_IsRemoved : c_IsntExist));
        }

        private void Edit()
        {
            CheckCollection();
            Input.ReadNum(out int index, c_EnterIndex, i => i >= 0 && i < ActiveStack.Count);
            IEngine engine = EngineFacade.Instance.Generate();
            ActiveStack[index] = engine;
            MenuManager.Write(string.Format(c_ChangeItem, index, c_IsEdited));
        }

        private void OutCollection()
        {
            CheckCollection();
            MenuManager.Write(ActiveStack.ToString());
        }

        private void OutJournal()
        {
            Input.ReadNum(out int number, c_EnterJournal, i => i >= 1 && i <= 2);
            bool isLeft = number == 1;
            MenuManager.Write((isLeft ? m_LeftJournal : m_RightJournal).ToString());
        }
    }
}
