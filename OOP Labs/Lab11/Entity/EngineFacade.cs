namespace Entity
{
    public class EngineFacade
    {
        private IEngine[] m_Engines;
        private Generator m_Generator;
        private IQuery m_Query1;
        private IQuery m_Query2;
        private IQuery m_Query3;

        public EngineFacade()
        {
            m_Generator = new Generator();
            m_Query1 = new Query1();
            m_Query2 = new Query2();
            m_Query3 = new Query3();
        }

        public IEngine[] Engines
        {
            get
            {
                if (m_Engines == null)
                    Generate();
                return m_Engines;
            }
        }

        public void Generate()
            => m_Generator.Run(out m_Engines);

        public void RunQuery1()
            => m_Query1.Run(Engines);

        public void RunQuery2()
            => m_Query2.Run(Engines);

        public void RunQuery3()
            => m_Query3.Run(Engines);
    }
}
