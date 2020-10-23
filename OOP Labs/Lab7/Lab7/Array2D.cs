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
                    return 0;
                return m_iArray.Length / N;
            }
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= N || j >= M)
                    throw new IncorrectIndex();
                return m_iArray[i, j];
            }
            set
            {
                if (i < 0 || j < 0 || i >= N || j >= M)
                    throw new IncorrectIndex();
                m_iArray[i, j] = value;
            }
        }

        public void Resize(int newN, int newM, GetNumber GetNum)
        {
            if (newN < 0 || newM < 0)
                throw new IncorrectNewSize();
            int oldN = N;
            int oldM = M;
            if (oldN == newN && oldM == newM)
                throw new AlreadySet();

            int[,] temp = m_iArray;
            m_iArray = new int[newN, newM];

            if (oldN > newN)
                for (int i = 0; i < newN; i++)
                    ResizeRow(i, oldM, newM, temp, GetNum);
            else
            {
                for (int i = 0; i < oldN; ++i)
                    ResizeRow(i, oldM, newM, temp, GetNum);
                for (int i = oldN; i < newN; ++i)
                    for (int j = oldM; j < newM; ++j)
                        GetNum(out m_iArray[i, j]);
            }
        }

        private void ResizeRow(int index, int oldM, int newM, int[,] old, GetNumber GetNum)
        {
            if (oldM > newM)
                for (int i = 0; i < newM; i++)
                    m_iArray[index, i] = old[index, i];
            else
            {
                for (int i = 0; i < oldM; ++i)
                    m_iArray[index, i] = old[index, i];
                for (int i = oldM; i < newM; ++i)
                    GetNum(out m_iArray[index, i]);
            }
        }

        public void DropEven()
        {
            int[,] temp = m_iArray;
            int n = N;
            int k = M;

            if (n == 0 && k == 0)
                throw new EmptyArray();

            int m = n / 2;
            m_iArray = new int[m, k];
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < k; ++j)
                    m_iArray[i, j] = temp[i * 2 + 1, j];
        }

    }
}
