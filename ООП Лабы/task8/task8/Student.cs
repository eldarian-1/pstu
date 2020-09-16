using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    class Student
    {
        static string[] Names1 = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Воробьев", "Петухов", "Орлов", "Чайкин", "Кукушкин", "Михайлов" };
        static string[] Names2 = { "Иван", "Петр", "", "Дмитрий", "Максим", "Константин", "Борис", "Александр", "Алексей", "Михаил" };
        static string[] Groups = { "Gr1", "Gr2", "Gr3" };
        static Random rnd = new Random();

        public string Name;
        public string Group;

        public Student()
        {
            Name = "NoName";
            Group = "Gr1";
        }

        public Student(string name, string gr)
        {
            Name = name;
            Group = gr;
        }

        public override string ToString()
        {
            return Name + ", " + Group;
        }

        public void Init()
        {
            Name = Names1[rnd.Next(10)] + " " + Names2[rnd.Next(10)];
            Group = Groups[rnd.Next(3)];
        }
    }
}
