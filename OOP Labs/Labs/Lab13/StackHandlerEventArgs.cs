using System;

namespace Lab13
{
    internal class StackHandlerEventArgs : EventArgs
    {
        public string Collection { get; set; }

        public string EditionType { get; set; }

        public object Object { get; set; }

        public override string ToString()
        {
            return Object + " - " + Collection + " : " + EditionType;
        }
    }
}
