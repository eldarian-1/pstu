using System;

namespace Lab10
{
    class InternalCombustionEngine : Engine
    {
        public InternalCombustionEngine(int i) : base(i) { }

        public override void Name()
            => Console.WriteLine("InternalCombustionEngine - {0}", index);

        public override void Fuel()
            => Console.WriteLine("Bensin - {0}", index);

        public override object Clone()
            => new InternalCombustionEngine(this.index);
    }
}
