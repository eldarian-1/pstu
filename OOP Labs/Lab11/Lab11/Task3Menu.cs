using System;
using Dialog;

namespace Lab11
{
    class Task3Menu : IWaiter
    {
        private const string c_Menu =
            "Меню Stack и Dictionary\n" +
            "1. Сгенерировать коллекции\n" +
            "2. Вывести коллекцию Dictionary<string, IEngine>\n" +
            "3. Поиск по индексу в списке\n" +
            "4. Поиск по индексу двигателя\n" +
            "5. Поиск по псевдониму двигателя\n" +
            "6. Поиск первого элемента\n" +
            "7. Поиск центрального элемента\n" +
            "8. Поиск последнего элемента\n" +
            "9. Поиск невходящего элемента\n" +
            "0. Назад\n" +
            "Выберете действие: ";
        private const string c_sEnterCount = "Введите количество элементов: ";
        private const string c_sFindByIndexList = "Введите индекс в списке: ";
        private const string c_sFindByIndexEngine = "Введите индекс двигателя: ";
        private const string c_sFindByPseudonym = "Введите псевдоним двигателя: ";
        private static readonly Exception EmptyCollections = new Exception("Коллекции пусты");

        private static Task3Menu s_Instance = null;

        private TestCollections testCollections;

        public static Task3Menu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new Task3Menu();
                return s_Instance;
            }
        }

        public string Menu { get; }
        public MyList<Task> Tasks { get; }
        public MyList<Exception> Reactions { get; }

        private Task3Menu()
        {
            testCollections = new TestCollections();
            Menu = c_Menu;
            Tasks = new MyList<Task>(
                Generate,
                Output,
                FindByIndexList,
                FindByIndexEngine,
                FindByPseudonym,
                FindFirst,
                FindCenter,
                FindLast,
                FindNonIncluded);
            Reactions = new MyList<Exception>(EmptyCollections);
        }

        private void Generate()
        {
            Input.ReadNum(out int count, c_sEnterCount);
            testCollections.Generate(count);
        }

        private void Output()
        {
            string result = testCollections.ToString();
            TaskRunner.Write(result);
        }

        private void FindByIndexList()
        {
            Input.ReadNum(out int index, c_sFindByIndexList);
            string result = testCollections.FindByIndexList(index);
            TaskRunner.Write(result);
        }

        private void FindByIndexEngine()
        {
            Input.ReadNum(out int index, c_sFindByIndexEngine);
            string result = testCollections.FindByIndexEngine(index);
            TaskRunner.Write(result);
        }

        private void FindByPseudonym()
        {
            Input.ReadWord(out string pseudonym, c_sFindByPseudonym);
            string result = testCollections.FindByPseudonym(pseudonym);
            TaskRunner.Write(result);
        }

        private void FindFirst()
        {
            string result = testCollections.FindFirst();
            TaskRunner.Write(result);
        }

        private void FindCenter()
        {
            string result = testCollections.FindCenter();
            TaskRunner.Write(result);
        }

        private void FindLast()
        {
            string result = testCollections.FindLast();
            TaskRunner.Write(result);
        }

        private void FindNonIncluded()
        {
            string result = testCollections.FindNonIncluded();
            TaskRunner.Write(result);
        }
    }
}
