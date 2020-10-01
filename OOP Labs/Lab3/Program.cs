﻿using System;

namespace Lab3
{
    delegate double GetNumber(double number);

    class Program
    {
        private const int c_iR = 3;
        private const int c_iN = 30;
        private const double c_dMin = 0.1d;
        private const double c_dMax = 1d;
        private const int c_iK = 10;
        private const double c_dD = (c_dMax - c_dMin) / c_iK;
        private const double c_dE = 0.0001;
        private const string c_sOutput =
            "x\t\t= {0}\nSn\t\t= {1}\nSe (n:{4})\t= {2}\ny = f(x)\t= {3}\n";

        private static GetNumber GetRound = number => Math.Round(number, c_iR);
        private static GetNumber GetReal = number => number;

        public static void Main(string[] args)
        {
            Run(GetRound);
            Console.ReadKey();
        }

        private static void Run(GetNumber GetNum)
        {
            for(double x = c_dMin; x <= c_dMax; x += c_dD)
            {
                Console.WriteLine(
                    c_sOutput, x,
                    GetNum(SeriesArithmetic(x)),
                    GetNum(SeriesDifferential(x, out int n)),
                    GetNum(Function(x)), n);
            }
        }

        private static double Function(double x)
        {
            return (1 + Math.Pow(x, 2)) / 2 * Math.Atan(x) - x / 2;
        }

        private static double Series(double x, int n)
        {
            return Math.Pow(-1, n + 1) * Math.Pow(x, 2 * n + 1)
                / (4 * Math.Pow(n, 2) - 1);
        }

        private static double SeriesArithmetic(double x)
        {
            double Sum = 0;
            for (int i = 1; i <= c_iN; ++i)
                Sum += Series(x, i);
            return Sum;
        }

        private static double SeriesDifferential(double x, out int i)
        {
            i = 0;
            double Sum = 0;
            double Result = Function(x);
            while(Math.Abs(Sum - Result) > c_dE)
                Sum += Series(x, ++i);
            return Sum;
        }
    }
}
