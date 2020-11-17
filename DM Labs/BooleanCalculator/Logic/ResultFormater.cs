using Entity;
using System.Collections.ObjectModel;

namespace Logic
{
    internal class ResultFormater
    {
        private ObservableCollection<VariableAdapter> m_Symbols;
        private Function m_Expression;
        private TruthTable m_TruthTable;
        private bool[] m_Reserv;

        public ResultFormater(LogicFacade facade)
        {
            m_Expression = facade.ActiveExpression;
            m_Symbols = facade.Symbols;
            m_TruthTable = new TruthTable(m_Symbols.Count);
            PackReserv();
            Calculate();
            UnpackReserv();
        }

        private void PackReserv()
        {
            int variables = m_TruthTable.Variables;
            m_Reserv = new bool[variables];
            for (int i = 0; i < variables; ++i)
                m_Reserv[i] = m_Symbols[i].Value;
        }

        private void UnpackReserv()
        {
            int variables = m_TruthTable.Variables;
            for (int i = 0; i < variables; ++i)
                m_Symbols[i].Value = m_Reserv[i];
        }

        private void Calculate()
        {
            int changes = m_TruthTable.Changes;
            int variables = m_TruthTable.Variables;
            for (int i = 0; i < changes; ++i)
            {
                for (int j = 0; j < variables; ++j)
                    m_Symbols[j].Value = m_TruthTable[i, j];
                m_TruthTable[i] = m_Expression.Value;
            }
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
