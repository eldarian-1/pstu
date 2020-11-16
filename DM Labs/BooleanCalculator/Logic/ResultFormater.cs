using Entity;
using System.Collections.ObjectModel;

namespace Logic
{
    internal class ResultFormater
    {
        private StateExpression m_Expression;
        private TruthTable m_TruthTable;

        public ResultFormater(LogicFacade facade)
        {
            m_Expression = facade.ActiveExpression;
            m_TruthTable = CreateTable(facade.Symbols);
        }

        private TruthTable CreateTable(ObservableCollection<SymbolAdapter> symbols)
        {
            TruthTable table = new TruthTable(symbols.Count);
            int changes = table.Changes;
            int variables = table.Variables;

            bool[] tempVariables = new bool[variables];
            for (int i = 0; i < variables; ++i)
                tempVariables[i] = symbols[i].Value;

            for (int i = 0; i < changes; ++i)
            {
                for (int j = 0; j < variables; ++j)
                    symbols[j].Value = table[i, j];
                table[i] = m_Expression.Value;
            }

            for (int i = 0; i < variables; ++i)
                symbols[i].Value = tempVariables[i];

            return table;
        }

        private string GetNum(bool val) => val ? "1" : "0";

        public string Execute()
        {
            string result
                = "Результат на заданном наборе: "
                + GetNum(m_Expression.Value)
                + "\n\nТаблица истинности:\n";

            for (int i = 0, n = m_TruthTable.Variables; i < n; ++i)
                result += ((char)('A' + i)).ToString();
            result += " Res\n";

            for (int i = 0, n = m_TruthTable.Changes; i < n; ++i)
            {
                for (int j = 0, m = m_TruthTable.Variables; j < m; ++j)
                    result += m_TruthTable[i, j] ? 1 : 0;
                result += " " + GetNum(m_TruthTable[i]) + "\n";
            }

            return result;
        }
    }
}
