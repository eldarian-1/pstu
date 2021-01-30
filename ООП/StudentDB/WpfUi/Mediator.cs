using Controller;
using System.Linq;
using WpfUi.Blocks;
using Model.Entities;
using WpfUi.Blocks.Forms;
using WpfUi.Blocks.Tables;
using System.Collections.Generic;

namespace WpfUi
{
    public class Mediator
    {
        private Facade _Facade;

        private IEnumerable<Subject> _Subjects;
        private IEnumerable<Student> _Students;
        private IEnumerable<Mark> _Marks;

        private SubjectTable _SubjectTable;
        private StudentTable _StudentTable;
        private MarkTable _MarkTable;
        private SubjectForm _SubjectForm;
        private StudentForm _StudentForm;
        private MarkForm _MarkForm;
        private Setting _Setting;

        private void Initialize(MainWindow main)
        {
            _Facade = new Facade();
            _SubjectTable = main.SubjectTableItem;
            _StudentTable = main.StudentTableItem;
            _MarkTable = main.MarkTableItem;
            _SubjectForm = main.SubjectFormItem;
            _StudentForm = main.StudentFormItem;
            _MarkForm = main.MarkFormItem;
            _Setting = main.SettingItem;
        }

        private void SetMediator()
        {
            _SubjectTable.Mediator = this;
            _StudentTable.Mediator = this;
            _MarkTable.Mediator = this;
            _SubjectForm.Mediator = this;
            _StudentForm.Mediator = this;
            _MarkForm.Mediator = this;
            _Setting.Mediator = this;
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
            _SubjectTable.SubjectList.ItemsSource = Subjects;
            _StudentTable.StudentList.ItemsSource = Students;
            _MarkTable.MarkList.ItemsSource = Marks;
            _MarkForm.StudentsBox.ItemsSource = Students;
            _MarkForm.SubjectsBox.ItemsSource = Subjects;
            _Setting.UseCasesBox.ItemsSource = _Facade.GetOperations();
        }

        public Mediator(MainWindow mainWindow)
        {
            Initialize(mainWindow);
            SetMediator();
            SetData();
        }

        public IEnumerable<Subject> Subjects => _Subjects;

        public IEnumerable<Student> Students => _Students;

        public IEnumerable<Mark> Marks => _Marks;

        public Subject SelectedSubject => _SubjectTable.SelectedSubject;

        public Student SelectedStudent => _StudentTable.SelectedStudent;

        public Mark MarkSubject => _MarkTable.SelectedMark;

        public void AddSubject(string name)
        {
            _Facade.Subjects.Insert(new Subject { SubjectName = name });
            SetData();
        }

        public void AddStudent(string firstName, string lastName)
        {
            _Facade.Students.Insert(new Student
            {
                FirstName = firstName,
                LastName = lastName
            });
            SetData();
        }

        public void AddMark(long studentId, long subjectId, byte value)
        {
            _Facade.Marks.Insert(new Mark
            {
                StudentId = studentId,
                SubjectId = subjectId,
                MarkValue = value
            });
            SetData();
        }

        public void EditSubject(Subject subject)
        {
            _SubjectForm.SetEditItem(subject);
            _SubjectForm.SetEditListener();
            SetData();
        }

        public void EditStudent(Student student)
        {
            _StudentForm.SetEditItem(student);
            _StudentForm.SetEditListener();
            SetData();
        }

        public void EditMark(Mark mark)
        {
            _MarkForm.SetEditItem(mark);
            _MarkForm.SetEditListener();
            SetData();
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
            _SubjectForm.Clear();
            _StudentForm.Clear();
            _MarkForm.Clear();
        }

        public void RemoveSubject(Subject subject)
        {
            _Facade.Subjects.Delete(subject);
            Marks.Where(mark => mark.SubjectId == subject.SubjectId)
                .ToList().ForEach(mark => RemoveMark(mark));
            ClearAllForm();
            SetData();
        }

        public void RemoveStudent(Student student)
        {
            _Facade.Students.Delete(student);
            Marks.Where(mark => mark.StudentId == student.StudentId)
                .ToList().ForEach(mark => RemoveMark(mark));
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
