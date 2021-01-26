using System;
using System.Linq;
using Model.Entities;
using System.Windows;
using System.Windows.Controls;

namespace WpfUi.Blocks.Forms
{
    public partial class MarkForm : UserControl
    {
        private const int c_Min = 2;
        private const int c_Max = 5;

        private bool _IsEdit;
        private long _EditId;

        public MarkForm()
        {
            InitializeComponent();
            MarksBox.ItemsSource = Enumerable.Range(c_Min, c_Max - c_Min + 1).Reverse();
        }

        public new MainWindow Parent { get; set; }

        public void SetEditItem(Mark mark)
        {
            _IsEdit = true;
            _EditId = mark.MarkId;
            SubjectsBox.SelectedItem = Parent.Subjects
                .Where(subject => subject.SubjectId == mark.SubjectId)
                .ToArray()[0];
            StudentsBox.SelectedItem = Parent.Students
                .Where(student => student.StudentId == mark.StudentId)
                .ToArray()[0];
            MarksBox.SelectedIndex = c_Max - mark.Value;
        }

        public void Clear()
        {
            _IsEdit = false;
            StudentsBox.SelectedItem = null;
            SubjectsBox.SelectedItem = null;
            MarksBox.SelectedItem = null;
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
            Parent.AddMark(
                (StudentsBox.SelectedItem as Student).StudentId,
                (SubjectsBox.SelectedItem as Subject).SubjectId,
                byte.Parse(MarksBox.SelectedItem.ToString()));
            Clear();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.UpdateMark(new Mark {
                MarkId = _EditId,
                SubjectId = (SubjectsBox.SelectedItem as Subject).SubjectId,
                StudentId = (StudentsBox.SelectedItem as Student).StudentId,
                Value = byte.Parse(MarksBox.SelectedItem.ToString())});
            Clear();
            SetAddListener();
        }
    }
}
