namespace Entity
{
    internal class InternalCombustionEngine : Engine
    {
        public InternalCombustionEngine(int i) : base(i) { }

        public override string Fuel => "Bensin";

        public override object Clone()
            => new InternalCombustionEngine(Index);
    }
}
