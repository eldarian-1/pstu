using Dialog;
using System;
using Lab12.Additionally;
using System.Collections.Generic;

namespace Lab12.Menu
{
    class StackMenu : IMenu
    {
        private static IMenu s_Instance;
        private static Exception s_NullDictionary = new Exception("Словарь стеков пуст");
        private static Exception s_NullStack = new Exception("Стек не создан");

        private const string c_EnterKey = "Введите имя стека: ";
        private const string c_EnterNum = "Введите номер стека: ";

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private IDictionary<string, StackAgregator<int>> m_Stacks;
        private string m_ActiveKey;

        public static IMenu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new StackMenu();
                return s_Instance;
            }
        }

        private StackMenu()
        {
            m_Stacks = new Dictionary<string, StackAgregator<int>>();
            m_Tasks = new MyList<Action>(
                CreateLink,
                ChoiceLink,
                ConstructStack,
                PrintStack,
                StackOperation,
                RemoveLink);
            m_Reactions = new MyList<Exception>(
                s_NullDictionary,
                s_NullStack);
        }

        public string Menu =>
            "Меню стека, основанного на односвязном списке\n" +
            "1. Создать новую ссылку на стек\n" +
            "2. Выбрать ссылку на стек\n" +
            "3. Сформировать стек конструктором\n" +
            "4. Распечатать стек\n" +
            "5. Операции над стеком\n" +
            "6. Удалить стек\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private void CheckDictionary()
        {
            if (m_Stacks.Count == 0)
                throw s_NullDictionary;
        }

        private void CheckStack()
        {
            if (m_ActiveKey == "")
                throw s_NullStack;
        }

        public void CreateLink()
        {
            Input.ReadWord(out string key, c_EnterKey);
            m_Stacks.Add(key, new StackAgregator<int>());
        }

        public void ChoiceLink()
        {
            CheckDictionary();
            int index = 0;
            int number;
            string query = "";
            foreach (var item in m_Stacks)
                query += ++index + item.Key + "\n";
            query += c_EnterNum;
            do Input.ReadNum(out number, query);
            while (number < 0 || number >= index);
            index = 0;
            foreach(var item in m_Stacks)
            {
                ++index;
                if(index == number)
                {
                    m_ActiveKey = item.Key;
                    break;
                }
            }
        }

        public void ConstructStack()
        {
            CheckDictionary();
            Waiter.Instance.Run(new StackConstructMenu(m_Stacks[m_ActiveKey]));
        }

        public void PrintStack()
        {
            CheckStack();
            Waiter.Write(m_Stacks[m_ActiveKey].ToString());
        }

        public void StackOperation()
        {
            CheckDictionary();
            Waiter.Instance.Run(new StackOperationMenu(m_Stacks[m_ActiveKey]));
        }

        public void RemoveLink()
        {
            CheckStack();
            m_Stacks.Remove(m_ActiveKey);
            CheckDictionary();
            foreach(var item in m_Stacks)
            {
                m_ActiveKey = item.Key;
                break;
            }
        }
    }
}
