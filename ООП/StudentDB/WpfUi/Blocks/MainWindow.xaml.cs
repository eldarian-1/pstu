using System.Windows;

namespace WpfUi.Blocks
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Mediator(this);
        }
    }
}
