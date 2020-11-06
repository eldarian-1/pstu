using System;
using Entity;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lab11
{
    internal class TestCollections
    {
        private const string c_sByIndexList = "по индексу в списке ";
        private const string c_sByIndexEngine = "по индексу двигателя ";
        private const string c_sByPower = "по мощности двигателя ";
        private const string c_sByPseudonym = "по псевдониму двигателя ";
        private const string c_sNonIncluded = "не включенного двигателя ";

        public Exception NotFound { get; } = new Exception("Двигатель не существует");

        private Stack<IEngine> m_StackBaseEngine;
        private Stack<string> m_StackPseudonymEngine;
        private Dictionary<string, IEngine> m_DictionaryPseudonym;
        private Dictionary<IEngine, IEngine> m_DictionaryBaseEngine;
        private Stopwatch m_Stopwatch;

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

        private void StartTimer()
        {
            if (m_Stopwatch == null)
                m_Stopwatch = new Stopwatch();
            else
                m_Stopwatch.Reset();
            m_Stopwatch.Start();
        }

        private long StopTimer()
        {
            m_Stopwatch.Stop();
            return m_Stopwatch.ElapsedTicks;
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

        private bool Find<TCollection, TValue>
            (TCollection collection, TValue element, out long ticks)
            where TCollection : Stack<TValue>
        {
            StartTimer();
            bool isFinded = collection.Contains(element);
            ticks = StopTimer();
            return isFinded;
        }

        private void FindKey<TCollection, TRequired, TOther>
            (TCollection collection, TRequired key, TOther other, out long ticks)
            where TCollection : Dictionary<TRequired, TOther>
        {
            StartTimer();
            collection.ContainsKey(key);
            ticks = StopTimer();
        }

        private void FindValue<TCollection, TRequired, TOther>
            (TCollection collection, TRequired value, TOther other, out long ticks)
            where TCollection : Dictionary<TOther, TRequired>
        {
            StartTimer();
            collection.ContainsValue(value);
            ticks = StopTimer();
        }

        private string ToStringResult(string byWhat, bool isFinded, long[] ticks)
        {
            if (ticks.Length == 6)
                return
                    $"Результат нахождения: {isFinded}\n" +
                    $"Время нахождения {byWhat}:\n" +
                    $"StackBaseEngine - {ticks[0]} ticks\n" +
                    $"StackPseudonymEngine - {ticks[1]} ticks\n" +
                    $"DictionaryPseudonym by key - {ticks[2]} ticks\n" +
                    $"DictionaryPseudonym by value - {ticks[3]} ticks\n" +
                    $"DictionaryBaseEngine by key - {ticks[4]} ticks\n" +
                    $"DictionaryBaseEngine by value - {ticks[5]} ticks";
            else if (ticks.Length == 2)
                return
                    $"Результат нахождения: {isFinded}\n" +
                    $"Время нахождения {byWhat}:\n" +
                    $"StackPseudonymEngine - {ticks[0]} ticks\n" +
                    $"DictionaryPseudonym by key - {ticks[1]} ticks";
            else
                return "";
        }

        public string Find(
            string requiredPseudonym,
            IEngine requiredEngine,
            IEngine requiredBaseEngine,
            string byWhat)
        {
            long[] ticks = new long[6];
            bool isFinded = Find(m_StackBaseEngine, requiredBaseEngine, out ticks[0]);
            Find(m_StackPseudonymEngine, requiredPseudonym, out ticks[1]);
            FindKey(m_DictionaryPseudonym, requiredPseudonym, (IEngine)null, out ticks[2]);
            FindValue(m_DictionaryPseudonym, requiredEngine, "", out ticks[3]);
            FindKey(m_DictionaryBaseEngine, requiredBaseEngine, (IEngine)null, out ticks[4]);
            FindValue(m_DictionaryBaseEngine, requiredEngine, (IEngine)null, out ticks[5]);
            return ToStringResult(byWhat, isFinded, ticks);
        }

        public string FindByIndexList(int index, string byWhat = "")
        {
            IEngine[] baseEngines = m_StackBaseEngine.ToArray();
            if (baseEngines.Length <= index || index < 0)
                throw NotFound;
            IEngine requiredBaseEngine = baseEngines[index];
            string requiredPseudonym = m_StackPseudonymEngine.ToArray()[index];
            IEngine requiredEngine = m_DictionaryPseudonym.Values.ToArray()[index];
            return Find(
                requiredPseudonym,
                requiredEngine,
                requiredBaseEngine,
                byWhat == "" ? c_sByIndexList + index : byWhat);
        }

        public string FindByIndexEngine(int indexEngine)
        {
            int indexList = -1;
            IEngine[] engines = m_DictionaryPseudonym.Values.ToArray();
            for (int i = 0, n = engines.Count(); i < n; ++i)
                if (engines[i].Index == indexEngine)
                {
                    indexList = i;
                    break;
                }
            return FindByIndexList(indexList, c_sByIndexEngine + indexEngine);
        }

        public string FindByPower(int power)
        {
            int index = -1;
            IEngine[] engines = m_DictionaryPseudonym.Values.ToArray();
            for (int i = 0, n = engines.Count(); i < n; ++i)
                if (engines[i].Power == power)
                {
                    index = i;
                    break;
                }
            return FindByIndexList(index, c_sByPower + power);
        }

        public string FindByPseudonym(string pseudonym)
        {
            long[] ticks = new long[2];
            bool isFinded = Find(m_StackPseudonymEngine, pseudonym, out ticks[0]);
            FindKey(m_DictionaryPseudonym, pseudonym, (IEngine)null, out ticks[1]);
            return ToStringResult(c_sByPseudonym + pseudonym, isFinded, ticks);
        }

        public string FindFirst()
        {
            return FindByIndexList(0);
        }

        public string FindCenter()
        {
            return FindByIndexList(m_StackBaseEngine.Count / 2);
        }

        public string FindLast()
        {
            return FindByIndexList(m_StackBaseEngine.Count - 1);
        }

        public string FindNonIncluded()
        {
            string pseudonym = EngineFacade.Instance.GeneratePseudonym(true);
            IEngine engine = EngineFacade.Instance.Generate();
            return Find(pseudonym, engine, engine.BaseEngine,
                c_sNonIncluded + $"{engine.Name}-{pseudonym} [{engine.Power} HP]");
        }
    }
}
