using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    public delegate string ReadString();
    public delegate string GetString(string s);

    public class Program
    {
        private const string c_sEnter = "Введите строку: ";
        private const string c_sInput = "Начальная строка: {0}";
        private const string c_sOutput = "Конечная строка: {0}";
        private const string c_sEmpty = "пустая строка";
        private const string c_sContinue = "Продолжить? (д - да, другое - выход): ";
        private const string c_sExit = "Спасибо за работу!";
        private const string c_sModus =
            "Введите способ получения строк (1 - ввод, 2 - из массива): ";

        private static readonly Regex regex = new Regex(@"\b(\w+)");
        private static GetString GetStr = str => str == "" ? c_sEmpty : "\"" + str + "\"";

        private const int c_iCount = 10;
        private static int s_iIndex = 0;
        private static readonly string[] r_sStrings = {
            "hello world!",
            "меня зовут Эльдар.",
            ". 453 564орпап",
            "алвпвалпр345  - helloh world",
            "меням зовут ЭльдарЭ Эльдарэ",
            "4534 564орпап алвлпр345Ф",
            "helloh helloh",
            "helloh",
            "What isi your name?",
            "WhtsW EASYE"
        };

        public static void Main(string[] args)
        {
            do
            {
                string input = GetMode()();
                string output = Proccessing(input);
                Console.WriteLine(c_sInput, GetStr(input));
                Console.WriteLine(c_sOutput, GetStr(output));
            }
            while (IsContinued());
            Console.WriteLine(c_sExit);
            Console.ReadKey();
        }

        public static string FromArray()
        {
            if (s_iIndex == c_iCount)
                s_iIndex = 0;
            return r_sStrings[s_iIndex++];
        }

        public static string ReadStr()
        {
            Console.Write(c_sEnter);
            return Console.ReadLine();
        }

        public static ReadString GetMode()
        {
            string key = "";
            do
            {
                Console.Write(c_sModus);
                key = Console.ReadLine();
            } while (key != "1" && key != "2");
            if (key == "1")
                return ReadStr;
            else
                return FromArray;
        }

        public static bool IsContinued()
        {
            Console.Write(c_sContinue);
            bool flag = Console.ReadLine() == "д";
            Console.WriteLine();
            return flag;
        }

        public static string Proccessing(string str)
        {
            StringBuilder strBuild = new StringBuilder(str);
            MatchCollection matches = regex.Matches(str);
            foreach(Match match in matches)
            {
                string word = match.Value;
                if (word[0] == word[word.Length - 1])
                    strBuild.Replace(word, "");
            }
            return strBuild.ToString();
        }
    }
}