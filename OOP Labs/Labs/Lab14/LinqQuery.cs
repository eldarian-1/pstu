using Entity;
using System.Linq;
using System.Collections.Generic;

namespace Lab14
{
    internal class LinqQuery : IQuery
    {
        public Dictionary<string, IEngine> DictionaryPseudonym { get; set; }

        public IEnumerable<string> SelectPseudonym()
        {
            return from item in DictionaryPseudonym
                   orderby item.Key
                   select item.Key;
        }

        public int CountDiesel()
        {
            return (from item in DictionaryPseudonym
                    where EngineFacade.Instance.IsDiesel(item.Value)
                    orderby item.Value.Index
                    select item.Value)
                    .Count();
        }

        public double AveragePower()
        {
            return (from item in DictionaryPseudonym
                    orderby item.Value.Index
                    select item.Value.Power)
                    .Average();
        }

        public int MedianPower()
        {
            var powers = (from item in DictionaryPseudonym
                          orderby item.Value.Index
                          select item.Value.Power).ToArray();
            int median = powers.Count() / 2;
            return powers[median];
        }

        public IEnumerable<string> InternalReactive()
        {
            var internals = from item in DictionaryPseudonym
                            where EngineFacade.Instance.IsInternal(item.Value)
                            orderby item.Value.Index
                            select item.Value.Name;
            var reactives = from item in DictionaryPseudonym
                            where EngineFacade.Instance.IsReactive(item.Value)
                            orderby item.Value.Index
                            select item.Value.Name;
            return internals.Union(reactives);
        }
    }
}
