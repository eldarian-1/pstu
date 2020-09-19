using System;

//  Вариант 14

namespace Task3
{
    class Program
    {
        private const char c_cA = 'a';
        private const char c_cB = 'b';

        private const double c_dA = 10d;
        private const double c_dB = 0.1d;

        private const double c_fA = 10f;
        private const double c_fB = 0.1f;

        private const string c_sDouble = "double";
        private const string c_sFloat = "float";
        private const string c_sGetNumber = "Введите число {0} ({1}): ";
        private const string c_sProgramText =
            "Операция с float:\n{0}\n\nОперация с double:\n{1}\n";

        static void Main(string[] args)
        {
            Console.WriteLine(c_sProgramText,
                Run(c_dA, c_dB), Run(c_fA, c_fB));
            Console.WriteLine("\n" + c_sProgramText,
                Run(GetDouble(c_cA), GetDouble(c_cB)),
                Run(GetFloat(c_cA), GetFloat(c_cB)));
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

        private static double Pow(double a, int b)
        {
            double result = a;
            while (--b > 0)
                result *= a;
            return result;
        }

        private static float Pow(float a, int b)
        {
            float result = a;
            while (--b > 0)
                result *= a;
            return result;
        }

        private static double GetFloat(char simbol)
        {
            float number = 0;
            for (bool flag = false; !flag;)
            {
                Console.Write(c_sGetNumber, simbol, c_sFloat);
                string sNum = Console.ReadLine();
                flag = float.TryParse(sNum, out number);
            }
            return number;
        }

        private static double GetDouble(char simbol)
        {
            double number = 0;
            for (bool flag = false; !flag;)
            {
                Console.Write(c_sGetNumber, simbol, c_sDouble);
                string sNum = Console.ReadLine();
                flag = double.TryParse(sNum, out number);
            }
            return number;
        }
    }
}
