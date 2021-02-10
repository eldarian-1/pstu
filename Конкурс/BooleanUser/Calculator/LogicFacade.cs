using Entity;
using System.Collections.ObjectModel;

namespace Calculator
{
    public class LogicFacade :
        Logic.LogicFacade<
            Variable,
            Function,
            ObservableCollection<Variable>,
            ObservableCollection<Function>>
    {
        public string RunFunction() => RunFunction<ResultFormater>();
    }
}
