using System;

namespace Dialog
{
    public class Waiter
    {
        private static readonly Exception ProgramEnd = new ApplicationException();

        private static Waiter s_Instance;
        private static int s_Level = 0;

        private IMenu Menu { get; set; }

        private Waiter() { }

        public static Waiter Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new Waiter();
                return s_Instance;
            }
        }

        public static void Write(string text)
            => Console.WriteLine(text + "\n");

        public Action GetTask()
        {
            while (true)
            {
                Input.ReadNum(out int i, Menu.Menu);
                if (Menu.Tasks.Count >= i && i > 0)
                    return Menu.Tasks[i - 1];
                else if (i == 0)
                    throw ProgramEnd;
                else
                {
                    Write(Output.IncorrectValue);
                    continue;
                }
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
                        Write(Output.EndProgram);
                    break;
                }
                catch (Exception exeption)
                {
                    if (Menu.Reactions.Contains(exeption))
                        Write(exeption.Message);
                    else
                        Write(Output.UnknownError);
                }
            }
        }

        public void Run(IMenu waiter)
        {
            ++s_Level;
            IMenu tWaiter = Menu;
            Menu = waiter;
            Run();
            Menu = tWaiter;
            --s_Level;
        }
    }
}
