using System;

//  Variant 14

namespace Task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Example1(GetNum(), GetNum());
            Console.WriteLine("Задание 2");
            Example2(GetNum(), GetNum());
            Console.WriteLine("Задание 3");
            Example3(GetNum(), GetNum());
            Console.WriteLine("Задание 4");
            Example4();
            Console.ReadKey();
        }

        private static void Example1(int n, int m)
        {
            Write(n++ * --m, n, m);
        }

        private static void Example2(int n, int m)
        {
            Write(n-- < m++, n, m);
        }

        private static void Example3(int n, int m)
        {
            Write(--n < --m, n, m);
        }

        private static void Example4()
        {
            int x;
            do x = GetNum();
            while (x == 0);

            Console.WriteLine(Math.Pow(Math.Abs(x + 1), 1 / 4.0) + 1 / Math.Pow(x, 2));
            Console.WriteLine();
        }

        private static void Write <T> (T result, int n, int m)
        {
            Console.WriteLine(result);
            Console.WriteLine(n);
            Console.WriteLine(m);
            Console.WriteLine();
        }

        private static int GetNum()
        {
            int iNum;
            bool flag;
            do
            {
                Console.Write("Введите число (int): ");
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out iNum);
            } while (!flag);
            return iNum;
        }
    }
}
