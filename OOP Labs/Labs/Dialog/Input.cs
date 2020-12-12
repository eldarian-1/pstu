using System;

namespace Dialog
{
    public static class Input
    {
        private const string c_IncorrectValue = "Некорректное значение!";

        public static void ReadSymbol(out char symbol, string thing)
        {
            bool flag;
            string word;
            do
            {
                Console.Write(thing);
                word = Console.ReadLine();
                flag = word != "";
                if (!flag)
                    Waiter.Write(c_IncorrectValue);
            }
            while (!flag);
            symbol = word[0];
        }

        public static void ReadBoolean(out bool value, string thing)
        {
            bool flag;
            do
            {
                Console.Write(thing + "\nyes/no: ");
                string inline = Console.ReadLine();
                flag = inline != "yes" && inline != "no";
                value = inline == "yes";
            }
            while (flag);
        }

        public static void ReadNum(out int number, string thing, Func<int, bool> func = null)
        {
            bool flag;
            do
            {
                Console.Write(thing);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
                Console.WriteLine();
                if (flag && func != null)
                    flag = func(number);
                if (!flag)
                    Waiter.Write(c_IncorrectValue);
            }
            while (!flag);
        }

        public static void ReadWord(out string word, string thing)
        {
            bool flag;
            do
            {
                Console.Write(thing);
                word = Console.ReadLine();
                flag = word != "";
                if (!flag)
                    Waiter.Write(c_IncorrectValue);
            }
            while (!flag);
        }
    }
}
