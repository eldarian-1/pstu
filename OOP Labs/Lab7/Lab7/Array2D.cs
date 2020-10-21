using System;

namespace Lab7
{
    class Array2D
    {
        private static int[,] s_iArray = new int[3, 4] {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 }
        };

        private int[,] m_iArray;

        public Array2D()
            => m_iArray = s_iArray;

        public Array2D(int n, int m)
            => m_iArray = new int[n, m];

        public int N
        {
            get => m_iArray.GetUpperBound(0) + 1;
        }

        public int M
        {
            get
            {
                if (N == 0)
                    throw new Exception();
                return m_iArray.Length / N;
            }
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0)
                    throw new Exception();
                return m_iArray[i, j];
            }
            set
            {
                if (i < 0 || j < 0)
                    throw new Exception();
                m_iArray[i, j] = value;
            }
        }

        public void Resize(int n, int m, GetNumber GetNum)
        {
            m_iArray = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    GetNum(out m_iArray[i, j]);
        }

        public void DropEven()
        {
            int[,] temp = m_iArray;
            int n = N;
            int k = M;
            int m = n / 2;
            m_iArray = new int[m, k];
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < k; ++j)
                    m_iArray[i, j] = temp[i * 2 + 1, j];
        }

    }
}
