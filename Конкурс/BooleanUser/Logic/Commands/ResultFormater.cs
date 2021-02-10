using Entity;
using System.Linq;
using System.Collections.Generic;

namespace Logic.Commands
{
    public abstract class ResultFormater<TVariable, TFunction, TVariableList, TFunctionList>
        where TVariable : Variable, ISymbol, new()
        where TFunction : Function, ISymbol, new()
        where TVariableList : ICollection<TVariable>, new()
        where TFunctionList : ICollection<TFunction>, new()
    {
        public abstract ResultFormater<TVariable, TFunction, TVariableList, TFunctionList> SetFacade
            (LogicFacade<TVariable, TFunction, TVariableList, TFunctionList> facade);

        protected TVariableList Variables { get; set; }

        protected TFunction Function { get; set; }

        protected TruthTable TruthTable { get; set; }

        protected void Calculate()
        {
            int changes = TruthTable.Changes;
            int variables = TruthTable.Variables;
            var vars = Variables.ToList();
            for (int i = 0; i < changes; ++i)
            {
                for (int j = 0; j < variables; ++j)
                    vars[j].Value = TruthTable[i, j];
                TruthTable[i] = Function.Value;
            }
        }

        public abstract string Execute();
    }
}
