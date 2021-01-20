using Controller;
using Model.Entities;
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
            SubjectTableItem.SubjectList.ItemsSource = _Facade.Subjects.SelectAll(new Subject());
            StudentTableItem.StudentList.ItemsSource = _Facade.Students.SelectAll(new Student());
            MarkTableItem.MarkList.ItemsSource = _Facade.Marks.SelectAll(new MarkEntry());
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
