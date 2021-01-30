using System;
using System.Collections.Generic;

namespace Dialog
{
    public interface IMenu
    {
        string Menu { get; }

        IList<Action> Tasks { get; }

        IList<Exception> Reactions { get; }
    }
}
