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
        public static IsValidate IsValidRuble = n => n >= 0;
        public static IsValidate IsValidPenny = n => n >= 0 && n < 100;
        
        public const int MinArray = 10;
        public const int MaxArray = 20;
        public const int MaxRubles = 999;
        public const int MaxPennies = 99;
        public const int MaxInt = 2147483647;

        public static Random Rand = new Random();
    }
}
