using System;

namespace Dialog
{
    public class TaskRunner
    {
        private static readonly Exception ProgramEnd = new ApplicationException();

        private static TaskRunner s_Instance;
        private static int s_Level = 0;

        private IWaiter Waiter { get; set; }

        private TaskRunner() { }

        public static TaskRunner Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new TaskRunner();
                return s_Instance;
            }
        }

        public static void WriteLine(string text)
            => Console.WriteLine(text + "\n");

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
                catch(ApplicationException)
                {
                    if(s_Level == 1)
                        WriteLine(Output.EndProgram);
                    break;
                }
                catch (Exception exeption)
                {
                    if (Waiter.Reactions.Contains(exeption))
                        WriteLine(exeption.Message);
                    else
                        WriteLine(Output.UnknownError);
                }
            }
        }

        public void Run(IWaiter waiter)
        {
            ++s_Level;
            IWaiter tWaiter = Waiter;
            Waiter = waiter;
            Run();
            Waiter = tWaiter;
            --s_Level;
        }
    }
}
