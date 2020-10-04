using System;

namespace Lab5
{
    delegate void GetNumber(out int number, char simbol, int i = -1, int j = -1);

    class NullArrayException : Exception { }

    class Kernel
    {
        public static int[] array1 { get; set; }
        public static int[,] array2 { get; set; }
        public static int[][] array3 { get; set; }

        public static void CheckArray<T>(T array)
        {
            if (array == null)
                throw new NullArrayException();
        }

        public static void Formation1(GetNumber GetNum)
        {
            GetNum(out int n, CLI.c_cN);
            array1 = new int[n];
            for (int i = 0; i < n; ++i)
                GetNum(out array1[i], CLI.c_cA);
        }

        public static void Formation2(GetNumber GetNum)
        {
            GetNum(out int n, CLI.c_cN);
            GetNum(out int m, CLI.c_cM);
            array2 = new int[n, m];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    GetNum(out array2[i, j], CLI.c_cA, i, j);
        }

        public static void Formation3( GetNumber GetNum)
        {
            GetNum(out int n, CLI.c_cN);
            array3 = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                GetNum(out int m, CLI.c_cM);
                array3[i] = new int[m];
                for (int j = 0; j < m; ++j)
                    GetNum(out array3[i][j], CLI.c_cA, i, j);
            }
        }

        public static void Addition1(GetNumber GetNum)
        {
            CheckArray(array1);
            GetNum(out int n, CLI.c_cN);
            GetNum(out int k, CLI.c_cK);
            int[] temp = array1;
            int sizeT = temp.Length;
            int sizeN = sizeT + n;
            array1 = new int[sizeN];
            for (int i = 0; i < k; ++i)
                array1[i] = temp[i];
            for (int i = k, j = k + n; i < j; ++i)
                GetNum(out array1[i], CLI.c_cA, i);
            for (int i = k + n; i < sizeN; ++i)
                array1[i] = temp[i - n];
        }

        public static void DeleteElems2()
        {
            CheckArray(array2);
            int[,] temp = array2;
            int n = array2.GetUpperBound(0) + 1;
            int k = array2.Length / n;
            int m = n / 2;
            array2 = new int[m, k];
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < k; ++j)
                    array2[i, j] = temp[i * 2, j];
        }

        public static void Addition3(GetNumber GetNum)
        {
            CheckArray(array3);
            int[][] temp = array3;
            int n = temp.Length;
            array3 = new int[n + 1][];
            for (int i = 0; i < n; ++i)
                array3[i] = temp[i];
            GetNum(out int m, CLI.c_cM);
            array3[n] = new int[m];
            for (int i = 0; i < m; ++i)
                GetNum(out array3[n][i], CLI.c_cA, n, i);
        }
    }
}
