using System;
using System.IO;

namespace Lab7
{
    delegate void GetNumber(out int num);

    static class Kernel
    {
        private static Random s_Rand = new Random();
        public static GetNumber GetRand = (out int num) => num = s_Rand.Next(-999, 999);
        public static GetNumber GetNull = (out int num) => num = 0;

        private static void SetByteArray(byte[] array, int pos, int num)
        {
            byte[] numA = BitConverter.GetBytes(num);
            pos *= 4;
            for (int i = 0; i < 4; ++i)
                array[pos + i] = numA[i];
        }

        private static int IntFromByteArray(byte[] array, int pos)
            => BitConverter.ToInt32(array, pos * 4);

        public static void SaveToFile(string file, Array1D array1D, Array2D array2D, Array2J array2J)
        {
            using (FileStream fstream = new FileStream(file, FileMode.OpenOrCreate))
            {
                int Sum = 16,
                    n1d = array1D.Length,
                    n2d = array2D.N,
                    m2d = array2D.M,
                    n2j = array2J.Length;
                int[] m2j = new int[n2j];
                for (int i = 0; i < n2j; ++i)
                {
                    m2j[i] = array2J[i].Length;
                    Sum += m2j[i] * 4;
                }
                Sum += (n1d + n2d + m2d + n2j) * 4;

                byte[] A = new byte[Sum];
                SetByteArray(A, 0, n1d);
                SetByteArray(A, 1, n2d);
                SetByteArray(A, 2, m2d);
                SetByteArray(A, 3, n2j);
                for (int i = 0; i < n2j; ++i)
                    SetByteArray(A, 4 + i, m2j[i]);
                for (int i = 0; i < n1d; ++i)
                    SetByteArray(A, 4 + n2j + i, array1D[i]);
                for (int i = 0; i < n2d; ++i)
                    for (int j = 0; j < m2d; ++j)
                        SetByteArray(A, 4 + n2j + n1d + i + j, array2D[i, j]);
                for (int i = 0; i < n2j; ++i)
                    for (int j = 0; j < m2j[i]; ++j)
                        SetByteArray(A, 4 + n2j + n1d + n2d + m2d + i + j, array2J[i][j]);

                fstream.Write(A, 0, Sum);
                fstream.Close();
            }
        }

        public static void LoadFromFile(string file, out Array1D array1D, out Array2D array2D, out Array2J array2J)
        {
            using (FileStream fstream = new FileStream(file, FileMode.OpenOrCreate))
            {
                byte[] A = new byte[fstream.Length];
                fstream.Read(A, 0, A.Length);
                int n1d = IntFromByteArray(A, 0);
                int n2d = IntFromByteArray(A, 1);
                int m2d = IntFromByteArray(A, 2);
                int n2j = IntFromByteArray(A, 3);
                int[] m2j = new int[n2j];
                for (int i = 0; i < n2j; ++i)
                    m2j[i] = IntFromByteArray(A, 4 + i);
                array1D = new Array1D(n1d);
                array2D = new Array2D(n2d, m2d);
                array2J = new Array2J(n2j);
                for (int i = 0; i < n1d; ++i)
                    array1D[i] = IntFromByteArray(A, 4 + n2j + i);
                for (int i = 0; i < n2d; ++i)
                    for (int j = 0; j < m2d; ++j)
                        array2D[i, j] = IntFromByteArray(A, 4 + n2j + n1d + i + j);
                for (int i = 0; i < n2j; ++i)
                {
                    array2J[i] = new int[m2j[i]];
                    for (int j = 0; j < m2j[i]; ++j)
                        array2J[i, j] = IntFromByteArray(A, 4 + n2j + n1d + n2d + m2d + i + j);
                }
                fstream.Close();
            }
        }
    }
}
