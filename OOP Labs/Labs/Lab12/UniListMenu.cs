﻿using Dialog;
using System;

namespace Lab12
{
    class UniListMenu : IMenu
    {
        private static IMenu s_Instance;

        private MyList<Action> m_Tasks;
        private MyList<Exception> m_Reactions;

        public static IMenu Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new UniListMenu();
                return s_Instance;
            }
        }

        private UniListMenu()
        {
            m_Tasks = new MyList<Action>();
            m_Reactions = new MyList<Exception>();
        }

        public string Menu =>
            "Главное меню\n" +
            "1. Односвязный список\n" +
            "2. Двусвязный список\n" +
            "3. Бинарное дерево\n" +
            "4. Стек на основе односвязного списка\n" +
            "0. Выход\n";

        public MyList<Action> Tasks => m_Tasks;
        public MyList<Exception> Reactions => m_Reactions;
    }
}
