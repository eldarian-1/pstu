using System;

namespace Lab10
{
    class TurboReactiveEngine : Engine
    {
        public TurboReactiveEngine(int i) : base(i) { }

        public override void Name()
            => Console.WriteLine("TurboReactiveEngine - {0}", index);

        public virtual void Fuel()
            => Console.WriteLine("Hydrogen - {0}", index);
    }
}
