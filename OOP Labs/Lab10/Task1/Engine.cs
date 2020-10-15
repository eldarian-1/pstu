using System;

namespace Lab10
{
    class Engine
    {
        protected int index;

        public Engine(int i)
        {
            index = i;
        }

        public virtual void Name()
            => Console.WriteLine("Engine - {0}", index);

        public virtual void Fuel()
            => Console.WriteLine("Fuel - {0}", index);
    }
}
