using System.Windows.Controls;

namespace WpfUi.Blocks.Forms
{
    public partial class StudentForm : UserControl
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        public new MainWindow Parent { get; set; }

        private void AddButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Parent.AddStudent(FirstName.Text, LastName.Text);
        }
    }
}
