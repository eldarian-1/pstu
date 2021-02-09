﻿using Resolution.Visuals;

namespace Logic.Visuals
{
    public partial class FunctionVisual : IVisible
    {
        public FunctionVisual()
        {
            IsVisible = true;
        }

        public bool IsVisible { get; private set; }

        public char Visual => IsVisible ? '✓' : '✖';

        public void ChangeVisible()
        {
            IsVisible = !IsVisible;
        }
    }
}
