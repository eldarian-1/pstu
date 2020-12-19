﻿using Entity;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Lab14
{
    internal class ExtensionQuery : IQuery
    {
        public Dictionary<string, IEngine> DictionaryPseudonym { get; set; }

        public IEnumerable<string> SelectPseudonym()
        {
            return DictionaryPseudonym
                .OrderBy(item => item.Key)
                .Select(item => item.Key);
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
            Array.Sort(powers);
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
