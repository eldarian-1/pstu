using Dialog;
using System;

namespace Lab14
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
                Selection,
                GetCount,
                Intersection,
                Union,
                Difference);
            m_Reactions = new MyList<Exception>();
        }

        public string Menu =>
            "Главное меню\n" +
            "1. Сформировать коллекцию\n" +
            "2. Запрос на выборку данных\n" +
            "3. Запрос на получение счетчика\n" +
            "4. Пересечение множеств\n" +
            "5. Объединение множеств\n" +
            "6. Вычитание множеств\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private void Formation()
        {

        }

        private void Selection()
        {

        }

        private void GetCount()
        {

        }

        private void Intersection()
        {

        }

        private void Union()
        {

        }

        private void Difference()
        {

        }
    }
}
