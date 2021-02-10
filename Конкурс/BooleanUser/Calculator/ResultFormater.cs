using Logic;
using Entity;
using Logic.Commands;
using System.Collections.ObjectModel;

namespace Calculator
{
    public class ResultFormater :
        ResultFormater<
            Variable,
            Function,
            ObservableCollection<Variable>,
            ObservableCollection<Function>>
    {
        private bool[] m_Reserv;

        public override ResultFormater<Variable, Function, ObservableCollection<Variable>, ObservableCollection<Function>>
            SetFacade(LogicFacade<Variable, Function, ObservableCollection<Variable>, ObservableCollection<Function>> facade)
        {
            Function = facade.ActiveFunction;
            Variables = facade.Variables;
            TruthTable = new TruthTable(Variables.Count);
            PackReserv();
            Calculate();
            UnpackReserv();
            return this;
        }

        private void PackReserv()
        {
            int variables = TruthTable.Variables;
            m_Reserv = new bool[variables];
            for (int i = 0; i < variables; ++i)
                m_Reserv[i] = Variables[i].Value;
        }

        private void UnpackReserv()
        {
            int variables = TruthTable.Variables;
            for (int i = 0; i < variables; ++i)
                Variables[i].Value = m_Reserv[i];
        }

        private string GetNum(bool val) => val ? "1" : "0";

        public override string Execute()
        {
            string result
                = "Результат на заданном наборе: "
                + GetNum(Function.Value)
                + "\n\nТаблица истинности:\n";

            for (int i = 0, n = TruthTable.Variables; i < n; ++i)
                result += ((char)('A' + i)).ToString();
            result += " Res\n";

            for (int i = 0, n = TruthTable.Changes; i < n; ++i)
            {
                for (int j = 0, m = TruthTable.Variables; j < m; ++j)
                    result += TruthTable[i, j] ? 1 : 0;
                result += " " + GetNum(TruthTable[i]) + "\n";
            }

            return result;
        }
    }
}
