using System;

namespace Lab7
{
    class Array1D
    {
        private static int[] s_iArray
            = new int[] { 13, 14, 15 };

        private int[] m_iArray;

        public Array1D()
            => m_iArray = s_iArray;

        public Array1D(int size)
            => m_iArray = new int[size];

        public int Length
        {
            get => m_iArray.Length;
        }

        public int this[int index]
        {
            get
            {
                if (index < 0)
                    throw new Exception();
                return m_iArray[index];
            }
            set
            {
                if (index < 0)
                    throw new Exception();
                m_iArray[index] = value;
            }
        }

        public void Resize(int size, GetNumber GetNum)
        {
            m_iArray = new int[size];
            for (int i = 0; i < size; i++)
                GetNum(out m_iArray[i]);
        }

        public void AddLine(int n, int k, GetNumber GetNum)
        {
            int oldSize = m_iArray.Length;
            int newSize = oldSize + n;
            if (k > oldSize || oldSize >= newSize)
                throw new Exception();
            int[] temp = m_iArray;
            m_iArray = new int[newSize];
            for (int i = 0; i < k; ++i)
                m_iArray[i] = temp[i];
            for (int i = k, j = k + n; i < j; ++i)
                GetNum(out m_iArray[i]);
            for (int i = k + n; i < newSize; ++i)
                m_iArray[i] = temp[i - n];
        }
    }
}
