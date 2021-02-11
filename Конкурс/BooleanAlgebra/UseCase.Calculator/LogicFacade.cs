using Model.Logic;
using Model.Entities;
using System.Collections.ObjectModel;

namespace UseCase.Calculator
{
    public class LogicFacade :
        LogicFacade<
            VariableVisual,
            Function,
            ObservableCollection<VariableVisual>,
            ObservableCollection<Function>>
    {
        public string RunFunction() => RunFunction<ResultFormater>();
    }
}
