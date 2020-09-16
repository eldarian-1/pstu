using System;

//  Variant 14

namespace Task3
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(Run(GetDouble(), GetDouble()));
            //Console.WriteLine(Run(GetFloat(), GetFloat()));
            Console.WriteLine(Run(10.0d, 0.01d));
            Console.WriteLine(Run(10.0f, 0.01f));
            Console.ReadKey();
        }

        private static double Run(double a, double b)
        {
            return (Pow(a + b, 4) - (Pow(a, 4) + 6 * Pow(a, 2) * Pow(b, 2) + Pow(b, 4)))
                / (4 * a * Pow(b, 3) + 4 * b * Pow(a, 3));
        }

        private static float Run(float a, float b)
        {
            return (Pow(a + b, 4) - (Pow(a, 4) + 6 * Pow(a, 2) * Pow(b, 2) + Pow(b, 4)))
                / (4 * a * Pow(b, 3) + 4 * b * Pow(a, 3));
        }

        private static float GetFloat()
        {
            float fNum;
            bool flag;
            do
            {
                Console.Write("Введите число (double): ");
                string sNum = Console.ReadLine();
                flag = float.TryParse(sNum, out fNum);
            } while (!flag);
            return fNum;
        }

        private static double GetDouble()
        {
            double dNum;
            bool flag;
            do
            {
                Console.Write("Введите число (double): ");
                string sNum = Console.ReadLine();
                flag = double.TryParse(sNum, out dNum);
            } while (!flag);
            return dNum;
        }

        private static double Pow(double a, int b)
        {
            while (--b > 0)
                a *= a;
            return a;
        }

        private static float Pow(float a, int b)
        {
            while (--b > 0)
                a *= a;
            return a;
        }
    }
}
