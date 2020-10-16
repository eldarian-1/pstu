using System;
using System.Collections;

namespace Lab10
{
    interface IExecutable : IComparable, IComparer, ICloneable
    {
        int Index();
        void Name();
        void Fuel();
    }
}
