﻿using System;

namespace Task1
{
    public abstract class Engine : IExecutable
    {
        protected int index;
        public int Power { get; set; }

        public Engine(int i)
            => index = i;

        public int Index()
            => index;

        public virtual void Name()
            => Console.WriteLine("Engine - {0}", index);

        public virtual void Fuel()
            => Console.WriteLine("Fuel - {0}", index);

        public int CompareTo(object obj)
        {
            Engine right = (Engine)obj;
            if (this.index > right.index)
                return 1;
            else if (this.index == right.index)
                return 0;
            return -1;
        }

        public int Compare(object left, object right)
            => ((Engine)left).CompareTo(right);

        public abstract object Clone();

        public Engine Copy()
            => (Engine)this.MemberwiseClone();
    }
}
