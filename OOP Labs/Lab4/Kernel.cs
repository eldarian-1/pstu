using System;

namespace Lab4
{
    delegate void GetNumber(out int number, char simbol, int i = -1);
    delegate GetNumber ModeGetNumber();
    delegate bool IsValidate(int x, int top);

    class NullArrayException : Exception { }
    class CleanArrayException : Exception { }
    class NullFunctionException : Exception { }
    class NotFoundException : Exception { }
    class NotSortedException : Exception { }
    class FoundElemException : Exception
    {
        public int N { get; set; }
        public FoundElemException(int n) { N = n; }
    }

    class Kernel
    {
        public static int[] array { get; set; }
        private static bool isSorted = false;
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

        public static void CheckArray()
        {
            if (array == null)
                throw new NullArrayException();
        }

        // Создание массива
        public static void Formation(GetNumber GetNum)
        {
            GetValid(out int n, GetNum, CLI.c_cN, CLI.c_iMaxInt);
            array = new int[n];
            for (int i = 0; i < n; ++i)
                GetNum(out array[i], CLI.c_cA, i);
            isSorted = false;
        }

        // Удаление всех элементов с четными индексами
        public static void DeleteElems()
        {
            CheckArray();
            int[] temp = array;
            int n = temp.Length / 2;
            array = new int[n];
            for (int i = 0; i < n; ++i)
                array[i] = temp[i * 2 + 1];
            if (array.Length == 0)
            {
                array = null;
                throw new CleanArrayException();
            }
        }

        // Добавление n элементов, начиная с k
        public static void Addition(ModeGetNumber ModeGetNum)
        {
            CheckArray();
            GetNumber GetNum = ModeGetNum();
            int oldSize = array.Length;
            GetValid(out int n, GetNum, CLI.c_cN, CLI.c_iMaxInt - oldSize);
            GetValid(out int k, GetNum, CLI.c_cK, oldSize - 1);
            int newSize = oldSize + n;
            int[] temp = array;
            array = new int[newSize];
            for (int i = 0; i < k; ++i)
                array[i] = temp[i];
            for (int i = k, j = k + n; i < j; ++i)
                GetNum(out array[i], CLI.c_cA, i);
            for (int i = k + n; i < newSize; ++i)
                array[i] = temp[i - n];
            isSorted = false;
        }

        // Переворот массива
        public static void Reverse()
        {
            CheckArray();
            int N = array.Length - 1;
            int n = N / 2;
            for (int i = 0; i < n; ++i)
            {
                int temp = array[i];
                array[i] = array[N - i];
                array[N - i] = temp;
            }
            isSorted = false;
        }

        // Поиск элемента по значению
        public static void BinarySearch(ModeGetNumber ModeGetNum)
        {
            CheckArray();
            if (!isSorted)
                throw new NotSortedException();
            GetNumber GetNum = ModeGetNum();
            GetNum(out int key, CLI.c_cK);
            int mid, left = 0, right = array.Length - 1;
            while (true)
            {
                if(left > right)
                    throw new NotFoundException();
                mid = left + (right - left) / 2;
                if (key > array[mid])
                    left = mid + 1;
                else if (key < array[mid])
                    right = mid - 1;
                else
                    throw new FoundElemException(mid);
            }
        }

        // Сортировка вставками
        public static void InsertSort()
        {
            CheckArray();
            int i, j, temp, n = array.Length;
            for (i = 0; i < n; i++)
            {
                temp = array[i];
                for (j = i - 1; j >= 0 && array[j] > temp; j--)
                    array[j + 1] = array[j];
                array[j + 1] = temp;
            }
            isSorted = true;
        }
    }
}
