using System;

namespace Lab13
{
    internal class StackHandlerEventArgs : EventArgs
    {
        public StackHandlerEventArgs(object obj, string collection, string editType)
        {
            Object = obj;
            Collection = collection;
            EditionType = editType;
        }

        public string Collection { get; set; }

        public string EditionType { get; set; }

        public object Object { get; set; }

        public override string ToString()
        {
            return Object + " - " + Collection + " : " + EditionType;
        }
    }
}
