using System.Collections.Generic;

namespace Lab14
{
    internal interface IQueryCollections
    {
        IEnumerable<string> SelectPseudonym();

        int CountDiesel();

        double AveragePower();

        int MedianPower();

        IEnumerable<string> InternalReactive();
    }
}
