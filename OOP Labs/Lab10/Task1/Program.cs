using System;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            IExecutable[] engines = {
                new TurboReactiveEngine(9),
                new DieselEngine(15),
                new InternalCombustionEngine(19),
                new TurboReactiveEngine(16),
                new DieselEngine(15),
                new InternalCombustionEngine(2),
                new TurboReactiveEngine(13),
                new DieselEngine(22),
                new InternalCombustionEngine(10),
                new TurboReactiveEngine(4),
                new DieselEngine(11),
                new InternalCombustionEngine(25)
            };
            for (int i = 0, n = engines.Length; i < n; ++i)
            {
                engines[i].Name();
                engines[i].Fuel();
            }
            Array.Sort(engines);
            for (int i = 0, n = engines.Length; i < n; ++i)
                engines[i].Name();
            Console.Read();
        }
    }
}
