using Entity;
using System.Linq;
using System.Collections.Generic;

namespace Lab14
{
    internal class TestCollections
    {
        private Stack<IEngine> m_StackBaseEngine;
        private Stack<string> m_StackPseudonymEngine;
        private Dictionary<string, IEngine> m_DictionaryPseudonym;
        private Dictionary<IEngine, IEngine> m_DictionaryBaseEngine;

        public TestCollections()
        {
            Generate(0);
        }

        public TestCollections(int count)
        {
            Generate(count);
        }

        public override string ToString()
        {
            int i = 0, n = m_DictionaryPseudonym.Count;
            string result = "";
            foreach (var item in m_DictionaryPseudonym)
                result += $"{item.Key}: {item.Value.Name} [{item.Value.Power} HP]" + (i++ < n - 1 ? "\n" : "");
            return result;
        }

        public void Generate(int count)
        {
            m_StackBaseEngine = new Stack<IEngine>();
            m_StackPseudonymEngine = new Stack<string>();
            m_DictionaryPseudonym = new Dictionary<string, IEngine>();
            m_DictionaryBaseEngine = new Dictionary<IEngine, IEngine>();

            IEngine[] engines = EngineFacade.Instance.GenerateArray(count);
            string[] pseudonyms = EngineFacade.Instance.GeneratePseudonymArray(count, true);

            foreach (IEngine engine in engines)
                m_StackBaseEngine.Push(engine.BaseEngine);
            foreach (string pseudonym in pseudonyms)
                m_StackPseudonymEngine.Push(pseudonym);
            IEngine[] baseEngines = m_StackBaseEngine.ToArray();
            for (int i = 0; i < count; ++i)
            {
                m_DictionaryPseudonym.Add(pseudonyms[i], engines[i]);
                m_DictionaryBaseEngine.Add(baseEngines[i], engines[i]);
            }
        }

        private string EnginesToString(IEnumerable<string> engines)
        {
            string result = "";
            foreach (var item in engines)
                result += item + "\n";
            return result;
        }

        public string SelectPseudonym()
        {
            var engines = from pseudonym in m_StackPseudonymEngine
                          orderby pseudonym select pseudonym;
            return EnginesToString(engines);
        }

        public int CountDiesel()
        {
            return (from item in m_DictionaryPseudonym
                    where EngineFacade.Instance.IsDiesel(item.Value)
                    orderby item.Value.Index select item.Value)
                    .Count();
        }

        public double AveragePower()
        {
            return (from item in m_DictionaryPseudonym
                    orderby item.Value.Index
                    select item.Value.Power)
                    .Average();
        }

        public int MedianPower()
        {
            var powers = (from item in m_DictionaryPseudonym
                         orderby item.Value.Index
                         select item.Value.Power).ToArray();
            int median = powers.Count() / 2;
            return powers[median];
        }

        public string InternalReactive()
        {
            var internals = from item in m_DictionaryPseudonym
                            where EngineFacade.Instance.IsInternal(item.Value)
                            orderby item.Value.Index
                            select item.Value.Name;
            var reactives = from item in m_DictionaryPseudonym
                            where EngineFacade.Instance.IsReactive(item.Value)
                            orderby item.Value.Index
                            select item.Value.Name;
            return EnginesToString(internals.Union(reactives));
        }
    }
}
