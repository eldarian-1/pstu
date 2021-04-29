using System;

namespace Dialog
{
    public class MenuManager
    {
        private static readonly Exception ProgramEnd = new ApplicationException();

        private static MenuManager s_Instance;
        private static int s_Level = 0;

        private const string c_UnknownError = "Неизвестная ошибка: ";
        private const string c_IncorrectValue = "Некорректное значение!";
        private const string c_EndProgram = "Спасибо за работу!";

        private IMenu Menu { get; set; }

        private MenuManager() { }

        public static MenuManager Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new MenuManager();
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
                    Write(c_IncorrectValue);
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
                catch(ApplicationException exception)
                {
                    if(s_Level == 1)
                        Write(c_EndProgram);
                    break;
                }
                catch (Exception exeption)
                {
                    if (Menu.Reactions.Contains(exeption))
                        Write(exeption.Message);
                    else
                        Write(c_UnknownError + exeption.Message);
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
