using System;

namespace Lab3
{
    class Program
    {
        private const int c_iN = 30;
        private const double c_dMin = 0.1d;
        private const double c_dMax = 1d;
        private const double c_dK = 10d;
        private const double c_dD = (c_dMax - c_dMin) / c_dK;
        private const double c_dE = 0.0001;
        private const string c_sOutput = "x = {0}; Sn = {1}; Se = {2}; y = f(x) = {3}";

        public static void Main(string[] args)
        {
            Run();
            Console.ReadKey();
        }

        private static void Run()
        {
            for(double x = c_dMin; x <= c_dMax; x += c_dD)
            {
                Console.WriteLine(
                    c_sOutput, x,
                    SeriesArithmetic(x),
                    SeriesDifferential(x),
                    Function(x));
            }
        }

        private static double Function(double x)
        {
            return (1 + Math.Pow(x, 2)) / 2 * Math.Atan(x) - x / 2;
        }

        private static double Series(double x, int n)
        {
            return Math.Pow(-1, n + 1) * Math.Pow(x, 2 * n + 1) / (4 * Math.Pow(n, 2) - 1);
        }

        private static double SeriesArithmetic(double x)
        {
            double Sum = 0;
            for (int i = 1; i <= c_iN; ++i)
                Sum += Series(x, i);
            return Sum;
        }

        private static double SeriesDifferential(double x)
        {
            int i = 1;
            double Sum = 0;
            double Result = Function(x);
            while(Math.Abs(Sum - Result) > c_dE)
                Sum += Series(x, i++);
            return Sum;
        }
    }
}
