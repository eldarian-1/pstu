using System;

namespace Lab9
{
    delegate void GetNumber(out int number, string thing, int i = -1);
    delegate void GetValidate(out int number, GetNumber GetNum, IsValidate IsValid, string thing);
    delegate GetNumber ModeGetNumber();
    delegate bool IsValidate(int x);
    delegate void Task();
    delegate Task GetTask();

    static class Core
    {
        public static IsValidate IsValidRuble = n => n >= 0 && n < MaxInt - MaxInt / Devide;
        public static IsValidate IsValidPenny = n => n >= 0 && n < MaxInt;
        public static IsValidate IsValidNum = IsValidPenny;
        
        public const int MinArray = 10;
        public const int MaxArray = 20;
        public const int MaxRubles = 999;
        public const int MaxPennies = 99;
        public const int Devide = 100;
        public const int MaxInt = 2147483647;

        public static Random Rand = new Random();

        public static void MinimumMoneyArray(MoneyArray array, out int index, out Money money)
        {
            if (array == null)
                throw new InvalidOperationException();
            int len = array.Length;
            if (len == 0)
                throw new InvalidOperationException();
            money = array[0];
            index = 0;
            for (int i = 1; i < len; ++i)
                if (money > array[i])
                {
                    money = array[i];
                    index = i;
                }
        }
    }
}
