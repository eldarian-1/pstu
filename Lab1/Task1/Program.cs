using System;

//  Вариант 14

namespace Task1
{
    delegate void Example();

    class Program
    {
        private const char c_cN = 'n';
        private const char c_cM = 'm';
        private const char c_cX = 'x';

        private const string c_sGetNumber = "Введите число {0}: ";
        private const string c_sExample = "ПРИМЕР {0}";
        private const string c_sExpression = "Выражение: {0}";
        private const string c_sExpressionType = "Тип выражения: {0}";
        private const string c_sExpressionValue = "Значение выражения: {0}";
        private const string c_sVariable = "Переменная {0}: {1}";

        private const int EXAMPLES_COUNT = 4;
        private static readonly Example[] examples =
            { Example1, Example2, Example3, Example4 };

        public static void Main(string[] args)
        {
            for (int i = 0; i < EXAMPLES_COUNT; ++i)
            {
                Console.WriteLine(c_sExample, i + 1);
                examples[i]();
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static void Example1()
        {
            GetNum(out int n, out int m);
            Console.WriteLine(c_sExpression, "n++ * --m");
            Expression(n++ * --m);
            WriteNM(n, m);
        }

        private static void Example2()
        {
            GetNum(out int n, out int m);
            Console.WriteLine(c_sExpression, "n-- < m++");
            Expression(n-- < m++);
            WriteNM(n, m);
        }

        private static void Example3()
        {
            GetNum(out int n, out int m);
            Console.WriteLine(c_sExpression, "--n < --m");
            Expression(--n < --m);
            WriteNM(n, m);
        }

        private static void Example4()
        {
            int x = 0;
            for (bool flag = false; !flag;)
            {
                GetNum(out x, c_cX);
                flag = x != 0;
            }
            Console.WriteLine(c_sExpression, "|x + 1|^(1/4) + 1 / x^2");
            Expression(Math.Pow(Math.Abs(x + 1), 1 / 4.0) + 1 / Math.Pow(x, 2));
            WriteNum(x, c_cX);
        }

        private static void GetNum(out int number, char simbol)
        {
            number = 0;
            for(bool flag = false; !flag;)
            {
                Console.Write(c_sGetNumber, simbol);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
            }
        }

        private static void GetNum(out int n, out int m)
        {
            GetNum(out n, c_cN);
            GetNum(out m, c_cM);
        }

        private static void Expression<T>(T result)
        {
            Console.WriteLine(c_sExpressionType, typeof(T).Name);
            Console.WriteLine(c_sExpressionValue, result);
        }

        private static void WriteNum(int number, char simbol)
        {
            Console.WriteLine(c_sVariable, simbol, number);
        }

        private static void WriteNM(int n, int m)
        {
            WriteNum(n, c_cN);
            WriteNum(m, c_cM);
        }
    }
}
