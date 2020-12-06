namespace Entity
{
    internal class TurboReactiveEngine : Engine
    {
        public TurboReactiveEngine(int i) : base(i) { }

        public string Fuel => "Hydrogen";

        public override object Clone()
            => new TurboReactiveEngine(Index) { Power = Power };

        public override IEngine BaseEngine => new Engine(Index) { Power = Power };
    }
}
