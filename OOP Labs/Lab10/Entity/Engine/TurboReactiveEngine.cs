namespace Entity
{
    public class TurboReactiveEngine : Engine
    {
        public TurboReactiveEngine(int i) : base(i) { }

        public string Fuel => "Hydrogen";

        public override object Clone()
            => new TurboReactiveEngine(Index);
    }
}
