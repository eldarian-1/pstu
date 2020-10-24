using System;
using System.Collections;

namespace Task1
{
    public interface IExecutable : IComparable, IComparer, ICloneable
    {
        int Index();
        void Name();
        void Fuel();
        int Power();
    }
}
