using Model.Entities;
using System.Windows;
using System.Windows.Controls;

namespace WpfUi.Blocks.Forms
{
    public partial class MarkForm : UserControl
    {
        private bool _IsEdit;
        private long _EditId;

        public MarkForm()
        {
            InitializeComponent();
        }

        public new MainWindow Parent { get; set; }

        public void SetEditItem(Mark mark)
        {
            _IsEdit = true;
            _EditId = mark.MarkId;
            StudentsBox.SelectedItem = null;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.AddMark(
                (StudentsBox.SelectedItem as Student).StudentId,
                (SubjectsBox.SelectedItem as Subject).SubjectId,
                byte.Parse((MarksBox.SelectedItem as ComboBoxItem).Content.ToString()));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.UpdateMark(new Mark {
                MarkId = _EditId,
                StudentId = (StudentsBox.SelectedItem as Student).StudentId,
                Value = byte.Parse((MarksBox.SelectedItem as ComboBoxItem).Content.ToString())
            });
        }
    }
}
