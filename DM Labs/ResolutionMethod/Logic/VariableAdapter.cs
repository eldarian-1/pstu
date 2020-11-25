﻿using Entity;

namespace Logic
{
    public class VariableAdapter : Variable
    {
        public VariableAdapter() : base() { }

        public bool IsVisible { get; private set; }

        public char Visual => IsVisible ? 'f' : 'a';

        public char Data => Value ? '1' : '0';

        public void InvertVisible()
        {

        }
    }
}
