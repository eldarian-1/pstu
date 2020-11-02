using System;

namespace Entity
{
    public interface IExecutable : IComparable, ICloneable
    {
        int Index { get; }
        int Power { get; set; }
        string Name { get; }
        string Fuel { get; }
    }
}
