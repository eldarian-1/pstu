using System;

namespace Lab9
{
    class MoneyArray
    {
        private Money[] m_maWads;

        public MoneyArray()
        {
            m_maWads = null;
        }

        public MoneyArray(Money[] array)
        {
            int len = array.Length;
            m_maWads = new Money[len];
            for (int i = 0; i < len; ++i)
                m_maWads[i] = array[i];
        }

        public Money this [int index]
        {
            get
            {
                if (m_maWads == null || index < 0 || index >= m_maWads.Length)
                    throw new ArgumentException();
                return m_maWads[index];
            }
            set
            {
                if (m_maWads == null || index < 0 || index >= m_maWads.Length)
                    throw new ArgumentException();
                m_maWads[index] = value;
            }
        }

        public int Minimum
        {
            get
            {
                if (m_maWads == null)
                    throw new InvalidOperationException();
                int len = m_maWads.Length;
                if (len == 0)
                    throw new InvalidOperationException();
                Money mMin = m_maWads[0];
                int iMin = 0;
                for (int i = 1; i < len; ++i)
                    if (mMin > m_maWads[i])
                    {
                        mMin = m_maWads[i];
                        iMin = i;
                    }
                return iMin;
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0, n = m_maWads.Length; i < n; ++i)
                result += " " + m_maWads[i];
            return result;
        }
    }
}
