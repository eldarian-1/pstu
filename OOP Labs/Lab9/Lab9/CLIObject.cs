using System;

namespace Lab9
{
    class CLIObject
    {
        private const string c_sCount = "Количество элементов: ";

        private string m_sMenu;
        private Task[] m_tTasks;

        public CLIObject(string menu, params Task[] tasks)
        {
            m_sMenu = menu;
            m_tTasks = tasks;
        }

        public void Run()
            => CLI.Run(GetTask);

        public void Run(string menu, params Task[] tasks)
        {
            string sTemp = m_sMenu;
            Task[] tTemp = m_tTasks;
            m_sMenu = menu;
            m_tTasks = tasks;
            CLI.Run(GetTask);
            Console.WriteLine();
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
            => CLI.GetMoney(GetNum, i);

        public MoneyArray GetMoneyArray(GetNumber GetNum)
        {
            int n = CLI.GetValidNum(GetNum, c_sCount);
            Money[] array = new Money[n];
            for(int i = 0; i < n; ++i)
                array[i] = GetMoney(GetNum, i);
            return new MoneyArray(array);
        }
    }
}
