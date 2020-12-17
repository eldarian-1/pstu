using Entity;
using System.Collections.Generic;

namespace Lab14
{
    internal class TestCollection
    {
        protected Dictionary<string, IEngine> DictionaryPseudonym { get; private set; }

        public TestCollection()
        {
            Generate(0);
        }

        public TestCollection(int count)
        {
            Generate(count);
        }

        public override string ToString()
        {
            int i = 0, n = DictionaryPseudonym.Count;
            string result = "";
            foreach (var item in DictionaryPseudonym)
                result += $"{item.Key}: {item.Value.Name} [{item.Value.Power} HP]" + (i++ < n - 1 ? "\n" : "");
            return result;
        }

        public void Generate(int count)
        {
            DictionaryPseudonym = new Dictionary<string, IEngine>();
            IEngine[] engines = EngineFacade.Instance.GenerateArray(count);
            string[] pseudonyms = EngineFacade.Instance.GeneratePseudonymArray(count, true);
            for (int i = 0; i < count; ++i)
                DictionaryPseudonym.Add(pseudonyms[i], engines[i]);
        }

        public IQuery QueryCollections(bool linq)
        {
            IQuery result;
            if (linq)
                result = new LinqQuery { DictionaryPseudonym = DictionaryPseudonym};
            else
                result = new ExtensionQuery { DictionaryPseudonym = DictionaryPseudonym };
            return result;
        }
    }
}
