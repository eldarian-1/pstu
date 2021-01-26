using Model.Entities;
using System.Windows;
using System.Windows.Controls;

namespace WpfUi.Blocks.Forms
{
    public partial class StudentForm : UserControl
    {
        private bool _IsEdit;
        private long _EditId;

        public StudentForm()
        {
            InitializeComponent();
        }

        public new MainWindow Parent { get; set; }

        public void SetEditItem(Student student)
        {
            _IsEdit = true;
            _EditId = student.StudentId;
            FirstName.Text = student.FirstName;
            LastName.Text = student.LastName;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.AddStudent(FirstName.Text, LastName.Text);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.UpdateStudent(new Student
            {
                StudentId = _EditId,
                FirstName = FirstName.Text,
                LastName = LastName.Text
            });
        }
    }
}
