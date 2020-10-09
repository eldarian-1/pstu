using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    public class Program
    {
        private const string c_sEnter = "Введите строку";
        private const string c_sResult = "Результат выполнения программы";
        private const string c_sContinue = "Продолжить? (д - да, другое - выход)";
        private const string c_sExit = "Спасибо за работу!";

        private static readonly Regex regex = new Regex(@"\b(\w+)");

        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine(c_sEnter);
                string str = Console.ReadLine();

                Console.WriteLine(c_sResult);
                string result = Proccessing(str);
                Console.WriteLine(result);

                Console.WriteLine(c_sContinue);
            }
            while (Console.ReadLine() == "д");
            Console.WriteLine(c_sExit);
            Console.ReadKey();
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