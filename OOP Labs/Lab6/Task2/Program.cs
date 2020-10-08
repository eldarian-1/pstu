using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    public class Program
    {
        private static readonly Regex regex = new Regex(@"\b(\w+)");

        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string result = Proccessing(str);
            Console.WriteLine(result);
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