using Model.Entities;
using System.Windows;
using System.Windows.Controls;

namespace WpfUi.Blocks.Forms
{
    public partial class MarkForm : UserControl
    {
        public MarkForm()
        {
            InitializeComponent();
        }

        public new MainWindow Parent { get; set; }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.AddMark(
                (StudentsBox.SelectedItem as Student).StudentId,
                (SubjectsBox.SelectedItem as Subject).SubjectId,
                byte.Parse((MarksBox.SelectedItem as ComboBoxItem).Content.ToString()));
        }
    }
}
