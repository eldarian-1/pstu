using System;

namespace Dialog
{
    public static class Input
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
                Console.WriteLine();
                if (!flag)
                    TaskRunner.Write(Output.IncorrectValue);
            }
        }
    }
}
