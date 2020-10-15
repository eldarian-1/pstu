using System;

namespace Lab10
{
    class DieselEngine : Engine
    {
        public DieselEngine(int i) : base(i) { }

        public override void Name()
            => Console.WriteLine("DieselEngine - {0}", index);

        public new void Fuel()
            => Console.WriteLine("Diesel - {0}", index);
    }
}
