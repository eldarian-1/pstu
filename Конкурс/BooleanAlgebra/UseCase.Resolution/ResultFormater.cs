using Model.Logic;
using UseCase.Resolution.Lists;
using UseCase.Resolution.Visuals;

namespace UseCase.Resolution
{
    public class ResultFormater : ResultFormater<VariableVisual, FunctionVisual, VariableList, FunctionList>
    {
        public override ResultFormater<VariableVisual, FunctionVisual, VariableList, FunctionList>
            SetFacade(LogicFacade<VariableVisual, FunctionVisual, VariableList, FunctionList> facade)
        {
            Function = facade.ActiveFunction;
            Variables = facade.Variables;
            TruthTable = new TruthTable(Variables.Count);
            Calculate();
            return this;
        }

        private string GetNum(bool val) => val ? "1" : "0";

        public override string Execute()
        {
            string result = "Таблица истинности:\n";

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
