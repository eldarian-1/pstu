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

        private const string c_EmptyDictionary = "Стек не выбран. Словарь стеков пуст.";
        private const string c_EnterKey = "Введите имя стека: ";
        private const string c_EnterNum = "Введите номер стека: ";

        private IList<Action> m_Tasks;
        private IList<Exception> m_Reactions;
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
            m_Tasks = new List<Action>().Add(
                CreateLink,
                ChoiceLink,
                ConstructStack,
                PrintStack,
                StackOperation,
                RemoveLink);
            m_Reactions = new List<Exception>().Add(
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
            "6. Удалить ссылку на стек\n" +
            "0. Выход\n" +
            "Введите номер задачи: ";

        public IList<Action> Tasks => m_Tasks;

        public IList<Exception> Reactions => m_Reactions;

        private void CheckDictionary()
        {
            if (m_Stacks.Count == 0)
                throw s_NullDictionary;
        }

        private void CheckStack(bool toCreate = false)
        {
            if (toCreate)
            {
                if (m_ActiveKey == "")
                    throw s_NullStack;
            }
            else if (m_ActiveKey == "" || m_Stacks[m_ActiveKey].Empty)
                throw s_NullStack;
        }

        public void CreateLink()
        {
            Input.ReadWord(out m_ActiveKey, c_EnterKey);
            m_Stacks.Add(m_ActiveKey, new StackAgregator<int>());
        }

        public static string ChoiseLink(IDictionary<string, StackAgregator<int>> stacks)
        {
            int index = 0;
            int number;
            string query = "", result = "";
            foreach (var item in stacks)
                query += ++index + ". " + item.Key + "\n";
            query += c_EnterNum;
            do Input.ReadNum(out number, query);
            while (number < 1 || number > index);
            index = 0;
            foreach (var item in stacks)
            {
                ++index;
                if (index == number)
                {
                    result = item.Key;
                    break;
                }
            }
            return result;
        }

        public void ChoiceLink()
        {
            CheckDictionary();
            m_ActiveKey = ChoiseLink(m_Stacks);
        }

        public void ConstructStack()
        {
            CheckDictionary();
            CheckStack(true);
            MenuManager.Instance.Run(new StackConstructMenu(m_Stacks, m_ActiveKey));
        }

        public void PrintStack()
        {
            CheckDictionary();
            CheckStack();
            MenuManager.Write(m_Stacks[m_ActiveKey].ToString());
        }

        public void StackOperation()
        {
            CheckDictionary();
            CheckStack();
            MenuManager.Instance.Run(new StackOperationMenu(m_Stacks[m_ActiveKey], m_ActiveKey));
        }

        public void RemoveLink()
        {
            CheckDictionary();
            m_Stacks.Remove(m_ActiveKey);
            try
            {
                CheckDictionary();
                foreach (var item in m_Stacks)
                {
                    m_ActiveKey = item.Key;
                    break;
                }
            }
            catch(Exception e)
            {
                if (e == s_NullDictionary)
                    MenuManager.Write(c_EmptyDictionary);
                else
                    throw e;
            }
        }
    }
}
