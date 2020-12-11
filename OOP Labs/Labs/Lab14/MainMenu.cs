using Dialog;
using System;
using System.Collections.Generic;

namespace Lab14
{
    internal class MainMenu : IMenu
    {
        private const string c_Linq = "Linq-запросом?";
        private const string c_EnterCount = "Введите количество элементов коллекции: ";

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private TestCollections m_Collection;

        public MainMenu()
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
            "3. Запрос на выборку псевдонимов коллекций\n" +
            "4. Запрос на получение счетчика дизельных двигателей\n" +
            "5. Средняя мощность всех двигателей\n" +
            "6. Медианная мощность всех двигателей\n" +
            "7. Объединение множеств двигателей внутреннего сгорания и турбореактивных\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private IQueryCollections QueryCollections()
        {
            Input.ReadBoolean(out bool linq, c_Linq);
            return m_Collection.QueryCollections(linq);
        }

        private string EnginesToString(IEnumerable<string> engines)
        {
            string result = "";
            foreach (var item in engines)
                result += item + "\n";
            return result;
        }

        private void Formation()
        {
            Input.ReadNum(out int count, c_EnterCount);
            m_Collection = new TestCollections(count);
        }

        private void Output()
        {
            Waiter.Write(m_Collection.ToString());
        }

        private void Selection()
        {
            Waiter.Write(EnginesToString(QueryCollections().SelectPseudonym()));
        }

        private void GetCount()
        {
            Waiter.Write(QueryCollections().CountDiesel().ToString());
        }

        private void AveragePower()
        {
            Waiter.Write(QueryCollections().AveragePower().ToString());
        }

        private void MedianPower()
        {
            Waiter.Write(QueryCollections().MedianPower().ToString());
        }

        private void Union()
        {
            Waiter.Write(EnginesToString(QueryCollections().InternalReactive()));
        }
    }
}
