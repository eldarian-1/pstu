using Controller;
using Model.Entities;
using System.Collections.Generic;
using System.Windows;

namespace WpfUi
{
    public partial class MainWindow : Window
    {
        private Facade _Facade;

        private void Init()
        {
            _Facade = new Facade();
        }

        private void SetParent()
        {
            SubjectFormItem.Parent = this;
            StudentFormItem.Parent = this;
        }

        private void SetData()
        {
            IEnumerable<Subject> subjects = _Facade.Subjects.SelectAll();
            IEnumerable<Student> students = _Facade.Students.SelectAll();
            IEnumerable<MarkEntry> marks = _Facade.Marks.SelectAll();
            SubjectTableItem.SubjectList.ItemsSource = subjects;
            StudentTableItem.StudentList.ItemsSource = students;
            MarkTableItem.MarkList.ItemsSource = marks;
            MarkFormItem.StudentsBox.ItemsSource = students;
            MarkFormItem.SubjectsBox.ItemsSource = subjects;
        }

        public MainWindow()
        {
            InitializeComponent();
            Init();
            SetParent();
            SetData();
        }

        public void AddSubject(string name)
        {
            _Facade.Subjects.Insert(new Subject { Name = name });
        }

        public void AddStudent(string firstName, string lastName)
        {
            _Facade.Students.Insert(new Student {
                FirstName = firstName,
                LastName = lastName });
        }

        public void AddMark(long studentId, long subjectId, byte value)
        {
            _Facade.Marks.Insert(new MarkEntry {
                StudentId = studentId,
                SubjectId = subjectId,
                Value = value });
        }
    }
}
