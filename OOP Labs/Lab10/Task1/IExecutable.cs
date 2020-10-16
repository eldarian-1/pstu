using System;
using System.Collections;

namespace Lab10
{
    interface IExecutable : IComparable, IComparer, ICloneable
    {
        void Name();
        void Fuel();
    }
}
