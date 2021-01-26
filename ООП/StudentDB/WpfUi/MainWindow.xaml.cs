using Controller;
using System.Linq;
using Model.Entities;
using System.Windows;
using System.Collections.Generic;
using WpfUi.Wrappers;

namespace WpfUi
{
    public partial class MainWindow : Window
    {
        private Facade _Facade;

        private IEnumerable<Subject> _Subjects;
        private IEnumerable<Student> _Students;
        private IEnumerable<Mark> _Marks;

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

        private void UpdateCollections()
        {
            _Subjects = _Facade.Subjects.SelectAll();
            _Students = _Facade.Students.SelectAll();
            _Marks = new MarkJournal(_Facade.Marks.SelectAll(), this);
        }

        private void SetData()
        {
            UpdateCollections();
            SubjectTableItem.SubjectList.ItemsSource = Subjects;
            StudentTableItem.StudentList.ItemsSource = Students;
            MarkTableItem.MarkList.ItemsSource = Marks;
            MarkFormItem.StudentsBox.ItemsSource = Students;
            MarkFormItem.SubjectsBox.ItemsSource = Subjects;
            SettingItem.UseCasesBox.ItemsSource = _Facade.GetOperations();
        }

        public MainWindow()
        {
            InitializeComponent();
            Init();
            SetParent();
            SetData();
        }

        public IEnumerable<Subject> Subjects => _Subjects;

        public IEnumerable<Student> Students => _Students;

        public IEnumerable<Mark> Marks => _Marks;

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
            SetData();
        }

        public void AddMark(long studentId, long subjectId, byte value)
        {
            _Facade.Marks.Insert(new Mark {
                StudentId = studentId,
                SubjectId = subjectId,
                Value = value });
            SetData();
        }

        public void EditSubject(Subject subject)
        {
            SubjectFormItem.SetEditItem(subject);
            SubjectFormItem.SetEditListener();
        }

        public void EditStudent(Student student)
        {
            StudentFormItem.SetEditItem(student);
            StudentFormItem.SetEditListener();
        }

        public void EditMark(Mark mark)
        {
            MarkFormItem.SetEditItem(mark);
            MarkFormItem.SetEditListener();
        }

        public void UpdateSubject(Subject subject)
        {
            _Facade.Subjects.Update(subject);
            SetData();
        }

        public void UpdateStudent(Student student)
        {
            _Facade.Students.Update(student);
            SetData();
        }

        public void UpdateMark(Mark mark)
        {
            _Facade.Marks.Update(mark);
            SetData();
        }

        private void ClearAllForm()
        {
            SubjectFormItem.Clear();
            StudentFormItem.Clear();
            MarkFormItem.Clear();
        }

        public void RemoveSubject(Subject subject)
        {
            _Facade.Subjects.Delete(subject);
            Marks.Where(mark => mark.SubjectId == subject.SubjectId).ToList().ForEach(mark => RemoveMark(mark));
            ClearAllForm();
            SetData();
        }

        public void RemoveStudent(Student student)
        {
            _Facade.Students.Delete(student);
            Marks.Where(mark => mark.StudentId == student.StudentId).ToList().ForEach(mark => RemoveMark(mark));
            ClearAllForm();
            SetData();
        }

        public void RemoveMark(Mark mark)
        {
            _Facade.Marks.Delete(mark);
            ClearAllForm();
            SetData();
        }

        public void SetUseCase(string key)
        {
            _Facade.SetOperation(key);
            SetData();
        }
    }
}
