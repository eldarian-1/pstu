using System;

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
        private EngineFinder m_EngineFinder;

        public EngineFacade()
        {
            m_Generator = new Generator();
            m_CompareByPower = new CompareByPower();
            m_EngineFinder = new EngineFinder();
        }

        public IEngine Generate()
        {
            m_Generator.Run(out IEngine engine);
            return engine;
        }

        public IEngine[] GenerateArray()
        {
            m_Generator.Run(out IEngine[] engines);
            return engines;
        }

        public void SortingByIndex(IEngine[] engines)
        {
            Array.Sort(engines);
        }

        public void SortingByPower(IEngine[] engines)
        {
            Array.Sort(engines, m_CompareByPower);
        }

        public int FindByIndex(IEngine[] engines, int key)
        {
            return m_EngineFinder.FindByIndex(engines, key);
        }

        public int FindByPower(IEngine[] engines, int key)
        {
            return m_EngineFinder.FindByPower(engines, key);
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
