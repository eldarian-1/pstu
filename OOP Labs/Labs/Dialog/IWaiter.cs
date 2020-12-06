using System;

namespace Dialog
{
    public interface IWaiter
    {
        string Menu { get; }
        MyList<Task> Tasks { get; }
        MyList<Exception> Reactions { get; }
    }
}
