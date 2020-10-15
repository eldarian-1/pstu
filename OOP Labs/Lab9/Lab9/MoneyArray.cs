using System;

namespace Lab9
{
    class MoneyArray
    {
        private Money[] m_maWads;
        private int m_iSize;

        public MoneyArray()
        {
            m_maWads = null;
            m_iSize = 0;
        }

        public MoneyArray(GetNumber GetNum)
        {
            GetNum(out m_iSize, Program.c_cN);
            m_maWads = new Money[m_iSize];
            for (int i = 0; i < m_iSize; ++i)
            {
                GetNum(out int rubles, Program.c_cR, i);
                GetNum(out int pennies, Program.c_cP, i);
                m_maWads[i] = new Money(rubles, pennies);
            }
        }

        public static MoneyArray Get(ModeGetNumber GetMode)
        {
            return new MoneyArray(GetMode());
        }

        public Money this [int index]
        {
            get
            {
                if (index < 0 || index >= m_iSize)
                    throw new ArgumentException();
                return m_maWads[index];
            }
            set
            {
                if (index < 0 || index >= m_iSize)
                    throw new ArgumentException();
                m_maWads[index] = value;
            }
        }

        public int GetMinimum()
        {
            if (m_iSize == 0)
                throw new InvalidOperationException();
            Money mMin = m_maWads[0];
            int iMin = 0;
            for (int i = 1; i < m_iSize; ++i)
                if (mMin > m_maWads[i])
                {
                    mMin = m_maWads[i];
                    iMin = i;
                }
            return iMin;
        }
    }
}
