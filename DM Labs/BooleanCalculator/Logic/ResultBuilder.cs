using Entity;
using System;
using System.Collections.ObjectModel;

namespace Logic
{
    internal class ResultBuilder
    {
        private ObservableCollection<SymbolAdapter> m_Symbols;
        private StateExpression m_Expression;

        public ResultBuilder(LogicFacade facade)
        {
            m_Symbols = facade.Symbols;
            m_Expression = facade.ActiveExpression;
        }

        public TruthTable CreateTable()
        {
            int variables = m_Symbols.Count;
            int changes = (int)Math.Pow(2, variables);
            TruthTable table = new TruthTable(variables, changes);

            bool[] tempVariables = new bool[variables];
            for (int i = 0; i < variables; ++i)
                tempVariables[i] = m_Symbols[i].Value;

            int[] devide = new int[variables];
            for (int i = 0; i < variables; ++i)
                devide[i] = (int)Math.Pow(2, i);

            for (int i = 0; i < changes; ++i)
            {
                for (int j = 0; j < variables; ++j)
                {
                    int num = (i & devide[variables - 1 - j]) / devide[variables - 1 - j];
                    table[i, j] = num == 1;
                    m_Symbols[j].Value = table[i, j];
                }
                table[i] = m_Expression.Value;
            }

            for (int i = 0; i < variables; ++i)
                m_Symbols[i].Value = tempVariables[i];

            return table;
        }

        private string GetNum(bool val)
        {
            if (val)
                return "1";
            else
                return "0";
        }

        public string Run()
        {
            TruthTable table = CreateTable();
            string result
                = "Результат на заданном наборе: "
                + GetNum(m_Expression.Value)
                + "\n\nТаблица истинности:\n";

            for (int i = 0, n = table.Variables; i < n; ++i)
                result += ((char)('A' + i)).ToString();
            result += " Res\n";

            for (int i = 0, n = table.Changes; i < n; ++i)
            {
                for (int j = 0, m = table.Variables; j < m; ++j)
                    result += table[i, j] ? 1 : 0;
                result += " " + GetNum(table[i]) + "\n";
            }

            return result;
        }
    }
}
