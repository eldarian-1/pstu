using System;

namespace Dialog
{
    public class TaskRunner
    {
        private static readonly Exception ProgramEnd
            = new Exception("Спасибо за работу");

        private IWaiter Waiter { get; set; }

        public TaskRunner(IWaiter waiter)
            => Waiter = waiter;

        public Task GetTask()
        {
            while (true)
            {
                Input.ReadNum(out int i, Waiter.Menu);
                if (Waiter.Tasks.Count >= i && i > 0)
                    return Waiter.Tasks[i - 1];
                else if (i == 0)
                    throw ProgramEnd;
                else
                    continue;
            }
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    GetTask()();
                }
                catch (Exception e)
                {
                    if (Waiter.Reactions.Contains(e) || e == ProgramEnd)
                        Console.WriteLine(e.Message);
                    else
                        Console.WriteLine(Output.UnknownError);
                    if (e == ProgramEnd)
                        break;
                }
            }
        }

        public void Run(IWaiter waiter)
        {
            IWaiter tWaiter = Waiter;
            Waiter = waiter;
            Run();
            Waiter = tWaiter;
        }
    }
}
