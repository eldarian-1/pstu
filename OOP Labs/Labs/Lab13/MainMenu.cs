using Dialog;
using Entity;
using System;

namespace Lab13
{
    internal class MainMenu : IMenu
    {
        private const string c_EnterStack = "1. Левый стек\n2. Правый стек\nВыберете стек: ";
        private const string c_EnterJournal = "1. Левый журнал\n2. Правый журнал\nВыберете журнал: ";
        private const string c_EnterIndex = "Введите индекс: ";

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;

        private ObservableStack m_LeftStack;
        private ObservableStack m_RightStack;
        private Journal m_LeftJournal;
        private Journal m_RightJournal;

        public MainMenu()
        {
            m_Tasks = new MyList<Action>(
                Formation,
                Add,
                Insert,
                Remove,
                Erase,
                Edit,
                OutCollection,
                OutJournal);
            m_Reactions = new MyList<Exception>();
        }

        public string Menu =>
            "Главное меню\n" +
            "1. Сформировать коллекцию\n" +
            "2. Добавить элемент\n" +
            "3. Добавить по индексу\n" +
            "4. Удалить элемент\n" +
            "5. Удалить по индексу\n" +
            "6. Присвоить по индексу\n" +
            "7. Вывести коллекцию\n" +
            "8. Вывести журнал\n" +
            "0. Выход\n" +
            "Введите номер задачи: ";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private bool IsLeft(string thing)
        {
            int number;
            do Input.ReadNum(out number, thing);
            while (number != 1 && number != 2);
            return number == 1;
        }

        private void Formation()
        {
            m_LeftStack = new ObservableStack();
            m_RightStack = new ObservableStack();
            m_LeftJournal = new Journal();
            m_RightJournal = new Journal();
            m_LeftStack.CountChanged += new StackHandler(m_LeftJournal.CountChange);
            m_LeftStack.ReferenceChanged += new StackHandler(m_LeftJournal.ReferenceChange);
            m_LeftStack.CountChanged += new StackHandler(m_RightJournal.CountChange);
            m_RightStack.CountChanged += new StackHandler(m_RightJournal.CountChange);
        }

        private void Add()
        {
            IEngine engine = EngineFacade.Instance.Generate();
            if (IsLeft(c_EnterStack))
                m_LeftStack.Add(engine);
            else
                m_RightStack.Add(engine);
        }

        private void Insert()
        {
            bool isLeft = IsLeft(c_EnterStack);
            Input.ReadNum(out int index, c_EnterIndex);
            IEngine engine = EngineFacade.Instance.Generate();
            if (isLeft)
                m_LeftStack.Insert(index, engine);
            else
                m_RightStack.Insert(index, engine);
        }

        private void Remove()
        {
            if (IsLeft(c_EnterStack))
                m_LeftStack.Remove();
            else
                m_RightStack.Remove();
        }

        private void Erase()
        {
            bool isLeft = IsLeft(c_EnterStack);
            Input.ReadNum(out int index, c_EnterIndex);
            if (isLeft)
                m_LeftStack.Erase(index);
            else
                m_RightStack.Erase(index);
        }

        private void Edit()
        {
            bool isLeft = IsLeft(c_EnterStack);
            Input.ReadNum(out int index, c_EnterIndex);
            IEngine engine = EngineFacade.Instance.Generate();
            if (isLeft)
                m_LeftStack[index] = engine;
            else
                m_RightStack[index] = engine;
        }

        private void OutCollection()
        {
            if (IsLeft(c_EnterStack))
                Waiter.Write(m_LeftStack.ToString());
            else
                Waiter.Write(m_RightStack.ToString());
        }

        private void OutJournal()
        {
            if (IsLeft(c_EnterJournal))
                Waiter.Write(m_LeftJournal.ToString());
            else
                Waiter.Write(m_RightJournal.ToString());
        }
    }
}
