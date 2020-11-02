using System;

namespace Dialog
{
    internal static class Input
    {
        public static void ReadNum(out int number, string thing)
        {
            bool flag = false;
            number = 0;
            while(!flag)
            {
                Console.Write(thing);
                string sNum = Console.ReadLine();
                flag = int.TryParse(sNum, out number);
                if (!flag)
                    Console.WriteLine(Output.IncorrectValue);
                else
                    Console.WriteLine();
            }
        }
    }
}
