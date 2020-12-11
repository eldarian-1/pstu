using Dialog;
using Entity;
using System;

namespace Lab13
{
    internal class MainMenu : IMenu
    {
        private static Exception s_NullCollection = new Exception("Коллекция не создана!");

        private const string c_LeftStack = "левая";
        private const string c_RightStack = "правая";
        private const string c_EnterIndex = "Введите индекс: ";
        private const string c_ActiveStack = "Выбрана {0} коллекция";
        private const string c_EnterJournal = "1. Левый журнал\n2. Правый журнал\nВыберете журнал: ";

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;

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
            m_Tasks = new MyList<Action>(
                ChoiseCollection,
                Add,
                Insert,
                Remove,
                Erase,
                Edit,
                OutCollection,
                OutJournal);
            m_Reactions = new MyList<Exception>(s_NullCollection);
        }

        public string Menu =>
            "Главное меню\n" +
            "1. Выбрать коллекцию (сейчас: " + (m_IsLeftStack ? c_LeftStack : c_RightStack) + ")\n" +
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

        private ObservableAgregator ActiveStack => m_IsLeftStack ? m_LeftStack : m_RightStack;

        private void CheckCollection()
        {
            if ((m_IsLeftStack && m_LeftStack == null)
                || (!m_IsLeftStack && m_RightStack == null))
                throw s_NullCollection;
        }

        private void ChoiseCollection()
        {
            m_IsLeftStack = !m_IsLeftStack;
            Waiter.Write(string.Format(c_ActiveStack,
                m_IsLeftStack ? c_LeftStack : c_RightStack));
        }

        private void Add()
        {
            CheckCollection();
            IEngine engine = EngineFacade.Instance.Generate();
            ActiveStack.Add(engine);
        }

        private void Insert()
        {
            CheckCollection();
            Input.ReadNum(out int index, c_EnterIndex);
            IEngine engine = EngineFacade.Instance.Generate();
            ActiveStack.Insert(index, engine);
        }

        private void Remove()
        {
            CheckCollection();
            ActiveStack.Remove();
        }

        private void Erase()
        {
            CheckCollection();
            Input.ReadNum(out int index, c_EnterIndex);
            ActiveStack.Erase(index);
        }

        private void Edit()
        {
            CheckCollection();
            Input.ReadNum(out int index, c_EnterIndex);
            IEngine engine = EngineFacade.Instance.Generate();
            ActiveStack[index] = engine;
        }

        private void OutCollection()
        {
            CheckCollection();
            Waiter.Write(ActiveStack.ToString());
        }

        private void OutJournal()
        {
            int number;
            do Input.ReadNum(out number, c_EnterJournal);
            while (number != 1 && number != 2);
            bool isLeft = number == 1;
            Waiter.Write((isLeft ? m_LeftJournal : m_RightJournal).ToString());
        }
    }
}
