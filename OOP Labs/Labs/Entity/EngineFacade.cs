using System;
using System.Collections.Generic;

namespace Entity
{
    public class EngineFacade
    {
        private static EngineFacade m_Instance;

        public static EngineFacade Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new EngineFacade();
                return m_Instance;
            }
        }

        private Generator m_Generator;
        private CompareByPower m_CompareByPower;
        private CompareByIndexD m_CompareByIndexD;
        private CompareByPowerD m_CompareByPowerD;
        private CompareByPseudonymD m_CompareByPseudonymD;
        private EngineFinder m_EngineFinder;

        public EngineFacade()
        {
            m_Generator = new Generator();
            m_CompareByPower = new CompareByPower();
            m_CompareByIndexD = new CompareByIndexD();
            m_CompareByPowerD = new CompareByPowerD();
            m_CompareByPseudonymD = new CompareByPseudonymD();
            m_EngineFinder = new EngineFinder();
        }

        public bool IsInternal(IEngine engine) => engine is InternalCombustionEngine;

        public bool IsDiesel(IEngine engine) => engine is DieselEngine;

        public bool IsReactive(IEngine engine) => engine is TurboReactiveEngine;

        public double[] GenerateDouble(int count)
        {
            m_Generator.Run(out double[] array, count);
            return array;
        }

        public int[] GenerateInt(int count)
        {
            m_Generator.Run(out int[] array, count);
            return array;
        }

        public IEngine Generate()
        {
            m_Generator.Run(out IEngine engine);
            return engine;
        }

        public IEngine[] GenerateArray(int count = -1)
        {
            m_Generator.Run(out IEngine[] engines, count);
            return engines;
        }

        public string GeneratePseudonym(bool isBig = false)
        {
            m_Generator.Run(out string pseudonym, isBig);
            return pseudonym;
        }

        public string[] GeneratePseudonymArray(int count, bool isBig = false)
        {
            m_Generator.Run(out string[] pseudonyms, count, isBig);
            return pseudonyms;
        }

        public void SortingByIndex(IEngine[] engines)
        {
            Array.Sort(engines);
        }

        public void SortingByPower(IEngine[] engines)
        {
            Array.Sort(engines, m_CompareByPower);
        }

        public void SortingByIndex(KeyValuePair<string, IEngine>[] engines)
        {
            Array.Sort(engines, m_CompareByIndexD);
        }

        public void SortingByPower(KeyValuePair<string, IEngine>[] engines)
        {
            Array.Sort(engines, m_CompareByPowerD);
        }

        public void SortingByPseudonym(KeyValuePair<string, IEngine>[] engines)
        {
            Array.Sort(engines, m_CompareByPseudonymD);
        }

        public int FindByIndex(IEngine[] engines, int key)
        {
            return m_EngineFinder.FindByIndex(engines, key);
        }

        public int FindByPower(IEngine[] engines, int key)
        {
            return m_EngineFinder.FindByPower(engines, key);
        }

        public string FindByPseudonym(string[] pseudonyms, string key)
        {
            return m_EngineFinder.FindByPseudonym(pseudonyms, key);
        }

        private string Run<TQuery>(TQuery query, IEngine[] engines)
            where TQuery : IQuery, new()
        {
            return query.Run(engines);
        }

        public string RunQuery1(IEngine[] engines)
        {
            return Run(new Query1(), engines);
        }

        public string RunQuery2(IEngine[] engines)
        {
            return Run(new Query2(), engines);
        }

        public string RunQuery3(IEngine[] engines)
        {
            return Run(new Query3(), engines);
        }
    }
}
