using System;

namespace Lab7
{
    class IncorrectIndex : Exception { }
    class IncorrectNewSize : Exception { }
    class IncorrectValue : Exception { }
    class AlreadySet : Exception { }
    class EmptyArray : Exception { }
    class IncorrectField : Exception
    {
        public int I { get; set; }
    }
    class IncorrectFields : Exception
    {
        public int N { get; set; }
        public int M { get; set; }
    }
}
