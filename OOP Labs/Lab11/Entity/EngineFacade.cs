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

        public EngineFacade()
        {
            m_Generator = new Generator();
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

        private void Run<TQuery>(TQuery query, IEngine[] engines)
            where TQuery : IQuery, new()
        {
            query.Run(engines);
        }

        public void RunQuery1(IEngine[] engines)
        {
            Run(new Query1(), engines);
        }

        public void RunQuery2(IEngine[] engines)
        {
            Run(new Query2(), engines);
        }

        public void RunQuery3(IEngine[] engines)
        {
            Run(new Query3(), engines);
        }
    }
}
