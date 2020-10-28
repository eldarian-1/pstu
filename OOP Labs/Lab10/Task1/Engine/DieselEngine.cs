using System;

namespace Task1
{
    public class DieselEngine : Engine
    {
        public DieselEngine(int i) : base(i) { }

        public new string Fuel => "Diesel";

        public override object Clone()
            => new DieselEngine(Index);
    }
}
