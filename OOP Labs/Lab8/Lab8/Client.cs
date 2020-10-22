using System;

namespace Lab8
{
    [Serializable]
    public class Client
    {
        public string Name { get; set; }

        public int Summ { get; set; }

        public string Type { get; set; }

        public string Period { get; set; }

        public override string ToString()
        {
            return "" + Name + " " + Summ + " " + Type + " " + Period;
        }

        public bool IsBeginOn(string name)
        {
            int N = Name.Length;
            int n = name.Length;
            if (N >= n)
            {
                bool flag = true;
                for (int i = 0; i < n && flag; i++)
                    flag = Name[i] == name[i];
                return flag;
            }
            else
                return false;
        }
    }
}
