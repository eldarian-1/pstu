using Dialog;
using System;

namespace Lab14
{
    internal class MainMenu : IMenu
    {
        private static IMenu s_Instance;

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private TestCollections m_Collection;

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
                Output,
                Selection,
                GetCount,
                AveragePower,
                MedianPower,
                Union);
            m_Reactions = new MyList<Exception>();
        }

        public string Menu =>
            "Главное меню\n" +
            "1. Сформировать коллекцию\n" +
            "2. Вывести коллекцию\n" +
            "3. Запрос на выборку данных\n" +
            "4. Запрос на получение счетчика\n" +
            "5. Средняя мощность\n" +
            "6. Медианная мощность\n" +
            "7. Объединение множеств\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private void Formation()
        {
            m_Collection = new TestCollections(10);
        }

        private void Output()
        {
            Waiter.Write(m_Collection.ToString());
        }

        private void Selection()
        {
            Waiter.Write(m_Collection.SelectPseudonym());
        }

        private void GetCount()
        {
            Waiter.Write(m_Collection.CountDiesel().ToString());
        }

        private void AveragePower()
        {
            Waiter.Write(m_Collection.AveragePower().ToString());
        }

        private void MedianPower()
        {
            Waiter.Write(m_Collection.MedianPower().ToString());
        }

        private void Union()
        {
            Waiter.Write(m_Collection.InternalReactive());
        }
    }
}
