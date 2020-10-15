using System;

namespace Lab9
{
    class CLIObject
    {
        private string m_sMenu;
        private Task[] m_tTasks;

        public CLIObject(string menu, params Task[] tasks)
        {
            m_sMenu = menu;
            m_tTasks = tasks;
        }

        public void Run()
        {
            CLI.Run(GetTask);
        }

        public void Run(string menu, params Task[] tasks)
        {
            string sTemp = m_sMenu;
            Task[] tTemp = m_tTasks;
            m_sMenu = menu;
            m_tTasks = tasks;
            CLI.Run(GetTask);
            m_sMenu = sTemp;
            m_tTasks = tTemp;
        }

        public Task GetTask()
        {
            while (true)
            {
                CLI.ReadNum(out int i, m_sMenu);
                if (m_tTasks.Length >= i && i > 0)
                    return m_tTasks[i - 1];
                else if (i == 0)
                    break;
                else
                    continue;
            }
            throw new ApplicationException();
        }

        public Money GetMoney(GetNumber GetNum, int i = -1)
        {
            return CLI.GetMoney(GetNum, i);
        }
    }
}
