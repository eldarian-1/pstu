using System;

//  Variant 14

namespace Task2
{
    class Program
    {
        public static void Main(string[] args)
        {
            do {
                Run(GetNum(), GetNum());
                Console.Write("Continue? (y - yes, other - no)");
            } while (Console.ReadLine()[0] == 'y');
            Console.ReadKey();
        }

        private static void Run(double x, double y)
        {
            Console.WriteLine("x = " + x + ", y = " + y + " is");
            if (!(RightTop(x, y) || LeftTop(x, y) || LeftBottom(x, y) || RightBottom(x, y)))
                Console.WriteLine(" not");
            Console.WriteLine(" entered in Area");
        }

        private static bool RightTop(double x, double y)
        {
            return x >= 0 && y >= 0 && x <= 1 && y <= 1 && y - x >= 0;
        }

        private static bool LeftTop(double x, double y)
        {
            return x <= 0 && y >= 0 && x >= -1 && y <= 1 && Math.Pow(Math.Pow(x,2)+ Math.Pow(y,2),1/2.0) <= 1;
        }

        private static bool LeftBottom(double x, double y)
        {
            return x <= 0 && y <= 0 && x >= -1 && y >= -1 && x - y >= 0;
        }

        private static bool RightBottom(double x, double y)
        {
            return x >= 0 && y <= 0 && x <= 1 && y >= -1 && Math.Pow(Math.Pow(x, 2) + Math.Pow(y, 2), 1 / 2.0) <= 1;
        }

        private static double GetNum()
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
    }
}
