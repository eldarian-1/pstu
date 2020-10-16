using System;

namespace Lab9
{
    class MoneyArray
    {
        private Money[] m_maWads = null;

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

        public int Length
        {
            get
            {
                if (m_maWads == null)
                    throw new ArgumentException();
                return m_maWads.Length;
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
