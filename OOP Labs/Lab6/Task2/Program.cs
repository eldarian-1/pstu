using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    class Program
    {
        private static readonly Regex regex = new Regex(@"\b(\w+)");

        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string result = Proccessing(str);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static string Proccessing(string str)
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
// hello world! меня зовут Эльдар. 453 564орпап алвпвалпр345  - helloh world меням зовут Эльдарэ 4534 564орпап алвлпр345Ф