using System;

namespace Dialog
{
    public interface IMenu
    {
        string Menu { get; }
        MyList<Action> Tasks { get; }
        MyList<Exception> Reactions { get; }
    }
}
