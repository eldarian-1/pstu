using Controller;
using Model.Entities;
using System.Windows;
using System.Collections.Generic;

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
            SubjectTableItem.Parent = this;
            StudentTableItem.Parent = this;
            MarkTableItem.Parent = this;
            SubjectFormItem.Parent = this;
            StudentFormItem.Parent = this;
            MarkFormItem.Parent = this;
            SettingItem.Parent = this;
        }

        private void SetData()
        {
            IEnumerable<Subject> subjects = _Facade.Subjects.SelectAll();
            IEnumerable<Student> students = _Facade.Students.SelectAll();
            IEnumerable<Mark> marks = _Facade.Marks.SelectAll();
            SubjectTableItem.SubjectList.ItemsSource = subjects;
            StudentTableItem.StudentList.ItemsSource = students;
            MarkTableItem.MarkList.ItemsSource = marks;
            MarkFormItem.StudentsBox.ItemsSource = students;
            MarkFormItem.SubjectsBox.ItemsSource = subjects;
            SettingItem.UseCasesBox.ItemsSource = _Facade.GetOperations();
        }

        public MainWindow()
        {
            InitializeComponent();
            Init();
            SetParent();
            SetData();
        }

        public Subject SelectedSubject => SubjectTableItem.SelectedSubject;

        public Student SelectedStudent => StudentTableItem.SelectedStudent;

        public Mark MarkSubject => MarkTableItem.SelectedMark;

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
            _Facade.Marks.Insert(new Mark {
                StudentId = studentId,
                SubjectId = subjectId,
                Value = value });
        }

        public void EditSubject(Subject subject)
        {
            SubjectFormItem.SetEditItem(subject);
        }

        public void EditStudent(Student student)
        {
            StudentFormItem.SetEditItem(student);
        }

        public void EditMark(Mark mark)
        {
            MarkFormItem.SetEditItem(mark);
        }

        public void UpdateSubject(Subject subject)
        {
            _Facade.Subjects.Update(subject);
        }

        public void UpdateStudent(Student student)
        {
            _Facade.Students.Update(student);
        }

        public void UpdateMark(Mark mark)
        {
            _Facade.Marks.Update(mark);
        }

        public void RemoveSubject(Subject subject)
        {
            _Facade.Subjects.Delete(subject);
        }

        public void RemoveStudent(Student student)
        {
            _Facade.Students.Delete(student);
        }

        public void RemoveMark(Mark mark)
        {
            _Facade.Marks.Delete(mark);
        }

        public void SetUseCase(string key)
        {
            _Facade.SetOperation(key);
            SetData();
        }
    }
}
