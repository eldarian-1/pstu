using Resultion;
using Resolution.Lists;
using Resolution.Visuals;

namespace Resolution
{
    public class ResultFormater
    {
        private VariableList m_Variables;
        private FunctionVisual m_Function;
        private TruthTable m_TruthTable;

        public ResultFormater(LogicFacade facade)
        {
            m_Function = facade.ActiveFunction.Get();
            m_Variables = facade.Variables.ToList();
            m_TruthTable = new TruthTable(m_Variables.Count);
            Calculate();
        }

        private void Calculate()
        {
            int changes = m_TruthTable.Changes;
            int variables = m_TruthTable.Variables;
            for (int i = 0; i < changes; ++i)
            {
                for (int j = 0; j < variables; ++j)
                    m_Variables[j].Value = m_TruthTable[i, j];
                m_TruthTable[i] = m_Function.Value;
            }
        }

        private string GetNum(bool val) => val ? "1" : "0";

        public string Execute()
        {
            string result = "Таблица истинности:\n";

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
