using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    class Controller
    {
        public static Student[] MakeCollection(int size)
        {
            Student[] mas = new Student[size];
            for(int i=0;i<size;i++)
            {
                Student s = new Student();
                s.Init();
                mas[i] = s;
            }

            return mas;
        }

        public static Student[] RemoveCollection(Student[] mas, int number )
        {
            Student[] temp = new Student[mas.Length - 1];
            int j = 0;
            for (int i = 0; i < number - 1; i++)
            {
                temp[j] = mas[i];
                j++;
            }
            for (int i =number; i < mas.Length; i++)
            {
                temp[j] = mas[i];
                j++;
            }

            mas = temp;
            return mas;

        }
    }
}
