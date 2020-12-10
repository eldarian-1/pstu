using System;

namespace Entity
{
    internal class Generator
    {
        private Random rand = new Random();

        private const int c_iSizeMin = 10;
        private const int c_iSizeMax = 20;
        private const char c_cCharMin = 'A';
        private const int c_cCharMax = 'Z';
        private const int c_iWordSizeMin = 2;
        private const int c_iWordSizeMax = 5;
        private const int c_iIndexMin = 100;
        private const int c_iIndexMax = 999;
        private const int c_iInternalMin = 70;
        private const int c_iInternalMax = 150;
        private const int c_iDieselMin = 110;
        private const int c_iDieselMax = 200;
        private const int c_iReactiveMin = 300;
        private const int c_iReactiveMax = 900;

        public void Run(out double[] array, int count)
        {
            array = new double[count];
            for (int i = 0; i < count; ++i)
                array[i] = rand.NextDouble() - 0.5;
        }

        public void Run(out int[] array, int count)
        {
            array = new int[count];
            for (int i = 0; i < count; ++i)
                array[i] = rand.Next();
        }

        public void Run(out IEngine engine)
        {
            engine = null;
            switch (rand.Next(0, 3))
            {
                case 0:
                    engine = new InternalCombustionEngine(rand.Next(c_iIndexMin, c_iIndexMax)) { Power = rand.Next(c_iInternalMin, c_iInternalMax) };
                    break;
                case 1:
                    engine = new DieselEngine(rand.Next(c_iIndexMin, c_iIndexMax)) { Power = rand.Next(c_iDieselMin, c_iDieselMax) };
                    break;
                case 2:
                    engine = new TurboReactiveEngine(rand.Next(c_iIndexMin, c_iIndexMax)) { Power = rand.Next(c_iReactiveMin, c_iReactiveMax) };
                    break;
            }
        }

        public void Run(out IEngine[] engines, int count)
        {
            if(count == -1)
                count = rand.Next(c_iSizeMin, c_iSizeMax);
            engines = new IEngine[count];
            for (int i = 0; i < count; ++i)
                Run(out engines[i]);
        }

        public void Run(out char character)
        {
            int i = rand.Next(c_cCharMin, c_cCharMax);
            character = Convert.ToChar(i);
        }

        public void Run(out string pseudonym, bool isBig)
        {
            int size;
            if(isBig)
                size =  rand.Next(c_iSizeMin, c_iSizeMax);
            else
                size = rand.Next(c_iWordSizeMin, c_iWordSizeMax);
            char[] characters = new char[size];
            for (int i = 0; i < size; ++i)
                Run(out characters[i]);
            pseudonym = string.Join("", characters);
        }

        public void Run(out string[] pseudonyms, int size, bool isBig)
        {
            pseudonyms = new string[size];
            for (int i = 0; i < size; ++i)
                Run(out pseudonyms[i], isBig);
        }
    }
}
