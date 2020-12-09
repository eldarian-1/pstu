using System;

namespace Dialog
{
    public static class Input
    {
        public static void ReadSymbol(out char symbol, string thing)
        {
            Console.Write(thing);
            symbol = Console.ReadLine()[0];
        }

        public static void ReadNum(out int number, string thing)
        {
            bool flag = false;
            number = 0;
            while (!flag)
            {
                Console.Write(thing);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
                Console.WriteLine();
                if (!flag)
                    Waiter.Write(Output.IncorrectValue);
            }
        }

        public static void ReadWord(out string word, string thing)
        {
            Console.Write(thing);
            word = Console.ReadLine();
        }
    }
}
