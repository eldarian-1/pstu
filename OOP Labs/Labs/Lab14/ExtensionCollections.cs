using Entity;
using System.Linq;
using System.Collections.Generic;

namespace Lab14
{
    internal class ExtensionCollections : TestCollections, IQueryCollections
    {
        public ExtensionCollections(TestCollections collections)
            : base(collections) { }

        public IEnumerable<string> SelectPseudonym()
        {
            return StackPseudonymEngine
                .OrderBy(item => item)
                .Select(item => item);
        }

        public int CountDiesel()
        {
            return DictionaryPseudonym
                .Where(item => EngineFacade.Instance.IsDiesel(item.Value))
                .OrderBy(item => item.Value.Index)
                .Select(item => item.Value)
                .Count();
        }

        public double AveragePower()
        {
            return DictionaryPseudonym
                .OrderBy(item => item.Value.Index)
                .Select(item => item.Value.Power)
                .Average();
        }

        public int MedianPower()
        {
            var powers = DictionaryPseudonym
                .OrderBy(item => item.Value.Index)
                .Select(item => item.Value.Power)
                .ToArray();
            int median = powers.Count() / 2;
            return powers[median];
        }

        public IEnumerable<string> InternalReactive()
        {
            var internals = DictionaryPseudonym
                .Where(item => EngineFacade.Instance.IsInternal(item.Value))
                .OrderBy(item => item.Value.Index)
                .Select(item => item.Value.Name);
            var reactives = DictionaryPseudonym
                .Where(item => EngineFacade.Instance.IsReactive(item.Value))
                .OrderBy(item => item.Value.Index)
                .Select(item => item.Value.Name);
            return internals.Union(reactives);
        }
    }
}
