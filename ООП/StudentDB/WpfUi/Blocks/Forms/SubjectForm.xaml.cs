using System.Windows.Controls;

namespace WpfUi.Blocks.Forms
{
    public partial class SubjectForm : UserControl
    {
        public SubjectForm()
        {
            InitializeComponent();
        }

        public new MainWindow Parent { get; set; }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Parent.AddSubject(SubjectName.Text);
        }
    }
}
