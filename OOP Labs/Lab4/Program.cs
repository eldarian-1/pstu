using System;

// Вариант 15

namespace Lab4
{
    class Program
    {
        private static Random s_rand = new Random();

        public static void Main(string[] args)
        {
            Formation(out int[] array, 100);
            Output(array);

            DeleteElems(ref array);
            Output(array);

            Addition(ref array, 5, 7);
            Output(array);

            Reverse(array);
            Output(array);

            FindElem(array, 29);

            InsertSort(array);
            Output(array);

            Console.ReadKey();
        }

        private static void Output(int[] array)
        {
            for (int i = 0, k = array.Length; i < k; ++i)
                Console.Write("{0} ",array[i]);
            Console.WriteLine("\n");
        }

        private static void Formation(out int[] array, int n)
        {
            array = new int[n];
            for (int i = 0; i < n; ++i)
                array[i] = s_rand.Next();
        }

        private static void DeleteElems(ref int[] array)
        {
            int[] temp = array;
            int n = temp.Length / 2;
            array = new int[n];
            for (int i = 0; i < n; ++i)
                array[i] = temp[i * 2];
        }

        private static void Addition(ref int[] array, int n, int k)
        {
            int[] temp = array;
            int sizeT = temp.Length;
            int sizeN = sizeT + n;
            array = new int[sizeN];
            for (int i = 0; i < k; ++i)
                array[i] = temp[i];
            for (int i = k, j = k + n; i < j; ++i)
                array[i] = s_rand.Next();
            for (int i = k + n; i < sizeN; ++i)
                array[i] = temp[i - n];
        }

        private static void Reverse(int[] array)
        {
            int N = array.Length - 1;
            int n = N / 2;
            for (int i = 0; i < n; ++i)
            {
                int temp = array[i];
                array[i] = array[N - i];
                array[N - i] = temp;
            }
        }

        private static void FindElem(int[] array, int k)
        {
            try
            {
                int n = 0;
                while (array[n++] != k) ;
                Console.WriteLine("Элемент найден по индексу {0}", n);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Элемент не найден");
            }
            finally
            {
                Console.WriteLine();
            }
        }

        private static void InsertSort(int[] array)
        {
            int i, j, temp, k = array.Length;
            for (i = 0; i < k; i++)
            {
                temp = array[i];
                for (j = i - 1; j >= 0 && array[j] > temp; j--)
                    array[j + 1] = array[j];
                array[j + 1] = temp;
            }
        }
    }
}
