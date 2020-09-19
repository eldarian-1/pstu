using System;

//  Вариант 14

namespace Task2
{
    class Program
    {
        private const char c_cX = 'x';
        private const char c_cY = 'y';
        private const char c_cD = 'д';

        private const string c_sPointInfo = "Точка M({0}, {1})";
        private const string c_sNot = " не";
        private const string c_sIsEntered = " входит в область фигуры";
        private const string c_sContinue = "Продолжить? (д - да, иначе - нет)";
        private const string c_sGetNumber = "Введите число {0}: ";

        static void Main(string[] args)
        {
            do {
                RunCalculate(GetNum(c_cX), GetNum(c_cY));
                Console.Write(c_sContinue);
            } while (Console.ReadLine()[0] == c_cD);

            Console.WriteLine();
            TestSystem();
            Console.ReadKey();
        }

        private static void TestSystem()
        {
            RunCalculate(0.0, 0.1);
            RunCalculate(0.2, -0.3);
            RunCalculate(0.4, 0.5);
            RunCalculate(0.6, -0.7);
            RunCalculate(0.8, 0.9);
            RunCalculate(1.0, -1.1);
            RunCalculate(1.2, 1.3);
            RunCalculate(1.4, -1.5);
            RunCalculate(0.0, -0.1);
            RunCalculate(-0.2, 0.3);
            RunCalculate(0.4, -0.5);
            RunCalculate(-0.6, 0.7);
            RunCalculate(0.8, -0.9);
            RunCalculate(-1.0, 1.1);
            RunCalculate(1.2, -1.3);
            RunCalculate(-1.4, 1.5);
        }

        private static void RunCalculate(double x, double y)
        {
            Console.Write(c_sPointInfo, x, y);
            if (Calculate(x, y))
                Console.Write(c_sNot);
            Console.WriteLine(c_sIsEntered);
        }

        private static bool Calculate(double x, double y)
        {
            return !(RightTop(x, y)
                || LeftTop(x, y)
                || LeftBottom(x, y)
                || RightBottom(x, y));
        }

        private static bool RightTop(double x, double y)
        {
            return x >= 0
                && y >= 0
                && x <= 1
                && y <= 1
                && -1 * (x - 1) <= y;
        }

        private static bool LeftTop(double x, double y)
        {
            return x <= 0
                && y >= 0
                && Math.Pow(Math.Pow(x,2)+ Math.Pow(y,2),1/2.0) <= 1;
        }

        private static bool LeftBottom(double x, double y)
        {
            return x <= 0
                && y <= 0
                && x >= -1
                && y >= -1
                && x - 1 >= y;
        }

        private static bool RightBottom(double x, double y)
        {
            return x >= 0
                && y <= 0
                && Math.Pow(Math.Pow(x, 2) + Math.Pow(y, 2), 1 / 2.0) <= 1;
        }

        private static double GetNum(char simbol)
        {
            double number = 0;
            for (bool flag = false; !flag;)
            {
                Console.Write(c_sGetNumber, simbol);
                string sNum = Console.ReadLine();
                flag = double.TryParse(sNum, out number);
            }
            return number;
        }
    }
}
