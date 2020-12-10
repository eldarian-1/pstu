﻿using Dialog;
using Entity;
using System;
using Collection.BiList;
using System.Collections.Generic;

namespace Lab12.Menu
{
    class BiListMenu : IMenu
    {
        private static IMenu s_Instance;
        private static Exception s_NullList = new Exception("Список не создан");

        private const string c_EnterCount = "Введите количество элементов: ";

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;
        private IList<int> m_List;

        public static IMenu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new BiListMenu();
                return s_Instance;
            }
        }

        private BiListMenu()
        {
            m_Tasks = new MyList<Action>(
                ConstructList,
                PrintList,
                RemoveEvenNumber,
                RemoveList);
            m_Reactions = new MyList<Exception>(s_NullList);
        }

        public string Menu =>
            "Меню двусвзного списка\n" +
            "1. Сформировать список\n" +
            "2. Распечатать список\n" +
            "3. Удалить четные номера\n" +
            "4. Удалить список\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;

        public MyList<Exception> Reactions => m_Reactions;

        private void CheckList()
        {
            if (m_List == null)
                throw s_NullList;
        }

        public void ConstructList()
        {
            m_List = new BiList<int>();
            Input.ReadNum(out int count, c_EnterCount);
            int[] array = EngineFacade.Instance.GenerateInt(count);
            foreach (int item in array)
                m_List.Add(item);
        }

        public void PrintList()
        {
            CheckList();
            Waiter.Write(m_List.ToString());
        }

        public void RemoveEvenNumber()
        {
            CheckList();
            for (int i = 0, j = 0; j < m_List.Count; ++i, ++j)
                if (i % 2 == 1)
                    m_List.RemoveAt(j--);
        }

        public void RemoveList()
        {
            CheckList();
            m_List = null;
        }
    }
}
