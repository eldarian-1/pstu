namespace Logic
{
    class TruthTable
    {
        private bool[,] m_Values;
        private bool[] m_Results;
        public int Variables { get; }
        public int Changes { get; }

        public TruthTable(int variables, int changes)
        {
            Variables = variables;
            Changes = changes;
            m_Values = new bool[changes, variables];
            m_Results = new bool[changes];
        }

        public bool this[int change]
        {
            get => m_Results[change];
            set => m_Results[change] = value;
        }

        public bool this[int change, int variable]
        {
            get => m_Values[change, variable];
            set => m_Values[change, variable] = value;
        }
    }
}
