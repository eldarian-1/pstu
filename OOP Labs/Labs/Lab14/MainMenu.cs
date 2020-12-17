using Dialog;
using System;
using System.Collections.Generic;

namespace Lab14
{
    internal class MainMenu : IMenu
    {
        private static Exception s_NullCollections = new Exception("Коллекции не созданы!");

        private const int c_MaxCount = 10000;
        private const string c_Linq = "LINQ";
        private const string c_Extension = "Методы расширения";
        private const string c_Engines = "Двигатели:\n";
        private const string c_Pseudonyms = "Псевдонимы двигателей:\n";
        private const string c_Diesels = "Количество дизельных двигателей: ";
        private const string c_AveragePower = "Средняя мощность двигателей: ";
        private const string c_MedianPower = "Медианная мощность двигателей: ";
        private const string c_InternalTurboreactive
            = "Множество двигателей внутреннего сгорания и турбореактивных двигателей:\n";
        private const string c_EnterCount = "Введите количество элементов коллекции: ";

        private IList<Action> m_Tasks;
        private IList<Exception> m_Reactions;
        private TestCollection m_Collection;
        private bool m_Linq;

        public MainMenu()
        {
            m_Linq = true;
            m_Tasks = new List<Action>().Add(
                Formation,
                Output,
                ChangeType,
                Selection,
                GetCount,
                AveragePower,
                MedianPower,
                Union);
            m_Reactions = new List<Exception>().Add(s_NullCollections, null);
        }

        public string Menu =>
            "Главное меню\n" +
            "1. Сформировать коллекцию\n" +
            "2. Вывести коллекцию\n" +
            "3. Изменить тип запросов (сейчас " + (m_Linq ? c_Linq : c_Extension) + ")\n" +
            "4. Запрос на выборку псевдонимов коллекций\n" +
            "5. Запрос на получение счетчика дизельных двигателей\n" +
            "6. Средняя мощность всех двигателей\n" +
            "7. Медианная мощность всех двигателей\n" +
            "8. Объединение множеств двигателей внутреннего сгорания и турбореактивных\n" +
            "0. Выход\n" +
            "Введите номер задачи: ";

        public IList<Action> Tasks => m_Tasks;

        public IList<Exception> Reactions => m_Reactions;

        private IQuery QueryCollections()
            => m_Collection.QueryCollections(m_Linq);

        private string EnginesToString(IEnumerable<string> engines)
        {
            string result = "";
            foreach (var item in engines)
                result += item + "\n";
            return result;
        }

        private void CheckCollections()
        {
            if (m_Collection == null)
                throw s_NullCollections;
        }

        private void Formation()
        {
            Input.ReadNum(out int count, c_EnterCount, i => i >= 0 && i <= c_MaxCount);
            m_Collection = new TestCollection(count);
            Output();
        }

        private void Output()
        {
            CheckCollections();
            MenuManager.Write(c_Engines + m_Collection.ToString());
        }

        private void ChangeType()
        {
            m_Linq = !m_Linq;
            MenuManager.Write("Тип запросов изменен на " + (m_Linq ? c_Linq : c_Extension));
        }

        private void Selection()
        {
            CheckCollections();
            MenuManager.Write(c_Pseudonyms +
                EnginesToString(QueryCollections().SelectPseudonym()));
        }

        private void GetCount()
        {
            CheckCollections();
            MenuManager.Write(c_Diesels +
                QueryCollections().CountDiesel().ToString());
        }

        private void AveragePower()
        {
            CheckCollections();
            MenuManager.Write(c_AveragePower +
                QueryCollections().AveragePower().ToString());
        }

        private void MedianPower()
        {
            CheckCollections();
            MenuManager.Write(c_MedianPower +
                QueryCollections().MedianPower().ToString());
        }

        private void Union()
        {
            CheckCollections();
            MenuManager.Write(c_InternalTurboreactive +
                EnginesToString(QueryCollections().InternalReactive()));
        }
    }
}
