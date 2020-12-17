using Entity;
using System.Collections.Generic;

namespace Lab14
{
    internal interface IQuery
    {
        Dictionary<string, IEngine> DictionaryPseudonym { get; }

        IEnumerable<string> SelectPseudonym();

        int CountDiesel();

        double AveragePower();

        int MedianPower();

        IEnumerable<string> InternalReactive();
    }
}
