using System;

namespace Lab7
{
    class Array2J
    {
        private static int[][] s_iArray = new int[][] {
            new int[] { 1, 2, 3, 4 },
            new int[] { 1, 2, 3 },
            new int[] { 1, 2, 3, 4, 5 }
        };

        private int[][] m_iArray;

        public Array2J()
            => m_iArray = s_iArray;

        public Array2J(int size)
            => m_iArray = new int[size][];

        public int Length
        {
            get => m_iArray.Length;
        }

        public int[] this[int index]
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

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0)
                    throw new Exception();
                return m_iArray[i][j];
            }
            set
            {
                if (i < 0 || j < 0)
                    throw new Exception();
                m_iArray[i][j] = value;
            }
        }

        public void Resize(int n)
        {
            int len = m_iArray.Length;
            int[][] tempArray = m_iArray;
            m_iArray = new int[n][];
            if (len > n)
                for (int i = 0; i < n; ++i)
                    m_iArray[i] = tempArray[i];
            else
            {
                for (int i = 0; i < len; ++i)
                    m_iArray[i] = tempArray[i];
                for (int i = len; i < n; ++i)
                    m_iArray[i] = new int[0];
            }
        }

        public void ResizeByIndex(int index, int m, GetNumber GetNum)
        {
            int len = m_iArray[index].Length;
            int[] tempArray = m_iArray[index];
            m_iArray[index] = new int[m];
            if (len > m)
                for (int i = 0; i < m; ++i)
                    m_iArray[index][i] = tempArray[i];
            else
            {
                for (int i = 0; i < len; ++i)
                    m_iArray[index][i] = tempArray[i];
                for (int i = len; i < m; ++i)
                    GetNum(out m_iArray[index][i]);
            }
        }

        public void AddLine()
        {
            int[][] temp = m_iArray;
            int n = temp.Length;
            m_iArray = new int[n + 1][];
            for (int i = 0; i < n; ++i)
                m_iArray[i] = temp[i];
            m_iArray[n] = new int[0];
        }
    }
}
