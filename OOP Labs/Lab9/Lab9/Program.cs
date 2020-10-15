using System;

namespace Lab9
{
    delegate void GetNumber(out int number, char simbol, int i = -1);
    delegate GetNumber ModeGetNumber();
    delegate bool IsValidate(int x, int top);
    delegate void Task();

    class Program
    {
        public const char c_cN = 'N';
        public const char c_cR = 'R';
        public const char c_cP = 'P';

        private const int c_iMinArray = 10;
        private const int c_iMaxArray = 20;
        private const int c_iMaxRubles = 999;
        private const int c_iMaxPennies = 99;
        public const int c_iMaxInt = 2147483647;

        private const string c_sReadNumber = "Введите {0}: ";
        private const string c_sReadNumberA = "Введите {0}{1}: ";
        private const string c_sIncorrectValue = "Некорректное значение!";
        private const string c_sGetMode =
            "Введите способ получения чисел (1 - ввод, - 2 случайное): ";

        private static Random s_rand = new Random();

        static void Main(string[] args)
        {

        }

        public static void ReadNum(out int number, char simbol, int i)
        {
            number = 0;
            for (bool flag = false; !flag;)
            {
                if (i == -1)
                    Console.Write(c_sReadNumber, simbol);
                else
                    Console.Write(c_sReadNumberA, simbol, i);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
                if (!flag)
                    IncorrectValue();
            }
        }

        public static void RandNum(out int number, char simbol, int i)
        {
            if (simbol == c_cN)
                number = s_rand.Next(c_iMinArray, c_iMaxArray);
            else if (simbol == c_cR)
                number = s_rand.Next(0, c_iMaxRubles);
            else
                number = s_rand.Next(0, c_iMaxPennies);
        }

        private static GetNumber GetMode()
        {
            string key = "";
            do
            {
                Console.Write(c_sGetMode);
                key = Console.ReadLine();
            } while (key != "1" && key != "2");
            if (key == "1")
                return ReadNum;
            else
                return RandNum;
        }

        public static void IncorrectValue()
        {
            Console.WriteLine(c_sIncorrectValue);
        }
    }
}
