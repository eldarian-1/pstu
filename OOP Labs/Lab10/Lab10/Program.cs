using System;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine[] engines = {
                new TurboReactiveEngine(1),
                new DieselEngine(2),
                new InternalCombustionEngine(3)
            };
            for (int i = 0; i < 3; ++i)
            {
                engines[i].Name();
                engines[i].Fuel();
            }
            Console.Read();
        }
    }
}
