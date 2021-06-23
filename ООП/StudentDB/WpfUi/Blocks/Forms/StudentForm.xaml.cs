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

        public Mediator Mediator { get; set; }

        public void SetEditItem(Student student)
        {
            _IsEdit = true;
            _EditId = student.StudentId;
            FirstName.Text = student.FirstName;
            LastName.Text = student.LastName;
        }

        public void Clear()
        {
            _IsEdit = false;
            FirstName.Text = "";
            LastName.Text = "";
        }

        public void SetAddListener()
        {
            ActionButton.Click -= EditButton_Click;
            ActionButton.Click += AddButton_Click;
            ActionButton.Content = "Добавить";
        }

        public void SetEditListener()
        {
            ActionButton.Click -= AddButton_Click;
            ActionButton.Click += EditButton_Click;
            ActionButton.Content = "Обновить";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Mediator.AddStudent(FirstName.Text, LastName.Text);
            Clear();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Mediator.UpdateStudent(new Student
            {
                StudentId = _EditId,
                FirstName = FirstName.Text,
                LastName = LastName.Text});
            Clear();
            SetAddListener();
        }
    }
}
