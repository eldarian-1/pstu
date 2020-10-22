using System;

namespace Lab5
{
    delegate void GetNumber(out int number, char simbol, int i = -1, int j = -1);
    delegate GetNumber ModeGetNumber();
    delegate bool IsValidate(int x, int top);

    class NullArrayException : Exception { }
    class CleanArrayException : Exception { }
    class BadSizeArray : Exception { }
    class NullFunctionException : Exception { }

    class Kernel
    {
        public static int[] array1D { get; set; }
        public static int[,] array2D { get; set; }
        public static int[][] arrayRagged { get; set; }
        private static IsValidate IsValid = (x, top) => (x >= 0 && x <= top);

        // Получение валидного числа
        private static void GetValid(out int number, GetNumber GetNum, char simbol, int top)
        {
            while (true)
            {
                GetNum(out number, simbol);
                if (IsValid(number, top))
                    break;
                else
                    CLI.IncorrectValue();
            }
        }

        public static void CheckArray<T>(T array)
        {
            if (array == null)
                throw new NullArrayException();
        }

        public static void Formation1D(GetNumber GetNum)
        {
            GetValid(out int n, GetNum, CLI.c_cN, CLI.c_iMaxInt);
            array1D = new int[n];
            for (int i = 0; i < n; ++i)
                GetNum(out array1D[i], CLI.c_cA, i);
        }

        public static void Formation2D(GetNumber GetNum)
        {
            GetValid(out int n, GetNum, CLI.c_cN, CLI.c_iMaxInt);
            GetValid(out int m, GetNum, CLI.c_cM, CLI.c_iMaxInt);
            array2D = new int[n, m];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    GetNum(out array2D[i, j], CLI.c_cA, i, j);
        }

        public static void FormationRagged(GetNumber GetNum)
        {
            GetValid(out int n, GetNum, CLI.c_cN, CLI.c_iMaxInt);
            arrayRagged = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                GetValid(out int m, GetNum, CLI.c_cM, CLI.c_iMaxInt);
                arrayRagged[i] = new int[m];
                for (int j = 0; j < m; ++j)
                    GetNum(out arrayRagged[i][j], CLI.c_cA, i, j);
            }
        }

        // Добавление N элементов после K элемента в одномерный массив
        public static void Addition(ModeGetNumber Mode)
        {
            CheckArray(array1D);
            GetNumber GetNum = Mode();
            int oldSize = array1D.Length;
            GetValid(out int n, GetNum, CLI.c_cN, CLI.c_iMaxInt - oldSize);
            GetValid(out int k, GetNum, CLI.c_cK, oldSize - 1);
            int newSize = oldSize + n;
            int[] temp = array1D;
            array1D = new int[newSize];
            for (int i = 0; i < k; ++i)
                array1D[i] = temp[i];
            for (int i = k, j = k + n; i < j; ++i)
                GetNum(out array1D[i], CLI.c_cA, i);
            for (int i = k + n; i < newSize; ++i)
                array1D[i] = temp[i - n];
        }

        // Удаление четных столбцов в двумерном массиве
        public static void DeleteEven()
        {
            CheckArray(array2D);
            int[,] temp = array2D;
            int n = array2D.GetUpperBound(0) + 1;
            if (n == 0)
                throw new BadSizeArray();
            int k = array2D.Length / n;
            int m = n / 2;
            array2D = new int[m, k];
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < k; ++j)
                    array2D[i, j] = temp[i * 2 + 1, j];
            if(array2D.Length == 0)
            {
                array2D = null;
                throw new CleanArrayException();
            }
        }

        // Добавление строки в конец рваного массива
        public static void AdditionLine(ModeGetNumber Mode)
        {
            CheckArray(arrayRagged);
            GetNumber GetNum = Mode();
            int[][] temp = arrayRagged;
            int n = temp.Length;
            arrayRagged = new int[n + 1][];
            for (int i = 0; i < n; ++i)
                arrayRagged[i] = temp[i];
            GetValid(out int m, GetNum, CLI.c_cM, CLI.c_iMaxInt);
            arrayRagged[n] = new int[m];
            for (int i = 0; i < m; ++i)
                GetNum(out arrayRagged[n][i], CLI.c_cA, n, i);
        }
    }
}
