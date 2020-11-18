﻿namespace Entity
{
    public class Variable : ISymbol
    {
        public static int Count { get; protected set; } = 0;

        public Variable()
        {
            Name = ((char)('A' + Count++)).ToString();
            Value = false;
        }

        public void InvertValue() => Value = !Value;

        public string Name { get; }

        public string Briefly => Name;

        public string Wholly => Name;

        public override string ToString() => Name;

        public bool Value { get; set; }
    }
}
