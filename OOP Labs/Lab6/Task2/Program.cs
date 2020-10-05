using System;
using System.Text.RegularExpressions;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex r = new Regex(@"\b(\w+)"); //[a-zA-Zа-яА-Я]
            string s = Console.ReadLine();
            string[] ss = r.Split(s);
            for (int i = 0, n = ss.Length; i < n; ++i)
            {
                string word = ss[i].ToLower();
                if (word == "" || word == " ")
                    continue;
                char c1 = word[0];
                char c2 = word[word.Length - 1];
                if (c1 == c2)
                    Console.WriteLine(word);
            }
            Console.ReadKey();
        }
    } // hello world! меня зовут Эльдар. 453 564орпап алвпвалпр345  - helloh world меням зовут Эльдарэ 4534 564орпап алвпвалпр345Ф
}
