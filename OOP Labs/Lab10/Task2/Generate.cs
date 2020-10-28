using System;
using Task1;

namespace Task2
{
    static class Generate
    {
        private static Random rand = new Random();

        private const int c_iInternalMin = 70;
        private const int c_iInternalMax = 150;
        private const int c_iDieselMin = 110;
        private const int c_iDieselMax = 200;
        private const int c_iReactiveMin = 300;
        private const int c_iReactiveMax = 900;

        public static void Run(out IExecutable[] arr)
        {
            int size = rand.Next(10, 99);
            arr = new IExecutable[size];
            for(int i = 0; i < size; ++i)
                switch(rand.Next(0, 3))
                {
                    case 0:
                        arr[i] = new InternalCombustionEngine(i) { Power = rand.Next(c_iInternalMin, c_iInternalMax) };
                        break;
                    case 1:
                        arr[i] = new DieselEngine(i) { Power = rand.Next(c_iDieselMin, c_iDieselMax) };
                        break;
                    case 2:
                        arr[i] = new TurboReactiveEngine(i) { Power = rand.Next(c_iReactiveMin, c_iReactiveMax) };
                        break;
                }
        }
    }
}
