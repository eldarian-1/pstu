using System;

namespace Logic
{
    public class TruthTable
    {
        private bool[,] m_Values;
        private bool[] m_Results;

        public TruthTable(int variables)
        {
            Variables = variables;
            Changes = (int)Math.Pow(2, variables);
            m_Values = new bool[Changes, variables];
            m_Results = new bool[Changes];
            Initialize();
        }

        private void Initialize()
        {
            int[] devide = new int[Variables];
            for (int i = 0; i < Variables; ++i)
                devide[i] = (int)Math.Pow(2, i);

            for (int i = 0; i < Changes; ++i)
                for (int j = 0; j < Variables; ++j)
                {
                    int num = (i & devide[Variables - 1 - j]) / devide[Variables - 1 - j];
                    this[i, j] = num == 1;
                }
        }

        public int Variables { get; }

        public int Changes { get; }

        public bool this[int change]
        {
            get => m_Results[change];
            set => m_Results[change] = value;
        }

        public bool this[int change, int variable]
        {
            get => m_Values[change, variable];
            protected set => m_Values[change, variable] = value;
        }
    }
}
