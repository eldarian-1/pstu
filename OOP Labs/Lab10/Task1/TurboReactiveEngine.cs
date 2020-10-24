using System;

namespace Task1
{
    public class TurboReactiveEngine : Engine
    {
        public TurboReactiveEngine(int i) : base(i) { }

        public override void Name()
            => Console.WriteLine("TurboReactiveEngine - {0}", index);

        public virtual void Fuel()
            => Console.WriteLine("Hydrogen - {0}", index);

        public override object Clone()
            => new TurboReactiveEngine(this.index);
    }
}
