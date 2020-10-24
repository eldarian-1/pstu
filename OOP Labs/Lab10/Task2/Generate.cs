using System;
using Task1;

namespace Task2
{
    static class Generate
    {
        private static Random rand = new Random();

        public static void Run(out IExecutable[] arr)
        {
            int size = rand.Next(10, 99);
            arr = new IExecutable[size];
            for(int i = 0; i < size; ++i)
                switch(rand.Next(0, 3))
                {
                    case 0:
                        arr[i] = new InternalCombustionEngine(i) { Power = rand.Next(70, 150) };
                        break;
                    case 1:
                        arr[i] = new DieselEngine(i) { Power = rand.Next(110, 120) };
                        break;
                    case 2:
                        arr[i] = new TurboReactiveEngine(i) { Power = rand.Next(300, 900) };
                        break;
                }
        }
    }
}
