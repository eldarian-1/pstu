namespace Entity
{
    internal class DieselEngine : Engine
    {
        public DieselEngine(int i) : base(i) { }

        public new string Fuel => "Diesel";

        public override object Clone()
            => new DieselEngine(Index);

        public override IEngine BaseEngine => new Engine(Index);
    }
}
