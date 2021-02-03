using Controller;
using WpfUi.Blocks;
using Model.Entities;
using WpfUi.Blocks.Forms;
using WpfUi.Blocks.Tables;

namespace WpfUi
{
    public class Mediator : Controller.Mediator
    {
        private Facade _Facade;

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

        protected override void UpdateCollections()
        {
            base.UpdateCollections();
            _SubjectTable.SubjectList.ItemsSource = Subjects;
            _StudentTable.StudentList.ItemsSource = Students;
            _MarkTable.MarkList.ItemsSource = Marks;
            _MarkForm.StudentsBox.ItemsSource = Students;
            _MarkForm.SubjectsBox.ItemsSource = Subjects;
            _Setting.UseCasesBox.ItemsSource = _Facade.GetOperations();
        }

        public Mediator(MainWindow mainWindow) : base()
        {
            Initialize(mainWindow);
            SetMediator();
            UpdateCollections();
        }

        public Subject SelectedSubject => _SubjectTable.SelectedSubject;

        public Student SelectedStudent => _StudentTable.SelectedStudent;

        public Mark MarkSubject => _MarkTable.SelectedMark;

        public void EditSubject(Subject subject)
        {
            _SubjectForm.SetEditItem(subject);
            _SubjectForm.SetEditListener();
            UpdateCollections();
        }

        public void EditStudent(Student student)
        {
            _StudentForm.SetEditItem(student);
            _StudentForm.SetEditListener();
            UpdateCollections();
        }

        public void EditMark(Mark mark)
        {
            _MarkForm.SetEditItem(mark);
            _MarkForm.SetEditListener();
            UpdateCollections();
        }

        private void ClearAllForm()
        {
            _SubjectForm.Clear();
            _StudentForm.Clear();
            _MarkForm.Clear();
        }

        public override void RemoveSubject(Subject subject)
        {
            base.RemoveSubject(subject);
            ClearAllForm();
        }

        public override void RemoveStudent(Student student)
        {
            base.RemoveStudent(student);
            ClearAllForm();
        }

        public override void RemoveMark(Mark mark)
        {
            base.RemoveMark(mark);
            ClearAllForm();
        }
    }
}
