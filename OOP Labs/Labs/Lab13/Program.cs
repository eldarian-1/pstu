namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableStack stack1 = new ObservableStack();
            ObservableStack stack2 = new ObservableStack();
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();
            stack1.CountChanged += new StackHandler(journal1.CountChange);
            stack1.ReferenceChanged += new StackHandler(journal1.ReferenceChange);
            stack1.CountChanged += new StackHandler(journal2.CountChange);
            stack2.CountChanged += new StackHandler(journal2.CountChange);
        }
    }
}
