using Entity;
using System.Collections.Generic;

namespace Lab14
{
    internal class TestCollections
    {
        protected Stack<IEngine> StackBaseEngine { get; private set; }

        protected Stack<string> StackPseudonymEngine { get; private set; }

        protected Dictionary<string, IEngine> DictionaryPseudonym { get; private set; }

        protected Dictionary<IEngine, IEngine> DictionaryBaseEngine { get; private set; }

        public TestCollections()
        {
            Generate(0);
        }

        public TestCollections(int count)
        {
            Generate(count);
        }

        protected TestCollections(TestCollections collections)
        {
            StackBaseEngine = collections.StackBaseEngine;
            StackPseudonymEngine = collections.StackPseudonymEngine;
            DictionaryPseudonym = collections.DictionaryPseudonym;
            DictionaryBaseEngine = collections.DictionaryBaseEngine;
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
            StackBaseEngine = new Stack<IEngine>();
            StackPseudonymEngine = new Stack<string>();
            DictionaryPseudonym = new Dictionary<string, IEngine>();
            DictionaryBaseEngine = new Dictionary<IEngine, IEngine>();

            IEngine[] engines = EngineFacade.Instance.GenerateArray(count);
            string[] pseudonyms = EngineFacade.Instance.GeneratePseudonymArray(count, true);

            foreach (IEngine engine in engines)
                StackBaseEngine.Push(engine.BaseEngine);
            foreach (string pseudonym in pseudonyms)
                StackPseudonymEngine.Push(pseudonym);
            IEngine[] baseEngines = StackBaseEngine.ToArray();
            for (int i = 0; i < count; ++i)
            {
                DictionaryPseudonym.Add(pseudonyms[i], engines[i]);
                DictionaryBaseEngine.Add(baseEngines[i], engines[i]);
            }
        }

        public IQueryCollections QueryCollections(bool linq)
        {
            IQueryCollections result;
            if (linq)
                result = new LinqCollections(this);
            else
                result = new ExtensionCollections(this);
            return result;
        }
    }
}
