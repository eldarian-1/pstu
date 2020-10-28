using System;

namespace Task1
{
    public static class Generate
    {
        private static Random rand = new Random();

        private const int c_iSizeMin = 10;
        private const int c_iSizeMax = 20;
        private const int c_iSizeMinB = 50;
        private const int c_iSizeMaxB = 99;
        private const int c_iIndexMin = 100;
        private const int c_iIndexMax = 999;
        private const int c_iInternalMin = 70;
        private const int c_iInternalMax = 150;
        private const int c_iDieselMin = 110;
        private const int c_iDieselMax = 200;
        private const int c_iReactiveMin = 300;
        private const int c_iReactiveMax = 900;

        public static void Run(out IExecutable[] arr, bool big = false)
        {
            int size;
            if(big)
                size = rand.Next(c_iSizeMinB, c_iSizeMaxB);
            else
                size = rand.Next(c_iSizeMin, c_iSizeMax);
            arr = new IExecutable[size];
            for(int i = 0; i < size; ++i)
                switch(rand.Next(0, 3))
                {
                    case 0:
                        arr[i] = new InternalCombustionEngine(rand.Next(c_iIndexMin, c_iIndexMax)) { Power = rand.Next(c_iInternalMin, c_iInternalMax) };
                        break;
                    case 1:
                        arr[i] = new DieselEngine(rand.Next(c_iIndexMin, c_iIndexMax)) { Power = rand.Next(c_iDieselMin, c_iDieselMax) };
                        break;
                    case 2:
                        arr[i] = new TurboReactiveEngine(rand.Next(c_iIndexMin, c_iIndexMax)) { Power = rand.Next(c_iReactiveMin, c_iReactiveMax) };
                        break;
                }
        }
    }
}
