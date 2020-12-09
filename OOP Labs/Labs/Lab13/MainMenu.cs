using Dialog;
using System;

namespace Lab13
{
    class MainMenu : IMenu
    {
        private static IMenu s_Instance;

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;

        public static IMenu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new MainMenu();
                return s_Instance;
            }
        }

        private MainMenu()
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
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private void Formation()
        {
            ObservableStack stack1 = new ObservableStack();
            ObservableStack stack2 = new ObservableStack();
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();
            stack1.CountChanged += new StackHandler(journal1.CountChange);
            stack1.ReferenceChanged += new StackHandler(journal1.ReferenceChange);
            stack1.CountChanged += new StackHandler(journal2.CountChange);
            stack2.CountChanged += new StackHandler(journal2.CountChange);
        }

        private void Add()
        {

        }

        private void Insert()
        {

        }

        private void Remove()
        {

        }

        private void Erase()
        {

        }

        private void Edit()
        {

        }

        private void OutCollection()
        {

        }

        private void OutJournal()
        {

        }
    }
}
